using System;
using System.Collections.Generic;
using DTO;
using DAO;
using DAO.Mapper;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO.Mapper.impl;
using DAO.utils;
using DAO.impl;
using Google.Protobuf.WellKnownTypes;
using static System.Net.Mime.MediaTypeNames;
using System.Data.SqlClient;

namespace DAO.DAO.impl
{
    public class ThongKeDAO
    {
        const string connectionString = "Server=localhost;Database=quanlikhohang;User ID=root;Password=123456;Port=3306;";
        public static List<ThongKeKhachHangDTO> GetThongKeKhachHang(string filterText, DateTime start, DateTime end)
        {
            var result = new List<ThongKeKhachHangDTO>();

            // Lấy dữ liệu phiếu xuất và khách hàng
            var phieuxuatList = new PhieuXuatDAO().GetAll();
            var khachhangList = new KhachHangDAO().GetAll();

            // Lọc khách hàng dựa trên filterText
            if (!string.IsNullOrEmpty(filterText))
            {
                khachhangList = khachhangList.Where(kh => kh.TenKhachHang.Contains(filterText)).ToList();
            }

            foreach (var khachHang in khachhangList)
            {
                // Lọc ra các phiếu xuất của khách hàng trong khoảng thời gian start và end
                var phieuXuatKhachHang = phieuxuatList
                    .Where(px => px.Makh == khachHang.MakH && px.Thoigian >= start && px.Thoigian <= end)
                    .ToList();

                // Nếu khách hàng không có phiếu xuất trong khoảng thời gian -> bỏ qua
                if (!phieuXuatKhachHang.Any()) continue;

                // Tính số lượng phiếu xuất và tổng tiền
                int soLuongPhieu = phieuXuatKhachHang.Count;
                long? tongTien = phieuXuatKhachHang.Sum(px => px.Tongtien);

                var thongKeKhachHang = new ThongKeKhachHangDTO
                {
                    MaKH = (int)khachHang.MakH,
                    TenKH = khachHang.TenKhachHang,
                    SoLuongPhieu = soLuongPhieu,
                    Tongtien = (long)tongTien
                };

                // Thêm vào kết quả
                result.Add(thongKeKhachHang);
            }

            return result;
        }

        public static List<ThongKeNhaCungCapDTO> GetThongKeNCC(string filterText, DateTime start, DateTime end)
        {
            var result = new List<ThongKeNhaCungCapDTO>();

            // Lấy dữ liệu phiếu nhập và nhà cung cấp
            var phieunhapList = new PhieuNhapDAO().GetAll();
            var nhacungcapList = new NhaCungCapDAO().GetAll();

            // Lọc nhà cung cấp dựa trên filterText
            if (!string.IsNullOrEmpty(filterText))
            {
                nhacungcapList = nhacungcapList.Where(ncc => ncc.Tennhacungcap.Contains(filterText)).ToList();
            }

            foreach (var nhaCungCap in nhacungcapList)
            {
                // Lọc ra các phiếu nhập của nhà cung cấp trong khoảng thời gian start và end
                var phieuNhapNhaCungCap = phieunhapList
                    .Where(pn => pn.Manhacungcap == nhaCungCap.Manhacungcap && pn.Thoigian >= start && pn.Thoigian <= end)
                    .ToList();

                // Nếu nhà cung cấp không có phiếu nhập trong khoảng thời gian -> bỏ qua
                if (!phieuNhapNhaCungCap.Any()) continue;

                // Tính số lượng phiếu nhập và tổng tiền
                int soLuongPhieu = phieuNhapNhaCungCap.Count;
                long tongTien = phieuNhapNhaCungCap.Sum(pn => pn.Tongtien);

                var thongKeNhaCungCap = new ThongKeNhaCungCapDTO
                {
                    MaNCC = nhaCungCap.Manhacungcap,
                    TenNCC = nhaCungCap.Tennhacungcap,
                    SoLuong = soLuongPhieu,
                    Tongtien = tongTien
                };

                // Thêm vào kết quả
                result.Add(thongKeNhaCungCap);
            }

            return result;
        }

