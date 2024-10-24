using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private List<TaiKhoan> _taikhoans = new List<TaiKhoan>();
        private List<NhomQuyen> _nhomquyen = new List<NhomQuyen>();

        public List<TaiKhoan> GetTaiKhoanAll()
        {
            return _taikhoans;
        }

        public TaiKhoan GetTaiKhoan(int index)
        {
            if (index >= 0 &&  index < _taikhoans.Count)
            {
                return _taikhoans[index];
            }
            else
            {
                throw new IndexOutOfRangeException("Error");
            }
        }

        public int GetTaiKhoanByMaNV(int manv)
        {
            var taikhoan = _taikhoans.FirstOrDefault(tk  => tk.Manv == manv);
            if (taikhoan != null)
            {
                return taikhoan.Manv;
            }
            else
            {
                throw new IndexOutOfRangeException("Error");
            }
        }

        public NhomQuyen GetNhomQuyen(int manhom)
        {
            var nhomquyen = _nhomquyen.FirstOrDefault(nq => nq.Manhomquyen == manhom);
            if (nhomquyen != null)
            {
                return nhomquyen;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public void AddAcc(TaiKhoan tk)
        {
            if (tk != null && !_taikhoans.Any(x => x.Manv == tk.Manv))
            {
                _taikhoans.Add(tk);
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public void UpdateAcc(int index, TaiKhoan tk)
        {
            if (index >= 0 &&  index < _taikhoans.Count)
            {
                _taikhoans[index] = tk;
            }
            else
            {
                throw new Exception("Error");
            }
        }

        public void DeleteAcc(int manv)
        {
            var taikhoan = _taikhoans.FirstOrDefault(tk => tk.Manv == manv);
            if (taikhoan != null)
            {
                _taikhoans.Remove(taikhoan);
            }
            else
            {
                throw new Exception("Error");
            }
        }
        
        public List<TaiKhoan> Search(string txt, string type)
        {
            if(type == "Tendangnhap")
            {
                return _taikhoans.Where(tk => tk.Tendangnhap.Contains(txt)).ToList();
            }
            else if(type == "Manv")
            {
                if (int.TryParse(txt, out int maNV))
                {
                    return _taikhoans.Where(Tk => Tk.Manv == maNV).ToList();
                }
                else
                {
                    throw new Exception("Error");
                }
            }
            else
            {
                throw new Exception("Error");
            }
        }
    }
}