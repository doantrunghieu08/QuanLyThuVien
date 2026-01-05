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
                // 1. Lấy dữ liệu
                DataTable dtHienTai = GetDataTableFromDGV(dgvSach);

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
        private DataTable GetDataTableFromDGV(DataGridView dgv)
        {
            DataTable dt = new DataTable();

            // 1. Tạo cột cho DataTable (Chỉ cột hiện)
            foreach (DataGridViewColumn col in dgv.Columns)
            {
                if (col.Visible)
                {
                    
                    dt.Columns.Add(col.Name, col.ValueType ?? typeof(string));
                }
            }

            // 2. Duyệt qua dữ liệu
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (!row.IsNewRow)
                {
                    DataRow dRow = dt.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        // Chỉ xử lý nếu cột đó đang hiện
                        if (dgv.Columns[cell.ColumnIndex].Visible)
                        {
                            
                            string columnName = dgv.Columns[cell.ColumnIndex].Name;

                            dRow[columnName] = cell.Value ?? DBNull.Value;
                        }
                    }
                    dt.Rows.Add(dRow);
                }
            }
            return dt;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }
    }
}
