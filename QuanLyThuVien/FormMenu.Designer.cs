using System.Drawing;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    partial class FormMenu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.heThongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.đăngXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DocGiaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.NhanVienItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MuonTraItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timKiemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchPhieuMuonItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchDocGiaItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchNhanVienItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SearchSachItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.heThongToolStripMenuItem,
            this.quảnLToolStripMenuItem,
            this.timKiemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1052, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // heThongToolStripMenuItem
            // 
            this.heThongToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.đăngXuấtToolStripMenuItem,
            this.thoátToolStripMenuItem});
            this.heThongToolStripMenuItem.Name = "heThongToolStripMenuItem";
            this.heThongToolStripMenuItem.Size = new System.Drawing.Size(85, 24);
            this.heThongToolStripMenuItem.Text = "Hệ thống";
            // 
            // đăngXuấtToolStripMenuItem
            // 
            this.đăngXuấtToolStripMenuItem.Name = "đăngXuấtToolStripMenuItem";
            this.đăngXuấtToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.đăngXuấtToolStripMenuItem.Text = "Đăng xuất";
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.thoátToolStripMenuItem.Text = "Thoát";
            // 
            // quảnLToolStripMenuItem
            // 
            this.quảnLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SachItem,
            this.DocGiaItem,
            this.NhanVienItem,
            this.MuonTraItem});
            this.quảnLToolStripMenuItem.Name = "quảnLToolStripMenuItem";
            this.quảnLToolStripMenuItem.Size = new System.Drawing.Size(93, 24);
            this.quảnLToolStripMenuItem.Text = "Chức năng";
            this.quảnLToolStripMenuItem.DropDownClosed += new System.EventHandler(this.quảnLToolStripMenuItem_DropDownItemClicked);
            this.quảnLToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.quảnLToolStripMenuItem_DropDownItemClicked);
            this.quảnLToolStripMenuItem.DoubleClick += new System.EventHandler(this.quảnLToolStripMenuItem_DropDownClosed);
            // 
            // SachItem
            // 
            this.SachItem.Name = "SachItem";
            this.SachItem.Size = new System.Drawing.Size(224, 26);
            this.SachItem.Text = "Sách";
            // 
            // DocGiaItem
            // 
            this.DocGiaItem.Name = "DocGiaItem";
            this.DocGiaItem.Size = new System.Drawing.Size(224, 26);
            this.DocGiaItem.Text = "Độc giả";
            // 
            // NhanVienItem
            // 
            this.NhanVienItem.Name = "NhanVienItem";
            this.NhanVienItem.Size = new System.Drawing.Size(224, 26);
            this.NhanVienItem.Text = "Nhân viên";
            // 
            // MuonTraItem
            // 
            this.MuonTraItem.Name = "MuonTraItem";
            this.MuonTraItem.Size = new System.Drawing.Size(224, 26);
            this.MuonTraItem.Text = "Mượn trả";
            // 
            // timKiemToolStripMenuItem
            // 
            this.timKiemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SearchPhieuMuonItem,
            this.SearchDocGiaItem,
            this.SearchNhanVienItem,
            this.SearchSachItem});
            this.timKiemToolStripMenuItem.Name = "timKiemToolStripMenuItem";
            this.timKiemToolStripMenuItem.Size = new System.Drawing.Size(84, 24);
            this.timKiemToolStripMenuItem.Text = "Tìm kiếm";
            this.timKiemToolStripMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.timKiemToolStripMenuItem_DropDownItemClicked);
            // 
            // SearchPhieuMuonItem
            // 
            this.SearchPhieuMuonItem.Name = "SearchPhieuMuonItem";
            this.SearchPhieuMuonItem.Size = new System.Drawing.Size(224, 26);
            this.SearchPhieuMuonItem.Text = "Phiếu mượn";
            // 
            // SearchDocGiaItem
            // 
            this.SearchDocGiaItem.Name = "SearchDocGiaItem";
            this.SearchDocGiaItem.Size = new System.Drawing.Size(224, 26);
            this.SearchDocGiaItem.Text = "Độc giả";
            // 
            // SearchNhanVienItem
            // 
            this.SearchNhanVienItem.Name = "SearchNhanVienItem";
            this.SearchNhanVienItem.Size = new System.Drawing.Size(224, 26);
            this.SearchNhanVienItem.Text = "Nhân viên";
            // 
            // SearchSachItem
            // 
            this.SearchSachItem.Name = "SearchSachItem";
            this.SearchSachItem.Size = new System.Drawing.Size(224, 26);
            this.SearchSachItem.Text = "Sách";
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 414);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMenu";
            this.Text = "FormMenu";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem heThongToolStripMenuItem;
        private ToolStripMenuItem đăngXuấtToolStripMenuItem;
        private ToolStripMenuItem thoátToolStripMenuItem;
        private ToolStripMenuItem quảnLToolStripMenuItem;
        private ToolStripMenuItem SachItem;
        private ToolStripMenuItem DocGiaItem;
        private ToolStripMenuItem NhanVienItem;
        private ToolStripMenuItem MuonTraItem;
        private ToolStripMenuItem timKiemToolStripMenuItem;
        private ToolStripMenuItem SearchPhieuMuonItem;
        private ToolStripMenuItem SearchDocGiaItem;
        private ToolStripMenuItem SearchNhanVienItem;
        private ToolStripMenuItem SearchSachItem;
    }
}
