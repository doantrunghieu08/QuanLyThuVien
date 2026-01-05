using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class NhanVien_DAL:Connect
    {
        public DataTable Load()
        {
            return loadData("SELECT MaNhanVien_HieuDT_3725_LTMT5, TenNhanVien_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5, DiaChi_HieuDT_3725_LTMT5\r\nFROM     NhanVien_HieuDT_3725_LTMT5");

        }

        public void InsertNhanVien(NhanVien ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO NhanVien_HieuDT_3725_LTMT5
                  (MaNhanVien_HieuDT_3725_LTMT5, TenNhanVien_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5, DiaChi_HieuDT_3725_LTMT5)
VALUES (@MaNhanVien_HieuDT_3725_LTMT5,@TenNhanVien_HieuDT_3725_LTMT5,@SoDienThoai_HieuDT_3725_LTMT5,@Email_HieuDT_3725_LTMT5,@DiaChi_HieuDT_3725_LTMT5)");

            cmd.Parameters.AddWithValue(@"MaNhanVien_HieuDT_3725_LTMT5", ob.ID);
            cmd.Parameters.AddWithValue(@"TenNhanVien_HieuDT_3725_LTMT5", ob.Name);
            cmd.Parameters.AddWithValue(@"SoDienThoai_HieuDT_3725_LTMT5", ob.SDT);
            cmd.Parameters.AddWithValue(@"Email_HieuDT_3725_LTMT5", ob.email);
            cmd.Parameters.AddWithValue(@"DiaChi_HieuDT_3725_LTMT5", ob.diaChi);
            ExcuteNonQuery(cmd);
        }

        public void DeleteNhanVien(string manv)
        {
            SqlCommand cmd = new SqlCommand(@"
                DELETE FROM NhanVien_HieuDT_3725_LTMT5
WHERE  (MaNhanVien_HieuDT_3725_LTMT5 = @Original_MaNhanVien_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue(@"Original_MaNhanVien_HieuDT_3725_LTMT5", manv);
            ExcuteNonQuery(cmd);
        }

        public void UpdateNhanVien(string manv, NhanVien ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                UPDATE NhanVien_HieuDT_3725_LTMT5
SET          TenNhanVien_HieuDT_3725_LTMT5 = @TenNhanVien_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5 = @SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5 = @Email_HieuDT_3725_LTMT5, 
                  DiaChi_HieuDT_3725_LTMT5 = @DiaChi_HieuDT_3725_LTMT5
WHERE  (MaNhanVien_HieuDT_3725_LTMT5 = @Original_MaNhanVien_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue(@"TenNhanVien_HieuDT_3725_LTMT5", ob.Name);
            cmd.Parameters.AddWithValue(@"SoDienThoai_HieuDT_3725_LTMT5", ob.SDT);
            cmd.Parameters.AddWithValue(@"Email_HieuDT_3725_LTMT5", ob.email);
            cmd.Parameters.AddWithValue(@"DiaChi_HieuDT_3725_LTMT5", ob.diaChi);

            cmd.Parameters.AddWithValue(@"Original_MaNhanVien_HieuDT_3725_LTMT5", manv);
            ExcuteNonQuery(cmd);
        }

        public Dictionary<string, string> getNhanVien()
        {
            Dictionary<string, string> mapNhanVien = new Dictionary<string, string>();

            DataTable dt = loadData(@"SELECT MaNhanVien_HieuDT_3725_LTMT5, TenNhanVien_HieuDT_3725_LTMT5
FROM     NhanVien_HieuDT_3725_LTMT5");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string maNhanVien = row["MaNhanVien_HieuDT_3725_LTMT5"].ToString();
                    String tenNhanVien = row["TenNhanVien_HieuDT_3725_LTMT5"].ToString();

                    if (!mapNhanVien.ContainsKey(maNhanVien))
                    {
                        mapNhanVien.Add(maNhanVien, tenNhanVien);
                    }
                }
            }
            return mapNhanVien;

        }

        public DataTable FindNhanVien(string tuKhoa)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT 
    MaNhanVien_HieuDT_3725_LTMT5, 
    TenNhanVien_HieuDT_3725_LTMT5, 
    SoDienThoai_HieuDT_3725_LTMT5, 
    Email_HieuDT_3725_LTMT5, 
    DiaChi_HieuDT_3725_LTMT5
FROM 
    NhanVien_HieuDT_3725_LTMT5
WHERE 
    (
       
        MaNhanVien_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
      
        OR TenNhanVien_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
        OR SoDienThoai_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
       
        OR Email_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
      
        OR DiaChi_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
    )");
            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
            return loadDataByParameter(cmd);
        }
    }
}
