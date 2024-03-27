using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace QLKS
{
    public partial class login : Form
    {
        private string connectionString = "server=.; database=QUANLIKHACHSAN;integrated security=true";
        private SqlCommand cmd;
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string taiKhoan = txtTaiKhoan.Text;
            string matKhau = txtMatKhau.Text;
            if (taiKhoan == "" || matKhau =="")
            {
                MessageBox.Show("Tên đăng nhập và mật khẩu không được để trống", "Thông báo");
            }
            else { 
                SqlConnection con = new SqlConnection();
                using (con = new SqlConnection(connectionString))
                {
                    try
                    {
                        con.Open();
                        //Đọc MANV của người dùng
                        string query = "SELECT MANV FROM TAIKHOAN WHERE USERNAME = @taiKhoan AND U_PASSWORD = @matKhau";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@taiKhoan", taiKhoan);
                        cmd.Parameters.AddWithValue("@matKhau", matKhau);
                        SqlDataReader reader = cmd.ExecuteReader();
                        string MANV = "";
                        if (reader.Read())
                        {
                            int manvInt = reader.GetInt32(0);
                            MANV = manvInt.ToString();
                        }
                        reader.Close();

                        //Đọc vai trò của người dùng
                        query = "SELECT VAITRO FROM TAIKHOAN WHERE MANV = @MANV";
                        cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@MANV", MANV);
                        reader = cmd.ExecuteReader();
                        string vaiTro = "";
                        if (reader.Read())
                        {
                            vaiTro = reader.GetString(0);
                        }
                        if (vaiTro == "")
                        {
                            MessageBox.Show("Xin vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu", "Thông báo");
                        }
                        reader.Close();
                        con.Close();

                        //DỰA VÀO VAI TRÒ CỦA NGƯỜI DÙNG MÀ CHUYỂN SANG GIAO DIỆN TƯƠNG ỨNG
                        if (vaiTro == "LỄ TÂN")
                        {
                            this.Hide();
                            TRANGCHULETAN TRANGCHULETANFORM = new TRANGCHULETAN();
                            TRANGCHULETANFORM.Show();
                        }
                        else if (vaiTro == "BELLMAN")
                        {
                            this.Hide();
                            TRANGCHUBELLMAN TRANGCHUBELLMANFORM = new TRANGCHUBELLMAN();
                            TRANGCHUBELLMANFORM.Show();
                        }
                        else if (vaiTro == "BUỒNG PHÒNG")
                        {
                            this.Hide();
                            TRANGCHUBUONGPHONG TRANGCHUBUONGPHONGFORM = new TRANGCHUBUONGPHONG();
                            TRANGCHUBUONGPHONGFORM.Show();
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Xin vui lòng kiểm tra lại tên đăng nhập hoặc mật khẩu", "Thông báo");
                    }
                }
            }
        }

        private void txtMatKhau_TextChanged(object sender, EventArgs e)
        {
            txtMatKhau.PasswordChar = '*';
        }
    }
}
