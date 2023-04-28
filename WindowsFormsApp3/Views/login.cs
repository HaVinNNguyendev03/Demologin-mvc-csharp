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
using System.Xml.Linq;
using WindowsFormsApp3.Controllers;
using WindowsFormsApp3.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace WindowsFormsApp3
{


    public partial class login : Form
    {


        //khởi tạo biến usercontroller có giá trị tham chiếu là UserController và phạm vi là private nhằm chỉ cho phép lưu hành nội bộ trong class login
        private UserController userController;
        public login()
        {
            InitializeComponent();
            userController = new UserController();//đã khởi tạo thành đối tượng 

        }



        private void textname_TextChanged(object sender, EventArgs e)
        {

        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            //kiểm tra
            /*userController.ShowUsers();*/
            //gán giá trị mà người dùng nhập vào
            string username = textname.Text;
            string password = textpassword.Text;
            //khai báo biến loginResult được gán bằng đối tượng userController,mục đích là nhận giá trị trả về của phương thức Login
            bool loginResult = userController.Login(username, password);//tham số để gán giá trị mà người dùng nhập vào 
           //in ra thông báo kết quả đăng nhập 
            if (loginResult)
            {
                MessageBox.Show("Đăng nhập thành công!");
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng!");
            }

        }
        //kiểm tra kết nối db
       /* private void button1_Click(object sender, EventArgs e)
        {
            connectDB db = new connectDB();
            List<user> users = db.GetUsers();
            if (users != null && users.Count > 0)
            {
                MessageBox.Show("Kết nối và lấy dữ liệu thành công!");
                foreach (user u in users)
                {
                    MessageBox.Show("Name: " + u.Name + ", Password: " + u.Password);
                }
            }
            else
            {
                MessageBox.Show("Kết nối hoặc lấy dữ liệu không thành công!");
            }
        }*/

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void closebtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}

        

       
    

