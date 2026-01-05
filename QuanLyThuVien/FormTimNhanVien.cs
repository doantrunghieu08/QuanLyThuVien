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
    public partial class FormTimNhanVien : Form
    {
        NhanVien_BUS nhanVien_BUS = new NhanVien_BUS();
        public FormTimNhanVien()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVien_BUS.FindNhanVien(txtTimKiem.Text);
        }

        private void FormTimNhanVien_Load(object sender, EventArgs e)
        {
            dgvNhanVien.DataSource = nhanVien_BUS.loadNhanVien();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassExcel excel = new ClassExcel();
            excel.XuatExcel(dgvNhanVien, "NhanVien.xlsx");
        }
    }
}
