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
    public class DocGia_DAL:Connect
    {
        public DataTable load()
        {
            return loadData(@"SELECT MaDocGia_HieuDT_3725_LTMT5, TenDocGia_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5, DiaChi_HieuDT_3725_LTMT5
FROM     DocGia_HieuDT_3725_LTMT5");
        }

        public void InsertDocGia(DocGia ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO DocGia_HieuDT_3725_LTMT5
                  (MaDocGia_HieuDT_3725_LTMT5 ,TenDocGia_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5, DiaChi_HieuDT_3725_LTMT5)
VALUES (@MaDocGia_HieuDT_3725_LTMT5 ,@TenDocGia_HieuDT_3725_LTMT5,@SoDienThoai_HieuDT_3725_LTMT5,@Email_HieuDT_3725_LTMT5,@DiaChi_HieuDT_3725_LTMT5)
                
            ");
            cmd.Parameters.AddWithValue("@MaDocGia_HieuDT_3725_LTMT5", ob.ID);
            cmd.Parameters.AddWithValue("@TenDocGia_HieuDT_3725_LTMT5", ob.Name);
            cmd.Parameters.AddWithValue("@SoDienThoai_HieuDT_3725_LTMT5", ob.SDT);
            cmd.Parameters.AddWithValue("@Email_HieuDT_3725_LTMT5", ob.email);
            cmd.Parameters.AddWithValue("@DiaChi_HieuDT_3725_LTMT5", ob.diaChi);
            ExcuteNonQuery(cmd);
        }

        public void DeleteDocGia(string maDocGia)
        {
            SqlCommand cmd = new SqlCommand(@"
                 DELETE FROM DocGia_HieuDT_3725_LTMT5
WHERE  (MaDocGia_HieuDT_3725_LTMT5 = @Original_MaDocGia_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue("@Original_MaDocGia_HieuDT_3725_LTMT5", maDocGia);
            ExcuteNonQuery(cmd) ;
        }

        public void UpdateDocGia(string maDocGia, DocGia ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                UPDATE DocGia_HieuDT_3725_LTMT5
SET          TenDocGia_HieuDT_3725_LTMT5 = @TenDocGia_HieuDT_3725_LTMT5, SoDienThoai_HieuDT_3725_LTMT5 = @SoDienThoai_HieuDT_3725_LTMT5, Email_HieuDT_3725_LTMT5 = @Email_HieuDT_3725_LTMT5, 
                  DiaChi_HieuDT_3725_LTMT5 = @DiaChi_HieuDT_3725_LTMT5
WHERE  (MaDocGia_HieuDT_3725_LTMT5 = @Original_MaDocGia_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue("@TenDocGia_HieuDT_3725_LTMT5", ob.Name);
            cmd.Parameters.AddWithValue("@SoDienThoai_HieuDT_3725_LTMT5", ob.SDT);
            cmd.Parameters.AddWithValue("@Email_HieuDT_3725_LTMT5", ob.email);
            cmd.Parameters.AddWithValue("@DiaChi_HieuDT_3725_LTMT5", ob.diaChi);
            cmd.Parameters.AddWithValue("@Original_MaDocGia_HieuDT_3725_LTMT5", maDocGia);
            ExcuteNonQuery(cmd);
        }
        public Dictionary<string, string> getDocGia()
        {
            Dictionary<string, string> mapDocGia = new Dictionary<string, string>();

            DataTable dt = loadData(@"SELECT MaDocGia_HieuDT_3725_LTMT5, TenDocGia_HieuDT_3725_LTMT5
FROM     DocGia_HieuDT_3725_LTMT5");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string maNhanVien = row["MaDocGia_HieuDT_3725_LTMT5"].ToString();
                    String tenNhanVien = row["TenDocGia_HieuDT_3725_LTMT5"].ToString();

                    if (!mapDocGia.ContainsKey(maNhanVien))
                    {
                        mapDocGia.Add(maNhanVien, tenNhanVien);
                    }
                }
            }
            return mapDocGia;

        }

        public DataTable FindDocGia(string tuKhoa)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT 
    MaDocGia_HieuDT_3725_LTMT5, 
    TenDocGia_HieuDT_3725_LTMT5, 
    SoDienThoai_HieuDT_3725_LTMT5, 
    Email_HieuDT_3725_LTMT5, 
    DiaChi_HieuDT_3725_LTMT5
FROM 
    DocGia_HieuDT_3725_LTMT5
WHERE 
    (
        
        MaDocGia_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
        
        OR TenDocGia_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
       
        OR SoDienThoai_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
    
        OR Email_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
      
        OR DiaChi_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
    )
            ");
            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
            return loadDataByParameter(cmd);
        }


    }
}