        public static Dictionary<int, List<ThongKeTonKhoDTO>> GetThongKeTonKho(string filterText, DateTime timeStart, DateTime timeEnd)
        {
            var result = new Dictionary<int, List<ThongKeTonKhoDTO>>();

            // Thiết lập thời gian kết thúc với giờ, phút, giây
            timeEnd = new DateTime(timeEnd.Year, timeEnd.Month, timeEnd.Day, 23, 59, 0);

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string sql = @"
                    WITH nhap AS (
                      SELECT maphienbansp, SUM(soluong) AS sl_nhap
                      FROM ctphieunhap
                      JOIN phieunhap ON phieunhap.maphieunhap = ctphieunhap.maphieunhap
                      WHERE thoigian BETWEEN @timeStart AND @timeEnd
                      GROUP BY maphienbansp
                    ),
                    xuat AS (
                      SELECT maphienbansp, SUM(soluong) AS sl_xuat
                      FROM ctphieuxuat
                      JOIN phieuxuat ON phieuxuat.maphieuxuat = ctphieuxuat.maphieuxuat
                      WHERE thoigian BETWEEN @timeStart AND @timeEnd
                      GROUP BY maphienbansp
                    ),
                    nhap_dau AS (
                      SELECT ctphieunhap.maphienbansp, SUM(ctphieunhap.soluong) AS sl_nhap_dau
                      FROM phieunhap
                      JOIN ctphieunhap ON phieunhap.maphieunhap = ctphieunhap.maphieunhap
                      WHERE phieunhap.thoigian < @timeStart
                      GROUP BY ctphieunhap.maphienbansp
                    ),
                    xuat_dau AS (
                      SELECT ctphieuxuat.maphienbansp, SUM(ctphieuxuat.soluong) AS sl_xuat_dau
                      FROM phieuxuat
                      JOIN ctphieuxuat ON phieuxuat.maphieuxuat = ctphieuxuat.maphieuxuat
                      WHERE phieuxuat.thoigian < @timeStart
                      GROUP BY ctphieuxuat.maphienbansp
                    ),
                    dau_ky AS (
                      SELECT
                        phienbansanpham.maphienbansp,
                        COALESCE(nhap_dau.sl_nhap_dau, 0) - COALESCE(xuat_dau.sl_xuat_dau, 0) AS soluongdauky
                      FROM phienbansanpham
                      LEFT JOIN nhap_dau ON phienbansanpham.maphienbansp = nhap_dau.maphienbansp
                      LEFT JOIN xuat_dau ON phienbansanpham.maphienbansp = xuat_dau.maphienbansp
                    ),
                    temp_table AS (
                      SELECT sanpham.masp, phienbansanpham.maphienbansp, sanpham.tensp, dau_ky.soluongdauky, 
                             COALESCE(nhap.sl_nhap, 0) AS soluongnhap, COALESCE(xuat.sl_xuat, 0) AS soluongxuat, 
                             (dau_ky.soluongdauky + COALESCE(nhap.sl_nhap, 0) - COALESCE(xuat.sl_xuat, 0)) AS soluongcuoiky,
                             kichthuocram, kichthuocrom, tenmau
                      FROM dau_ky
                      LEFT JOIN nhap ON dau_ky.maphienbansp = nhap.maphienbansp
                      LEFT JOIN xuat ON dau_ky.maphienbansp = xuat.maphienbansp
                      JOIN phienbansanpham ON phienbansanpham.maphienbansp = dau_ky.maphienbansp
                      JOIN sanpham ON phienbansanpham.masp = sanpham.masp
                      JOIN dungluongram ON phienbansanpham.ram = dungluongram.madlram
                      JOIN dungluongrom ON phienbansanpham.rom = dungluongrom.madlrom
                      JOIN mausac ON phienbansanpham.mausac = mausac.mamau
                    )
                    SELECT * FROM temp_table
                    WHERE tensp LIKE @text OR masp LIKE @text
                    ORDER BY masp;
                "
                    ;

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@timeStart", timeStart);
                        cmd.Parameters.AddWithValue("@timeEnd", timeEnd);
                        cmd.Parameters.AddWithValue("@text", "%" + filterText + "%");

                        con.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int masp = reader.GetInt32(reader.GetOrdinal("masp"));
                                int maphienbansp = reader.GetInt32(reader.GetOrdinal("maphienbansp"));
                                string tensp = reader.GetString(reader.GetOrdinal("tensp"));
                                int soluongdauky = reader.GetInt32(reader.GetOrdinal("soluongdauky"));
                                int soluongnhap = reader.GetInt32(reader.GetOrdinal("soluongnhap"));
                                int soluongxuat = reader.GetInt32(reader.GetOrdinal("soluongxuat"));
                                int soluongcuoiky = reader.GetInt32(reader.GetOrdinal("soluongcuoiky"));
                                int ram = reader.GetInt32(reader.GetOrdinal("kichthuocram"));
                                int rom = reader.GetInt32(reader.GetOrdinal("kichthuocrom"));
                                string mausac = reader.GetString(reader.GetOrdinal("tenmau"));

                                var dto = new ThongKeTonKhoDTO(masp, maphienbansp, tensp, ram, rom, mausac, soluongdauky, soluongnhap, soluongxuat, soluongcuoiky);
                                if (!result.ContainsKey(masp))
                                {
                                    result[masp] = new List<ThongKeTonKhoDTO>();
                                }
                                result[masp].Add(dto);
                            }
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
            }

