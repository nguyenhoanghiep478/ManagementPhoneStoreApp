using Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    internal class NhanVienService : INhanVienService
    {
        private List<NhanVien> _nhanVien = new List<NhanVien>();

        public List<NhanVien> GetAll()
        {
            return _nhanVien;
        }

        public NhanVien GetByIndex(int index)
        {
            if (index != 0 && index < _nhanVien.Count)
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

        public void InsertNv(NhanVien nv)
        {
            if (nv != null && !_nhanVien.Any(n => n.Manv == nv.Manv))
            {
                _nhanVien.Add(nv);
            }
            else
            {
                throw new Exception("Error");
            }
        }
        public void UpdateNv(int index, NhanVien nv)
        {
            if (index >= 0 && index < _nhanVien.Count)
            {
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
                
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public List<NhanVien> Search(string text, string filterType)
        {
            switch (filterType.ToLower())
            {
                case "Hoten":
                    return _nhanVien.Where(nv => nv.Hoten.Contains(text)).ToList();
                case "Manv":
                    if (int.TryParse(text, out int manv))
                    {
                        return _nhanVien.Where(nv => nv.Manv == manv).ToList();
                    }
                    else
                    {
                        throw new Exception("error");
                    }
                default:
                    throw new Exception("Error");
            }
        }

        public void ExportToExcel(List<NhanVien> list, string[] headers, string filePath)
        {

        }

        public void ImportFromExcel(string filePath)
        {

        }

    }
}
