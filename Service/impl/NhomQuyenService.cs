using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    internal class NhomQuyenService : INhomQuyenService
    {
        private List<NhomQuyen> _nhomquyen = new List<NhomQuyen>();
        private Dictionary<string, List<ChiTietQuyen>> _chitietquyen = new Dictionary<string, List<ChiTietQuyen>>();
        public List<NhomQuyen> GetAll()
        {
            return _nhomquyen;
        }

        public NhomQuyen GetByIndex(int index)
        {
            if (index >= 0 && index < _nhomquyen.Count)
            {
                return _nhomquyen[index];
            }
            else
            {
                throw new IndexOutOfRangeException("error");
            }
        }

        public bool Add(string tennhomquyen, List<ChiTietQuyen> ctquyen)
        {
            if (!string.IsNullOrEmpty(tennhomquyen) && ctquyen != null)
            {
                int newMaNhomQuyen = (_nhomquyen.Count + 1);
                NhomQuyen newNhomQuyen = new NhomQuyen { Manhomquyen = newMaNhomQuyen, Tennhomquyen = tennhomquyen };
                _nhomquyen.Add(newNhomQuyen);
                _chitietquyen.Add(newMaNhomQuyen.ToString(), ctquyen);
                return true;
            }
            return false;
        }

        public bool Update(NhomQuyen nhomquyen, List<ChiTietQuyen> chitietquyen, int index)
        {   
            if (index >= 0 &&  index < _nhomquyen.Count)
            {
                _nhomquyen[index] = nhomquyen;
                _chitietquyen[nhomquyen.Manhomquyen.ToString()] = chitietquyen;
                return true;
            }
            return false;
        }

        public bool Delete(NhomQuyen nhomquyen)
        {
            if (_nhomquyen.Remove(nhomquyen))
            {
                _chitietquyen.Remove(nhomquyen.Manhomquyen.ToString());
                return true;
            }
            return false;
        }

        public List<ChiTietQuyen> GetChiTietQuyen(string manhomquyen)
        {
            if (_chitietquyen.ContainsKey(manhomquyen))
            {
                return _chitietquyen[manhomquyen];
            }
            return null;
        }

        public bool AddChiTietQuyen(List<ChiTietQuyen> listctquyen)
        {
            if(listctquyen != null && listctquyen.Count > 0)
            {
                string maNhomQuyen = listctquyen[0].MaNhomQuyen.ToString();
                if (_chitietquyen.ContainsKey(maNhomQuyen))
                {
                    _chitietquyen[maNhomQuyen].AddRange(listctquyen);
                    return true;
                }
            }
            return false;
            //throw new NotImplementedException();
        }

        public bool RemoveChiTietQuyen(string manhomquyen)
        {
            if (_chitietquyen.ContainsKey(manhomquyen))
            {
                _chitietquyen.Remove(manhomquyen);
                return true;
            }
            return false;
            //throw new NotImplementedException();
        }

        public bool CheckPermission(int maquyen, string chucnang, string hanhdong)
        {
            foreach (var k in _chitietquyen)
            {
                if (k.Value.Any(q => q.MaNhomQuyen == maquyen && q.MaChucNang == chucnang && q.HanhDong == hanhdong))
                {
                    return true;
                }
            }
            return false;
            //throw new NotImplementedException();
        }

        public List<NhomQuyen> Search(string text)
        {
            return _nhomquyen.Where(nq => nq.Tennhomquyen.Contains(text)).ToList();
            //throw new NotImplementedException();
        }
    }
}