            return result;
        }


        public List<ThongKeDoanhThuDTO> GetDoanhThuTheoTungNam(int yearStart, int yearEnd)
        {
            var result = new List<ThongKeDoanhThuDTO>();
            var phieuNhapList = new PhieuNhapDAO().GetAll();
            var phieuXuatList = new PhieuXuatDAO().GetAll();

            // Nhóm phiếu xuất theo năm và tính tổng doanh thu
            var doanhThuTheoNam = phieuXuatList
                .Where(px => px.Thoigian.Year >= yearStart && px.Thoigian.Year <= yearEnd)
                .GroupBy(px => px.Thoigian.Year)
                .Select(g => new ThongKeDoanhThuDTO
                {
                    Thoigian = g.Key,
                    Doanhthu = g.Sum(px => (long)px.Tongtien)
                }).ToList();

            // Nhóm phiếu nhập theo năm và tính tổng vốn
            var vonTheoNam = phieuNhapList
                .Where(pn => pn.Thoigian.Year >= yearStart && pn.Thoigian.Year <= yearEnd)
                .GroupBy(pn => pn.Thoigian.Year)
                .Select(g => new
                {
                    Thoigian = g.Key,
                    Von = g.Sum(pn => pn.Tongtien)
                }).ToList();

            // Kết hợp kết quả từ phiếu xuất và phiếu nhập
            foreach (var dt in doanhThuTheoNam)
            {
                // Lấy vốn tương ứng từ phiếu nhập
                var von = vonTheoNam.FirstOrDefault(v => v.Thoigian == dt.Thoigian);
                dt.Von = von != null ? von.Von : 0; // Gán vốn nếu có, nếu không thì gán 0
                dt.Loinhuan = dt.Doanhthu - dt.Von; // Tính lợi nhuận
                result.Add(dt);
            }

            // Thêm các năm không có doanh thu vào kết quả với doanh thu, vốn và lợi nhuận bằng 0
            for (int year = yearStart; year <= yearEnd; year++)
            {
                if (!result.Any(r => r.Thoigian == year))
                {
                    result.Add(new ThongKeDoanhThuDTO
                    {
                        Thoigian = year,
                        Doanhthu = 0,
                        Von = 0,
                        Loinhuan = 0
                    });
                }
            }

            return result;
        }


        public List<ThongKeTheoThangDTO> GetThongKeTheoThang(int nam)
        {
            var result = new List<ThongKeTheoThangDTO>();
            var phieuNhapList = new PhieuNhapDAO().GetAll();
            var phieuXuatList = new PhieuXuatDAO().GetAll();

            // Nhóm phiếu nhập theo tháng và tính tổng chi phí
            var chiphiTheoThang = phieuNhapList
                .Where(pn => pn.Thoigian.Year == nam)
                .GroupBy(pn => pn.Thoigian.Month)
                .Select(g => new ThongKeTheoThangDTO
                {
                    Thang = g.Key,
                    Chiphi = g.Sum(pn => (int)pn.Tongtien)
                }).ToList();

            // Nhóm phiếu xuất theo tháng và tính tổng doanh thu
            var doanhThuTheoThang = phieuXuatList
                .Where(px => px.Thoigian.Year == nam)
                .GroupBy(px => px.Thoigian.Month)
                .Select(g => new
                {
                    Thang = g.Key,
                    DoanhThuThang = g.Sum(px => px.Tongtien)
                }).ToList();

            // Kết hợp kết quả từ phiếu nhập và phiếu xuất
            foreach (var dt in chiphiTheoThang)
            {
                // Lấy doanh thu tương ứng từ phiếu xuất
                var doanhThu = doanhThuTheoThang.FirstOrDefault(d => d.Thang == dt.Thang);

                // Tạo đối tượng ThongKeTheoThangDTO cho tháng này
                var thongKeThang = new ThongKeTheoThangDTO
                {
                    Thang = dt.Thang,
                    Chiphi = dt.Chiphi,
                    DoanhthuThang = (int)(doanhThu != null ? doanhThu.DoanhThuThang : 0), // Gán doanh thu nếu có
                    LoinhuanThang = (int)((doanhThu != null ? doanhThu.DoanhThuThang : 0) - dt.Chiphi) // Tính lợi nhuận
                };

                result.Add(thongKeThang);
            }

            // Thêm các tháng không có dữ liệu vào kết quả 
            for (int thang = 1; thang <= 12; thang++)
            {
                if (!result.Any(r => r.Thang == thang))
                {
                    result.Add(new ThongKeTheoThangDTO
                    {
                        Thang = thang,
                        Chiphi = 0,
                        DoanhthuThang = 0,
                        LoinhuanThang = 0
                    });
                }
            }

            return result;
        }

        public List<ThongKeTungNgayTrongThangDTO> GetThongKeTungNgayTrongThang(int thang, int nam)
        {
            var result = new List<ThongKeTungNgayTrongThangDTO>();

            // Lấy dữ liệu phiếu nhập và phiếu xuất
            var phieuNhapList = new PhieuNhapDAO().GetAll();
            var phieuXuatList = new PhieuXuatDAO().GetAll();

            // Xác định số ngày trong tháng
            var daysInMonth = DateTime.DaysInMonth(nam, thang);

            // Lặp qua từng ngày trong tháng
            for (int day = 1; day <= daysInMonth; day++)
            {
                var currentDate = new DateTime(nam, thang, day);

             
                var chiphiNgay = phieuNhapList
                    .Where(pn => pn.Thoigian.Date == currentDate.Date)
                    .Sum(pn => pn.Tongtien);

               
                var doanhThuNgay = phieuXuatList
                    .Where(px => px.Thoigian.Date == currentDate.Date)
                    .Sum(px => px.Tongtien);

                // Tạo đối tượng DTO cho ngày này
                var thongKeNgay = new ThongKeTungNgayTrongThangDTO
                {
                    Ngay = currentDate,
                    Chiphi = (int)chiphiNgay,
                    DoanhthuNgay = (int)doanhThuNgay,
                    LoinhuanNgay = (int)(doanhThuNgay - chiphiNgay) // Tính lợi nhuận
                };

                // Thêm vào kết quả
                result.Add(thongKeNgay);
            }

            return result;
        }


        public List<ThongKeTungNgayTrongThangDTO> GetThongKeTuNgayDenNgay(string start, string end)
        {
            var result = new List<ThongKeTungNgayTrongThangDTO>();

            // Chuyển đổi chuỗi ngày tháng thành DateTime
            if (!DateTime.TryParse(start, out DateTime startDate) || !DateTime.TryParse(end, out DateTime endDate))
            {
                throw new ArgumentException("Ngày bắt đầu hoặc ngày kết thúc không hợp lệ.");
            }

            // Lấy dữ liệu phiếu nhập và phiếu xuất
            var phieuNhapList = new PhieuNhapDAO().GetAll();
            var phieuXuatList = new PhieuXuatDAO().GetAll();

            // Lặp qua từng ngày trong khoảng thời gian
            for (var date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
            {
                // Tính tổng doanh thu trong ngày
                var doanhThuNgay = phieuXuatList
                    .Where(px => px.Thoigian.Date == date.Date)
                    .Sum(px => px.Tongtien);

                // Tính tổng chi phí trong ngày
                var chiPhiNgay = phieuNhapList
                    .Where(pn => pn.Thoigian.Date == date.Date)
                    .Sum(pn => pn.Tongtien);

                // Tính lợi nhuận trong ngày
                var loiNhuanNgay = doanhThuNgay - chiPhiNgay;

                // Tạo đối tượng DTO cho ngày này
                var thongKeNgay = new ThongKeTungNgayTrongThangDTO
                {
                    Ngay = date, // Gán ngày
                    Chiphi = (int)chiPhiNgay, // Gán tổng chi phí
                    DoanhthuNgay = (int)doanhThuNgay, // Gán tổng doanh thu
                    LoinhuanNgay = (int)loiNhuanNgay // Gán lợi nhuận
                };

                // Thêm vào kết quả
                result.Add(thongKeNgay);
            }

            return result;
        }



        public List<ThongKeTungNgayTrongThangDTO> GetThongKe7NgayGanNhat()
        {
            var result = new List<ThongKeTungNgayTrongThangDTO>();

            // Lấy dữ liệu phiếu nhập và phiếu xuất
            var phieuNhapList = new PhieuNhapDAO().GetAll();
            var phieuXuatList = new PhieuXuatDAO().GetAll();

            // Lặp qua 7 ngày gần nhất
            for (int i = 0; i < 7; i++)
            {
                var date = DateTime.Now.AddDays(-i); // Ngày hiện tại trừ i ngày

                // Tính tổng doanh thu trong ngày
                var doanhThuNgay = phieuXuatList
                    .Where(px => px.Thoigian.Date == date.Date)
                    .Sum(px => px.Tongtien);

                // Tính tổng chi phí trong ngày
                var chiPhiNgay = phieuNhapList
                    .Where(pn => pn.Thoigian.Date == date.Date)
                    .Sum(pn => pn.Tongtien);

                // Tính lợi nhuận trong ngày
                var loiNhuanNgay = doanhThuNgay - chiPhiNgay;

                // Tạo đối tượng DTO cho ngày này
                var thongKeNgay = new ThongKeTungNgayTrongThangDTO
                {
                    Ngay = date, // Gán ngày
                    Chiphi = (int)chiPhiNgay, // Gán tổng chi phí
                    DoanhthuNgay = (int)doanhThuNgay, // Gán tổng doanh thu
                    LoinhuanNgay = (int)loiNhuanNgay // Gán lợi nhuận
                };

                // Thêm vào kết quả
                result.Add(thongKeNgay);
            }

            return result;
        }
    }
}