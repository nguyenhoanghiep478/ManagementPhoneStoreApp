using DAO.DAO;
using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class TaiKhoanService : ITaiKhoanService
    {
        private List<TaiKhoan> _taikhoans = new List<TaiKhoan>();
        private List<NhomQuyen> _nhomquyen = new List<NhomQuyen>();
        private ITaiKhoanDao _taiKhoanDAO = new TaiKhoanDAO();
        private INhomQuyenDAO _nhomQuyenDAO = new NhomQuyenDAO();
        public static Lazy<TaiKhoanService> instance = new Lazy<TaiKhoanService>(() => new TaiKhoanService());

        public static TaiKhoanService Instance { get { return instance.Value; } }

        public TaiKhoanService()
        {
            this._taikhoans = _taiKhoanDAO.GetAll().Where(tk => tk.Trangthai.Equals(1)).ToList();
            _nhomquyen=_nhomQuyenDAO.GetAll();
        }
        public TaiKhoan getByIndex(int index)
        {
            if (index >= 0 && index <_taikhoans.Count)
            {
                return _taikhoans[index];
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
                tk.Matkhau = PasswordHelper.HashPassword(tk.Matkhau);      
                _taiKhoanDAO.insert(tk);
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
                _taiKhoanDAO.update(tk);
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
                _taiKhoanDAO.delete(manv);
                _taikhoans.Remove(taikhoan);
            }
            else
            {
                throw new Exception("Error");
            }
        }
        
        public List<TaiKhoan> Search(string txt, string type)
        {
            txt = txt.ToLower();
            if (type.Equals("Tất cả") )
            {
                return _taikhoans.Where(tk => tk.Manv.ToString().Equals(txt)
                || tk.Tendangnhap.ToLower().Contains(txt)).ToList();
            }
            else if (type.Equals("Tên đăng nhập"))
            {
                return _taikhoans.Where(tk => tk.Tendangnhap.ToLower().Contains(txt)).ToList();
            }
            else if (type.Equals("Mã nhân viên"))
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
        public List<TaiKhoan> getTaiKhoanAllStatus()
        {
            return _taiKhoanDAO.GetAll();
        }
        public List<TaiKhoan> GetTaiKhoanAll()
        {
          return this._taikhoans;
        }

        public TaiKhoan GetTaiKhoan(int index)
        {
            return this._taikhoans[index];
        }

        public int GetTaiKhoanByMaNV(int manv)
        {
           for(int i = 0;i < _taikhoans.Count; i++)
            {
                if (_taikhoans[i].Manv == manv)
                {
                    return i;
                }
            };
            return 0;
        }
    }
}