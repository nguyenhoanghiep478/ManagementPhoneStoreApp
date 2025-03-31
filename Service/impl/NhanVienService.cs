using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class NhanVienService : INhanVienService
    {
        private List<NhanVien> _nhanVien = new NhanVienDAO().GetAll().Where(nv=>nv.Trangthai.Equals(1)).ToList();
        private readonly INhanVienDAO nvDAO = new NhanVienDAO();
        private static Lazy<NhanVienService> instace = new Lazy<NhanVienService>(()=> new NhanVienService());
        public static NhanVienService Instance => instace.Value;
        public List<NhanVien> GetAll()
        {
            return _nhanVien;
        }

        public NhanVien GetByIndex(int index)
        {
            if (index >=0 && index < _nhanVien.Count)
            {
                return _nhanVien[index];
            }
            else
            {
                throw new IndexOutOfRangeException("error");
            }
        }

        public int GetIndexById(int manv)
        {
            var nv = _nhanVien.FirstOrDefault(n => n.Manv == manv);
            if (nv != null)
            {
                return _nhanVien.IndexOf(nv);
            }
            throw new Exception("Error");
        }

        public string GetNameById(int manv)
        {
            var nv = _nhanVien.FirstOrDefault(n => n.Manv == manv);
            if(nv != null)
            {
                return nv.Hoten;
            }
            throw new Exception("Error");
        }
        public string[] GetArrTenNhanVien()
        {
            return _nhanVien.Select(n => n.Hoten).ToArray();
        }

        public bool checkDup(string name)
        {
            return nvDAO.GetAll().Any(nv=>nv.Hoten.Equals(name));
        }
        public void InsertNv(NhanVien nv)
        {
            long i= nvDAO.insert(nv);
            nv.Manv = (int)i;
            _nhanVien.Add(nv);
            //if (nv != null && !_nhanVien.Any(n => n.Manv == nv.Manv))
            //{
             
            //}
            //else
            //{
            //    throw new Exception("Error");
            //}
        }
        public void UpdateNv(int index, NhanVien nv)
        {
            if (index >= 0 && index < _nhanVien.Count)
            {
                nvDAO.update(nv);
                _nhanVien[index] = nv;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public void DeleteNv(NhanVien nhanvien)
        {
            if (_nhanVien.Remove(nhanvien))
            {
                nvDAO.delete((long)nhanvien.Manv);
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public List<NhanVien> Search(string filter, string field)
        {
            filter = filter.ToLower();
            switch (field)
            {
                case "Tất cả":
                    return _nhanVien.Where(nv =>
                    nv.Manv.ToString().Equals(filter) ||  // Tìm theo Mã nhân viên
                    nv.Hoten.ToLower().Contains(filter) ||  // Tìm theo Họ tên
                    nv.Sdt.Contains(filter) ||  // Tìm theo Số điện thoại
                    nv.Email.ToLower().Contains(filter) ||  // Tìm theo Email
                    (nv.Giotinh.ToString().Equals(filter) ||  // Tìm theo Giới tính (nếu filter là 0, 1, 2...)
                    (DateTime.TryParse(filter, out DateTime ngaySinh1) && ngaySinh1.ToString("yyyy-MM-dd").Equals(filter)))
                    ).ToList();
                    break;
                case "Mã nhân viên":
                    if (int.TryParse(filter, out int manhanvien))
                    {
                        return _nhanVien.Where(nv => nv.Manv == manhanvien).ToList();
                    }
                    break;

                case "Họ tên":
                    return _nhanVien.Where(nv => nv.Hoten.ToLower().Contains(filter)).ToList();
                case "Giới tính":
                    if (int.TryParse(filter, out int gioiTinh) && (gioiTinh == 0 || gioiTinh == 1))
                    {
                        return _nhanVien.Where(nv => nv.Giotinh == gioiTinh).ToList();
                    }
                    else
                    {
                        throw new Exception("Giới tính không hợp lệ. Vui lòng nhập 0 Nữ hoặc 1 Nam.");
                    }
                case "Ngày sinh":
                    if (DateTime.TryParse(filter, out DateTime ngaySinh))
                    {
                        return _nhanVien.Where(nv => nv.Ngaysinh.Date== ngaySinh.Date).ToList();
                    }
                    break;

                case "Số điện thoại":
                    return _nhanVien.Where(nv => nv.Sdt.Contains(filter)).ToList();

                case "Email":
                    return _nhanVien.Where(nv => nv.Email.ToLower().Contains(filter)).ToList();

                default:
                    throw new Exception("Error");

            }
            return new List<NhanVien>();
        }

        public void ExportToExcel(List<NhanVien> list, string[] headers, string filePath)
        {

        }

        public void ImportFromExcel(string filePath)
        {

        }

        
    }
}
