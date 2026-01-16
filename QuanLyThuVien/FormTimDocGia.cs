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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ClassPDF classPDF = new ClassPDF();
                // 1. Lấy dữ liệu
                DataTable dtHienTai = classPDF.GetDataTableFromDGV(dgvDocGia);

                if (dtHienTai.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu trên lưới để xuất!");
                    return;
                }

                // 2. Khởi tạo báo cáo
                baoCaoDocGia rpt = new baoCaoDocGia();

                // 3. Đổ dữ liệu
                rpt.SetDataSource(dtHienTai);

                // 4. Lưu file
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF Files|*.pdf";
                saveFile.FileName = "Danhsachdocgia_DaTimKiem.pdf";

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
