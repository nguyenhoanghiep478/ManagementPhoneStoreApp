using DAO.DAO.impl;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Service.impl
{
    public class NhomQuyenService : INhomQuyenService
    {
        private List<NhomQuyen> _nhomquyen = new List<NhomQuyen>();
        private DanhMucChucNangDAO danhMucChucNangDAO = new DanhMucChucNangDAO();
        private static readonly Lazy<NhomQuyenService> instance = new Lazy<NhomQuyenService>(() => new NhomQuyenService());
        public static NhomQuyenService Instace => instance.Value; 
        private  ChiTietQuyenDAO ChiTietQuyenDAO = new ChiTietQuyenDAO();
        private NhomQuyenDAO NhomQuyenDAO = new NhomQuyenDAO();
        private Dictionary<string, List<ChiTietQuyen>> _chitietquyen = new Dictionary<string, List<ChiTietQuyen>>();
        
      
        public List<NhomQuyen> GetAll()
        {
            return _nhomquyen;
        }
        public NhomQuyenService()
        {
            _nhomquyen = new NhomQuyenDAO().GetAll();
            List<ChiTietQuyen> allChiTietQuyen = ChiTietQuyenDAO.getAll();
            if (_chitietquyen.Count < 1)
            {
                foreach (var nhomquyen in _nhomquyen)
                {
                    List<ChiTietQuyen> quyenCuaNhomQuyen = allChiTietQuyen.Where(ctquyen => ctquyen.MaNhomQuyen.Equals(nhomquyen.Manhomquyen)).ToList();
                    _chitietquyen.Add(nhomquyen.Tennhomquyen, quyenCuaNhomQuyen);
                }
            }
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
        public String getNameByMA(int id)
        {
          return   _nhomquyen.Where(nq => nq.Manhomquyen.Equals(id)).First().Tennhomquyen;
        }
        public bool Add(string tennhomquyen, List<ChiTietQuyen> ctquyen)
        {
            if (!string.IsNullOrEmpty(tennhomquyen) && ctquyen != null)
            {
                NhomQuyen nhomQuyen = new NhomQuyen();
                nhomQuyen.Manhomquyen = getIncreasementId();
                nhomQuyen.Tennhomquyen = tennhomquyen;
                nhomQuyen.Trangthai = 1;
                this.NhomQuyenDAO.insert(nhomQuyen);
                AddChiTietQuyen(ctquyen);
                this._nhomquyen.Add(nhomQuyen);
                return true;
            }
            return false;
        }

        public bool Update(NhomQuyen nhomquyen, List<ChiTietQuyen> chitietquyen, int index, string newName)
        {
          
            NhomQuyen nhomQuyenOld = _nhomquyen[index];
            handleUpdateChiTietQuyenForNhomQuyen(nhomQuyenOld, chitietquyen);
            List<ChiTietQuyen> ctQuyen = _chitietquyen[nhomquyen.Tennhomquyen];
            _chitietquyen.Remove(nhomquyen.Tennhomquyen);
            _chitietquyen.Add(newName, ctQuyen);

            nhomquyen.Tennhomquyen = newName;
            this.NhomQuyenDAO.update(nhomquyen);
            if (index >= 0 &&  index < _nhomquyen.Count)
            {
                _nhomquyen[index] = nhomquyen;
                if (chitietquyen != null)
                {
                   
                    _chitietquyen[nhomquyen.Manhomquyen.ToString()] = chitietquyen;
                }
                return true;
            }
          
            return false;
        }

        public void handleUpdateChiTietQuyenForNhomQuyen(NhomQuyen nhomQuyen,List<ChiTietQuyen> chiTietQuyens)
        {
            List<ChiTietQuyen> currentQuyen = _chitietquyen[nhomQuyen.Tennhomquyen];
           
            handleUpdateCtQuyenInNhomQuyen(currentQuyen, chiTietQuyens,nhomQuyen.Tennhomquyen);
        }

        private void handleUpdateCtQuyenInNhomQuyen(List<ChiTietQuyen> currentQuyen , List<ChiTietQuyen> updatedQuyen,String tenNhomQuyen)
        {
            if(updatedQuyen.Count == 0)
            {
                removeChiTietQuyen(currentQuyen, tenNhomQuyen);
            }
            else 
            {
                List<ChiTietQuyen> removed = new List<ChiTietQuyen>();
                foreach (var ct in currentQuyen)
                {
                    if(!updatedQuyen.Any(uct => uct.Equals(ct))){
                        removed.Add(ct);
                    }
                
                }
            
                if(removed.Count > 0)
                {
                    removeChiTietQuyen(removed, tenNhomQuyen);
                }

                List<ChiTietQuyen> added = updatedQuyen.Where( ct => !currentQuyen.Contains(ct)).ToList();
                if(added.Count > 0)
                {
                    AddChiTietQuyen(added);
                }

            }
        }

        public bool Delete(NhomQuyen nhomquyen)
        {
            this.NhomQuyenDAO.delete((int)nhomquyen.Manhomquyen);
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
            foreach (var chitietquen in listctquyen)
            {
               this.ChiTietQuyenDAO.insert(chitietquen);
            }
            if(listctquyen != null && listctquyen.Count > 0)
            {
                int maNhomQuyen = listctquyen[0].MaNhomQuyen;
                int index = getIndexByMaNhomQuyen(maNhomQuyen);
                string tenNhomQuyen = GetByIndex(index).Tennhomquyen;

                if (_chitietquyen.ContainsKey(tenNhomQuyen))
                {
                    _chitietquyen[tenNhomQuyen].AddRange(listctquyen);
                    return true;
                }
                else
                {
                    _chitietquyen.Add(tenNhomQuyen, listctquyen);
                }

                return true;
            }
            return false;
            //throw new NotImplementedException();
        }

        private void removeChiTietQuyen(List<ChiTietQuyen> chiTietQuyens,string tenNhomQuyen)
        {
            List<ChiTietQuyen> inList = _chitietquyen[tenNhomQuyen];
            foreach (var ctquyen in chiTietQuyens)
            {
                ChiTietQuyenDAO.delete(ctquyen);
               inList.Remove(ctquyen);
            }
            _chitietquyen.Remove(tenNhomQuyen);
            _chitietquyen.Add(tenNhomQuyen, inList);
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

        public List<NhomQuyen> Search(string type,string text)
        {
            if (type.Equals("manhomquyen"))
            {
                try
                {
                    return _nhomquyen.Where(nq => nq.Manhomquyen.Equals(int.Parse(text))).ToList();
                }
                catch (Exception ex)
                {
                  
                }
                return null;
            }
            else
            {
                return _nhomquyen.Where(nq => nq.Tennhomquyen.ToLower().Contains(text.ToLower())).ToList();
            }
            
            //throw new NotImplementedException();
        }

        List<DanhMucChucNang> INhomQuyenService.getAllDanhMucChucNang()
        {
            return this.danhMucChucNangDAO.getAll();
        }

        public bool checkDup(string tenNhomQuyen)
        {
            return this._nhomquyen.Any(nq => nq.Tennhomquyen.Equals(tenNhomQuyen));
        }

        public int getIncreasementId()
        {
            return this._nhomquyen.Count+1;
        }

        public int getIndexByMaNhomQuyen(int maNhomQuyen)
        {
           return this._nhomquyen.FindIndex(nq => nq.Manhomquyen.Equals(maNhomQuyen));
        }
    }
}
