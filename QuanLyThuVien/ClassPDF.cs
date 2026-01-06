using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    public class ClassPDF
    {
        public DataTable GetDataTableFromDGV(DataGridView dgv)
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
    }
}
