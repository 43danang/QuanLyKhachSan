using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS
{
    public partial class TRANGCHULETAN : Form
    {
        private string connectionString = "server=.; database=QUANLIKHACHSAN;integrated security=true";

        public TRANGCHULETAN()
        {
            InitializeComponent();
        }

        private void TRANGCHULETAN_Load(object sender, EventArgs e)
        {

        }

        private void btnDangXuat_Click(object sender, EventArgs e)
        {
            this.Hide();
            login loginform = new login();
            loginform.Show();
        }

        private void btnDichVu_Click(object sender, EventArgs e)
        {

        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnKiemTraTinhTrangPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckIn_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKyDVTC_Click(object sender, EventArgs e)
        {

        }

        private void btnGiaHanPhong_Click(object sender, EventArgs e)
        {

        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {

        }

        private void btnDangKyDVHT_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}
