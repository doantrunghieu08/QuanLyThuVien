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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPDF classPDF = new ClassPDF();
                // 1. Lấy dữ liệu
                DataTable dtHienTai = classPDF.GetDataTableFromDGV(dgvNhanVien);

                if (dtHienTai.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!");
                    return;
                }

                // 2. Khởi tạo báo cáo
                baoCaoNhanVien rpt = new baoCaoNhanVien();

                // 3. Đổ dữ liệu
                rpt.SetDataSource(dtHienTai);

                // 4. Lưu file
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.FileName = "DanhsachNhanVien_TimKiem.pdf";

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
    }
}
