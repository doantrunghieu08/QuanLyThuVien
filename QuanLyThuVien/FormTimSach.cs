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
    public partial class FormTimSach : Form
    {
        Sach_BUS sach_BUS = new Sach_BUS();

        public FormTimSach()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dgvSach.DataSource = sach_BUS.findSach(txtTimKiem.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassExcel excel = new ClassExcel();
            excel.XuatExcel(dgvSach, "Sach.xlsx");
        }

        private void FormTimSach_Load(object sender, EventArgs e)
        {
            dgvSach.DataSource = sach_BUS.LoadDataSach();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPDF classPDF = new ClassPDF();
                // 1. Lấy dữ liệu
                DataTable dtHienTai = classPDF.GetDataTableFromDGV(dgvSach);

                if (dtHienTai.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!");
                    return;
                }

                // 2. Khởi tạo báo cáo
                baoCaoSach rpt = new baoCaoSach();

                // 3. Đổ dữ liệu
                rpt.SetDataSource(dtHienTai);

                // 4. Lưu file
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.FileName = "DanhSachSach_KetQuaTimKiem.pdf";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    rpt.ExportToDisk(ExportFormatType.PortableDocFormat, saveFile.FileName);
                    MessageBox.Show("Đã xuất file PDF thành công!");
                }
            }
            catch (Exception ex)
            {
                // Hiện lỗi ra để biết đường sửa thay vì thoát app
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        
        }
        

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
