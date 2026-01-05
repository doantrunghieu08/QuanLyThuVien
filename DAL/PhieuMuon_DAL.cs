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
    public class PhieuMuon_DAL:Connect
    {
        public DataTable Load()
        {
            return loadData(@"
                SELECT MuonTra_HieuDT_3725_LTMT5.MaMuonTra_HieuDT_3725_LTMT5, MuonTra_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5, DocGia_HieuDT_3725_LTMT5.TenDocGia_HieuDT_3725_LTMT5, 
                  MuonTra_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5, NhanVien_HieuDT_3725_LTMT5.TenNhanVien_HieuDT_3725_LTMT5, MuonTra_HieuDT_3725_LTMT5.NgayMuon_HieuDT_3725_LTMT5, 
                  MuonTra_HieuDT_3725_LTMT5.TienCoc_HieuDT_3725_LTMT5, MuonTra_HieuDT_3725_LTMT5.NgayHenTra_HieuDT_3725_LTMT5
FROM     MuonTra_HieuDT_3725_LTMT5 INNER JOIN
                  NhanVien_HieuDT_3725_LTMT5 ON MuonTra_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5 = NhanVien_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5 INNER JOIN
                  DocGia_HieuDT_3725_LTMT5 ON MuonTra_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5 = DocGia_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5
            ");

        }

        public void Insert(MuonTra ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                INSERT INTO MuonTra_HieuDT_3725_LTMT5
                  (MaMuonTra_HieuDT_3725_LTMT5, MaDocGia_HieuDT_3725_LTMT5, MaNhanVien_HieuDT_3725_LTMT5, NgayMuon_HieuDT_3725_LTMT5, TienCoc_HieuDT_3725_LTMT5, NgayHenTra_HieuDT_3725_LTMT5)
VALUES (@MaMuonTra_HieuDT_3725_LTMT5,@MaDocGia_HieuDT_3725_LTMT5,@MaNhanVien_HieuDT_3725_LTMT5,@NgayMuon_HieuDT_3725_LTMT5,@TienCoc_HieuDT_3725_LTMT5,@NgayHenTra_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue(@"MaMuonTra_HieuDT_3725_LTMT5", ob.maMuonTra);
            cmd.Parameters.AddWithValue(@"MaDocGia_HieuDT_3725_LTMT5", ob.maDocGia);
            cmd.Parameters.AddWithValue(@"MaNhanVien_HieuDT_3725_LTMT5", ob.maNhanVien);
            cmd.Parameters.AddWithValue(@"NgayMuon_HieuDT_3725_LTMT5", ob.ngayMuon);
            cmd.Parameters.AddWithValue(@"TienCoc_HieuDT_3725_LTMT5", ob.tienCoc);
            cmd.Parameters.AddWithValue(@"NgayHenTra_HieuDT_3725_LTMT5", ob.ngayHenTra);
            ExcuteNonQuery(cmd);
        }

        public void Delete(string maPhieuMuon)
        {
            // BƯỚC 1: Xóa các sách trong bảng chi tiết (Bảng con) trước
            // Nếu không xóa cái này trước, SQL sẽ chặn vì dính khóa ngoại (Foreign Key)
            SqlCommand cmdChiTiet = new SqlCommand(@"DELETE FROM ChiTietMuonTra_HieuDT_3725_LTMT5 
                                             WHERE MaMuonTra_HieuDT_3725_LTMT5 = @MaMuonTra");
            cmdChiTiet.Parameters.AddWithValue("@MaMuonTra", maPhieuMuon);
            ExcuteNonQuery(cmdChiTiet);

            // BƯỚC 2: Sau khi bảng con sạch sẽ, mới xóa Phiếu Mượn (Bảng cha)
            SqlCommand cmdPhieuMuon = new SqlCommand(@"DELETE FROM MuonTra_HieuDT_3725_LTMT5 
                                               WHERE MaMuonTra_HieuDT_3725_LTMT5 = @MaMuonTra");
            cmdPhieuMuon.Parameters.AddWithValue("@MaMuonTra", maPhieuMuon);
            ExcuteNonQuery(cmdPhieuMuon);
        }

        public void Update(string maPhieuMuon, MuonTra ob)
        {
            SqlCommand cmd = new SqlCommand(@"
                UPDATE MuonTra_HieuDT_3725_LTMT5
SET          MaDocGia_HieuDT_3725_LTMT5 = @MaDocGia_HieuDT_3725_LTMT5, MaNhanVien_HieuDT_3725_LTMT5 = @MaNhanVien_HieuDT_3725_LTMT5, NgayMuon_HieuDT_3725_LTMT5 = @NgayMuon_HieuDT_3725_LTMT5, 
                  TienCoc_HieuDT_3725_LTMT5 = @TienCoc_HieuDT_3725_LTMT5, NgayHenTra_HieuDT_3725_LTMT5 = @NgayHenTra_HieuDT_3725_LTMT5
WHERE  (MaMuonTra_HieuDT_3725_LTMT5 = @Original_MaMuonTra_HieuDT_3725_LTMT5)
            ");
            cmd.Parameters.AddWithValue("@MaDocGia_HieuDT_3725_LTMT5", ob.maDocGia);
            cmd.Parameters.AddWithValue("@MaNhanVien_HieuDT_3725_LTMT5", ob.maNhanVien);
            cmd.Parameters.AddWithValue("@NgayMuon_HieuDT_3725_LTMT5", ob.ngayMuon);
            cmd.Parameters.AddWithValue("@TienCoc_HieuDT_3725_LTMT5", ob.tienCoc);
            cmd.Parameters.AddWithValue("@NgayHenTra_HieuDT_3725_LTMT5", ob.ngayHenTra);
            cmd.Parameters.AddWithValue("@Original_MaMuonTra_HieuDT_3725_LTMT5", maPhieuMuon);
            ExcuteNonQuery(cmd);
        }

        public DataTable findPhieuMuon(string tuKhoa)
        {
            SqlCommand cmd = new SqlCommand(@"
                SELECT 
    MuonTra_HieuDT_3725_LTMT5.MaMuonTra_HieuDT_3725_LTMT5, 
    MuonTra_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5, 
    DocGia_HieuDT_3725_LTMT5.TenDocGia_HieuDT_3725_LTMT5, 
    MuonTra_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5, 
    NhanVien_HieuDT_3725_LTMT5.TenNhanVien_HieuDT_3725_LTMT5, 
    MuonTra_HieuDT_3725_LTMT5.NgayMuon_HieuDT_3725_LTMT5, 
    MuonTra_HieuDT_3725_LTMT5.TienCoc_HieuDT_3725_LTMT5, 
    MuonTra_HieuDT_3725_LTMT5.NgayHenTra_HieuDT_3725_LTMT5
FROM 
    MuonTra_HieuDT_3725_LTMT5 
INNER JOIN
    NhanVien_HieuDT_3725_LTMT5 ON MuonTra_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5 = NhanVien_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5 
INNER JOIN
    DocGia_HieuDT_3725_LTMT5 ON MuonTra_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5 = DocGia_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5
WHERE 
    (
        -- Tìm theo Mã Mượn Trả
        MuonTra_HieuDT_3725_LTMT5.MaMuonTra_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%' 
        
        -- Tìm theo Mã hoặc Tên Độc Giả
        OR MuonTra_HieuDT_3725_LTMT5.MaDocGia_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        OR DocGia_HieuDT_3725_LTMT5.TenDocGia_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
        -- Tìm theo Mã hoặc Tên Nhân Viên
        OR MuonTra_HieuDT_3725_LTMT5.MaNhanVien_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        OR NhanVien_HieuDT_3725_LTMT5.TenNhanVien_HieuDT_3725_LTMT5 LIKE N'%' + @TuKhoa + '%'
        
        -- Tìm theo Tiền cọc (Cần chuyển sang chuỗi để so sánh LIKE)
        OR CAST(MuonTra_HieuDT_3725_LTMT5.TienCoc_HieuDT_3725_LTMT5 AS NVARCHAR) LIKE N'%' + @TuKhoa + '%'
        
        -- Tìm theo Ngày mượn/hẹn trả (Cần chuyển sang chuỗi, định dạng dd/MM/yyyy hoặc tùy cấu hình)
        OR CONVERT(NVARCHAR, MuonTra_HieuDT_3725_LTMT5.NgayMuon_HieuDT_3725_LTMT5, 103) LIKE N'%' + @TuKhoa + '%'
        OR CONVERT(NVARCHAR, MuonTra_HieuDT_3725_LTMT5.NgayHenTra_HieuDT_3725_LTMT5, 103) LIKE N'%' + @TuKhoa + '%'
    )
            ");
            cmd.Parameters.AddWithValue("@TuKhoa", tuKhoa);
            return loadDataByParameter(cmd);
        }
    }
}
