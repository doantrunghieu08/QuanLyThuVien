using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using CrystalDecisions.Shared;

namespace QuanLyThuVien
{
    public partial class FormTimPhieuMuon : Form
    {
        MuonTra_BUS muonTra_BUS = new MuonTra_BUS();
        ChiTietPhieuMuon_BUS chiTietPhieuMuon_BUS = new ChiTietPhieuMuon_BUS();
        string maPhieuMuon = "null";
        public FormTimPhieuMuon()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvPhieuMuon.DataSource = muonTra_BUS.FindMuonTra(txtTimKiem.Text);
        }

        private void FormTimPhieuMuon_Load(object sender, EventArgs e)
        {
            dgvPhieuMuon.DataSource = muonTra_BUS.LoadMuonTra();
            dgvChiTietPM.DataSource = chiTietPhieuMuon_BUS.loadChiTietPM(maPhieuMuon);
        }

        private void dgvPhieuMuon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvPhieuMuon.Rows[e.RowIndex];
                var cellValue = row.Cells[0].Value;
                if (cellValue != null)
                {
                    maPhieuMuon = cellValue.ToString();

                    // 2. QUAN TRỌNG: Gọi lại hàm load dữ liệu chi tiết dựa trên mã vừa lấy
                    dgvChiTietPM.DataSource = chiTietPhieuMuon_BUS.loadChiTietPM(maPhieuMuon);
                }
            }

        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            ClassExcel excel = new ClassExcel();
            excel.XuatExcel(dgvPhieuMuon, "PhieuMuon.xslx");
        }

        private void btnXuatReport_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPDF classPDF = new ClassPDF();
                // 1. Lấy dữ liệu
                DataTable dtHienTai = classPDF.GetDataTableFromDGV(dgvPhieuMuon);

                if (dtHienTai.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!");
                    return;
                }

                // 2. Khởi tạo báo cáo
                baoCaoPhieuMuon rpt = new baoCaoPhieuMuon();

                // 3. Đổ dữ liệu
                rpt.SetDataSource(dtHienTai);

                // 4. Lưu file
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.FileName = "DanhSachPhieuMuon_KetQuaTimKiem.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, saveFile.FileName);
                    MessageBox.Show("Đã xuất file PDF thành công!");
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
    }
}
