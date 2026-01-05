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
    public partial class FormTimDocGia : Form
    {
        DocGia_BUS docGia_BUS = new DocGia_BUS();
        public FormTimDocGia()
        {
            InitializeComponent();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = docGia_BUS.findDocGia(txtTimKiem.Text);
        }

        private void FormTimDocGia_Load(object sender, EventArgs e)
        {
            dgvDocGia.DataSource = docGia_BUS.loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassExcel excel = new ClassExcel();
            excel.XuatExcel(dgvDocGia, "DocGia.xlsx");
        }
    }
}
