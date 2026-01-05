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
                var cellValue = row.Cells["MaMuonTra_HieuDT_3725_LTMT5"].Value;
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
    }
}
