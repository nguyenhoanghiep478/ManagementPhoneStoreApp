using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface INhanVienService
    {
        List<NhanVien> GetAll();
        NhanVien GetByIndex(int index);
        int GetIndexById(int manv);
        string GetNameById(int manv);
        string[] GetArrTenNhanVien();
        void InsertNv(NhanVien nv);
        void UpdateNv(int index, NhanVien nv);
        void DeleteNv(NhanVien nv);
        List<NhanVien> Search(string text, string filterType);
        void ExportToExcel(List<NhanVien> list, string[] headers, string filePath);
        void ImportFromExcel(string filePath);
    }
}
