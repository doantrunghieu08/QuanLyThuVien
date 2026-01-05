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
using DTO;

namespace QuanLyThuVien
{
    public partial class FormChiTiet : Form
    {
        ChiTietPhieuMuon_BUS chiTietPhieuMuon = new ChiTietPhieuMuon_BUS();
        Sach_BUS sach_BUS = new Sach_BUS();
        public FormChiTiet(string maPhieuMuon)
        {
            InitializeComponent();
            txtMaMuonTra.Text = maPhieuMuon;
            dTPNgayTra.Format = DateTimePickerFormat.Custom;
            dTPNgayTra.CustomFormat = "dd/MM/yyyy";
        }

        private void FormChiTiet_Load(object sender, EventArgs e)
        {
            try
            {
                loadData();
                loadSach();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi tải dữ liệu Form Con: " + ex.Message);
                this.Close(); // Nếu lỗi thì đóng form luôn cho gọn
            }
        }
        public void loadData()
        {
            dgvChiTiet.DataSource = chiTietPhieuMuon.loadChiTietPM(txtMaMuonTra.Text);
        }

        public void loadSach()
        {
            Dictionary<string, string> mapMonHoc = sach_BUS.getSach();
            cbbMaSach.DataSource = new BindingSource(mapMonHoc, null);

            cbbMaSach.DisplayMember = "Value"; // Hiển thị Tên khoa (phần Value của Dictionary)
            cbbMaSach.ValueMember = "Key";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            ChiTietMuonTra ob = new ChiTietMuonTra();
            ob.maMuonTra = txtMaMuonTra.Text;
            ob.maSach = Convert.ToString(cbbMaSach.SelectedValue);
            ob.ngayTra = dTPNgayTra.Value;
            ob.tienPhat = Convert.ToInt32(txtTienPhat.Text);
            ob.ghiChu = txtGhiChu.Text;
            chiTietPhieuMuon.InsertChiTietPM(ob);
            loadData();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maMuonTra = txtMaMuonTra.Text;
                ChiTietMuonTra ob = new ChiTietMuonTra();

                ob.maMuonTra = txtMaMuonTra.Text.Trim();
                ob.maSach = Convert.ToString(cbbMaSach.SelectedValue);
                ob.ngayTra = dTPNgayTra.Value;
                ob.tienPhat = Convert.ToInt32(txtTienPhat.Text);
                ob.ghiChu = txtGhiChu.Text;
                chiTietPhieuMuon.UpdateChiTietPM(ob, maMuonTra);
                MessageBox.Show("Sửa thành công");
                loadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maMuonTra = txtMaMuonTra.Text;
                string maSach = Convert.ToString(cbbMaSach.SelectedValue);
                chiTietPhieuMuon.DeleteChiTietPM(maMuonTra, maSach);
                MessageBox.Show("Xóa thành công");
                loadData();
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn thoát?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void dgvChiTiet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvChiTiet.Rows[e.RowIndex];
                cbbMaSach.Text = row.Cells["MaSach_HieuDT_3725_LTMT5"].Value.ToString();
                dTPNgayTra.Text = row.Cells["NgayTra_HieuDT_3725_LTMT5"].Value.ToString();
                txtTienPhat.Text = row.Cells["TienPhat_HieuDT_3725_LTMT5"].Value.ToString();
                txtGhiChu.Text = row.Cells["GhiChu_HieuDT_3725_LTMT5"].Value.ToString();
            }
        }
    }
}
