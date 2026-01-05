using System;
using System.Windows.Forms;

namespace QuanLyThuVien
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Xóa dòng lỗi cũ đi nhé: ApplicationConfiguration.Initialize();

            // Thay bằng 2 dòng này (Code chuẩn của .NET Framework):
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Dòng này giữ nguyên để chạy Form của bạn
            Application.Run(new FormMenu());
        }
    }
}