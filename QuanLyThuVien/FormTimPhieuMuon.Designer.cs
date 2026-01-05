using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    partial class FormTimPhieuMuon
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel4 = new Panel();
            txtTimKiem = new TextBox();
            label1 = new Label();
            panel3 = new Panel();
            dgvChiTietPM = new DataGridView();
            panel2 = new Panel();
            dgvPhieuMuon = new DataGridView();
            btnXuatExcel = new Button();
            btnXuatReport = new Button();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPM).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(946, 512);
            panel1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(panel4, 0, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 25.6716423F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 74.32836F));
            tableLayoutPanel1.Size = new Size(211, 335);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Controls.Add(btnXuatReport);
            panel4.Controls.Add(btnXuatExcel);
            panel4.Controls.Add(txtTimKiem);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(3, 89);
            panel4.Name = "panel4";
            panel4.Size = new Size(205, 243);
            panel4.TabIndex = 0;
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(3, 35);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(293, 27);
            txtTimKiem.TabIndex = 0;
            txtTimKiem.TextChanged += txtTimKiem_TextChanged;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.None;
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(15, 2);
            label1.Name = "label1";
            label1.Size = new Size(181, 82);
            label1.TabIndex = 1;
            label1.Text = "Tìm kiếm phiếu mượn";
            // 
            // panel3
            // 
            panel3.Controls.Add(dgvChiTietPM);
            panel3.Dock = DockStyle.Right;
            panel3.Location = new Point(211, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(735, 335);
            panel3.TabIndex = 1;
            // 
            // dgvChiTietPM
            // 
            dgvChiTietPM.Anchor = AnchorStyles.None;
            dgvChiTietPM.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChiTietPM.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChiTietPM.Location = new Point(6, 6);
            dgvChiTietPM.Name = "dgvChiTietPM";
            dgvChiTietPM.RowHeadersWidth = 51;
            dgvChiTietPM.Size = new Size(726, 326);
            dgvChiTietPM.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(dgvPhieuMuon);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 335);
            panel2.Name = "panel2";
            panel2.Size = new Size(946, 177);
            panel2.TabIndex = 0;
            // 
            // dgvPhieuMuon
            // 
            dgvPhieuMuon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPhieuMuon.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPhieuMuon.Dock = DockStyle.Fill;
            dgvPhieuMuon.Location = new Point(0, 0);
            dgvPhieuMuon.Name = "dgvPhieuMuon";
            dgvPhieuMuon.RowHeadersWidth = 51;
            dgvPhieuMuon.Size = new Size(946, 177);
            dgvPhieuMuon.TabIndex = 0;
            dgvPhieuMuon.CellClick += dgvPhieuMuon_CellClick;
            // 
            // btnXuatExcel
            // 
            btnXuatExcel.Location = new Point(48, 213);
            btnXuatExcel.Name = "btnXuatExcel";
            btnXuatExcel.Size = new Size(114, 30);
            btnXuatExcel.TabIndex = 1;
            btnXuatExcel.Text = "Xuất excel";
            btnXuatExcel.UseVisualStyleBackColor = true;
            btnXuatExcel.Click += btnXuatExcel_Click;
            // 
            // btnXuatReport
            // 
            btnXuatReport.Location = new Point(48, 175);
            btnXuatReport.Name = "btnXuatReport";
            btnXuatReport.Size = new Size(114, 29);
            btnXuatReport.TabIndex = 2;
            btnXuatReport.Text = "Xuất pdf";
            btnXuatReport.UseVisualStyleBackColor = true;
            // 
            // FormTimPhieuMuon
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(946, 512);
            Controls.Add(panel1);
            Name = "FormTimPhieuMuon";
            Text = "FormTimPhieuMuon";
            Load += FormTimPhieuMuon_Load;
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvChiTietPM).EndInit();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvPhieuMuon).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private DataGridView dgvPhieuMuon;
        private DataGridView dgvChiTietPM;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel4;
        private TextBox txtTimKiem;
        private Label label1;
        private Button btnXuatExcel;
        private Button btnXuatReport;
    }
}