using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BUS
{
    public class NhanVien_BUS
    {
        NhanVien_DAL nhanVien_DAL = new NhanVien_DAL();
        public DataTable loadNhanVien()
        {
            return nhanVien_DAL.Load();
        }
        public void InsertNhanVien(NhanVien ob)
        {
            nhanVien_DAL.InsertNhanVien(ob);
        }
        public void DeleteNhanVien(string manv)
        {
            nhanVien_DAL.DeleteNhanVien(manv);
        }

        public void UpdateNhanVien(string manv, NhanVien ob)
        {
            nhanVien_DAL.UpdateNhanVien(manv, ob);
        }

        public Dictionary<string, string> getNhanVien()
        {
            return nhanVien_DAL.getNhanVien();
        }

        public DataTable FindNhanVien(string tuKhoa)
        { 
            return nhanVien_DAL.FindNhanVien(tuKhoa);

        }
    }
}
