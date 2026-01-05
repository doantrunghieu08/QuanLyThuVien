using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO;

namespace DAL
{
    public class Sach_DAL:Connect
    {
        public DataTable load()
        {
            return loadData(@"
                SELECT MaSach_HieuDT_3725_LTMT5, TenSach_HieuDT_3725_LTMT5, NhaXuatBan_HieuDT_3725_LTMT5, TheLoai_HieuDT_3725_LTMT5, TacGia_HieuDT_3725_LTMT5, NamXuatBan_HieuDT_3725_LTMT5
FROM     Sach_HieuDT_3725_LTMT5
            ");
        }

        public void InsertSach(Sach ob) {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Sach_HieuDT_3725_LTMT5
                  (MaSach_HieuDT_3725_LTMT5, TenSach_HieuDT_3725_LTMT5, NhaXuatBan_HieuDT_3725_LTMT5, TheLoai_HieuDT_3725_LTMT5, TacGia_HieuDT_3725_LTMT5, NamXuatBan_HieuDT_3725_LTMT5)
VALUES (@MaSach_HieuDT_3725_LTMT5,@TenSach_HieuDT_3725_LTMT5,@NhaXuatBan_HieuDT_3725_LTMT5,@TheLoai_HieuDT_3725_LTMT5,@TacGia_HieuDT_3725_LTMT5,@NamXuatBan_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue("@MaSach_HieuDT_3725_LTMT5", ob.maSach);
            cmd.Parameters.AddWithValue("@TenSach_HieuDT_3725_LTMT5", ob.tenSach);
            cmd.Parameters.AddWithValue("@NhaXuatBan_HieuDT_3725_LTMT5", ob.nhaXuatBan);
            cmd.Parameters.AddWithValue("@TheLoai_HieuDT_3725_LTMT5", ob.theLoai);
            cmd.Parameters.AddWithValue("@TacGia_HieuDT_3725_LTMT5", ob.tacGia);
            cmd.Parameters.AddWithValue("@NamXuatBan_HieuDT_3725_LTMT5", ob.namXuatBan);
            ExcuteNonQuery(cmd);

        }
        public void DeleteSach(string maSach) { 
            SqlCommand cmd = new SqlCommand(@" DELETE FROM Sach_HieuDT_3725_LTMT5
WHERE  (MaSach_HieuDT_3725_LTMT5 = @Original_MaSach_HieuDT_3725_LTMT5)");
            cmd.Parameters.AddWithValue("@Original_MaSach_HieuDT_3725_LTMT5", maSach);
            ExcuteNonQuery(cmd);
        }

        public void UpdateSach(Sach ob, string maSach)
        {
            SqlCommand cmd = new SqlCommand(@"
                UPDATE Sach_HieuDT_3725_LTMT5
SET          TenSach_HieuDT_3725_LTMT5 = @TenSach_HieuDT_3725_LTMT5, NhaXuatBan_HieuDT_3725_LTMT5 = @NhaXuatBan_HieuDT_3725_LTMT5, TheLoai_HieuDT_3725_LTMT5 = @TheLoai_HieuDT_3725_LTMT5, 
                  TacGia_HieuDT_3725_LTMT5 = @TacGia_HieuDT_3725_LTMT5, NamXuatBan_HieuDT_3725_LTMT5 = @NamXuatBan_HieuDT_3725_LTMT5
WHERE  (MaSach_HieuDT_3725_LTMT5 = @Original_MaSach_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue("@TenSach_HieuDT_3725_LTMT5", ob.tenSach);
            cmd.Parameters.AddWithValue("@NhaXuatBan_HieuDT_3725_LTMT5", ob.nhaXuatBan);
            cmd.Parameters.AddWithValue("@TheLoai_HieuDT_3725_LTMT5", ob.theLoai);
            cmd.Parameters.AddWithValue("@TacGia_HieuDT_3725_LTMT5", ob.tacGia);
            cmd.Parameters.AddWithValue("@NamXuatBan_HieuDT_3725_LTMT5", ob.namXuatBan);
            cmd.Parameters.AddWithValue("@Original_MaSach_HieuDT_3725_LTMT5", maSach);
            ExcuteNonQuery(cmd);
        }

        public Dictionary<string, string> getSach()
        {
            Dictionary<string, string> mapSach = new Dictionary<string, string>();

            DataTable dt = loadData(@"SELECT MaSach_HieuDT_3725_LTMT5, TenSach_HieuDT_3725_LTMT5
FROM     Sach_HieuDT_3725_LTMT5");

            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string maSach = row["MaSach_HieuDT_3725_LTMT5"].ToString();
                    string tenSach = row["TenSach_HieuDT_3725_LTMT5"].ToString();

                    if (!mapSach.ContainsKey(maSach))
                    {
                        mapSach.Add(maSach, tenSach);
                    }
                }
            }
            return mapSach;

        }

        public DataTable findSach(string tuKhoa)
        {
            SqlCommand cmd = new SqlCommand(@"SELECT 
    MaSach_HieuDT_3725_LTMT5, 
    TenSach_HieuDT_3725_LTMT5, 
    NhaXuatBan_HieuDT_3725_LTMT5, 
    TheLoai_HieuDT_3725_LTMT5, 
    TacGia_HieuDT_3725_LTMT5, 
    NamXuatBan_HieuDT_3725_LTMT5
FROM 
    Sach_HieuDT_3725_LTMT5
WHERE 
    (
       
        MaSach_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
       
        OR TenSach_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
       
        OR NhaXuatBan_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
        
        OR TheLoai_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
      
        OR TacGia_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
       
        OR CAST(NamXuatBan_HieuDT_3725_LTMT5 AS NVARCHAR) LIKE N'%' + @TuKhoa + '%'
    )");
            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
            return loadDataByParameter(cmd);
        }
        


    }
}
