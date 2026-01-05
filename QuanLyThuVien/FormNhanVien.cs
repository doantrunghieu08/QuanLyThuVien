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
    public partial class FormNhanVien : Form
    {
        NhanVien_BUS nhanVien_Bus = new NhanVien_BUS();
        public FormNhanVien()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FormNhanVien_Load(object sender, EventArgs e)
        {
            loadData();
        }
        public void loadData()
        {
            dgvNhanVien.DataSource = nhanVien_Bus.loadNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NhanVien ob = new NhanVien();
            ob.ID = txtMaNhanVien.Text;
            ob.Name = txtTenNhanVien.Text.Trim();
            ob.SDT = txtSoDienThoai.Text;
            ob.email = txtEmail.Text;
            ob.diaChi = txtDiaChi.Text;

            nhanVien_Bus.InsertNhanVien(ob);
            MessageBox.Show("Thêm thành công");
            loadData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maNhanVien = txtMaNhanVien.Text;
                NhanVien ob = new NhanVien();
                ;
                ob.Name = txtTenNhanVien.Text.Trim();
                ob.SDT = txtSoDienThoai.Text;
                ob.email = txtEmail.Text;
                ob.diaChi = txtDiaChi.Text;
                nhanVien_Bus.UpdateNhanVien(maNhanVien, ob);
                MessageBox.Show("Cập nhật thành công");
                loadData();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                string maNhanVien = txtMaNhanVien.Text;
                nhanVien_Bus.DeleteNhanVien(maNhanVien);
                MessageBox.Show("Xóa thành công");
                loadData();
            }
            
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvNhanVien.Rows[e.RowIndex];
                txtMaNhanVien.Text = row.Cells["MaNhanVien_HieuDT_3725_LTMT5"].Value.ToString();
                txtTenNhanVien.Text = row.Cells["TenNhanVien_HieuDT_3725_LTMT5"].Value.ToString();
                txtSoDienThoai.Text = row.Cells["SoDienThoai_HieuDT_3725_LTMT5"].Value.ToString();
                txtEmail.Text = row.Cells["Email_HieuDT_3725_LTMT5"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi_HieuDT_3725_LTMT5"].Value.ToString();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Thoát thành công", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes) {
                this.Close();
            }
        }
    }
}
