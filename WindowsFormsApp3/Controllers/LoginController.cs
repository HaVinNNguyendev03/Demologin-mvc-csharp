using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.Controllers;
using WindowsFormsApp3.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using WindowsFormsApp3;


namespace WindowsFormsApp3.Controllers
{
    public class UserController
    {
        public void ShowUsers()
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
        }
        //phương thức này sẽ trả về giá trị bool tùy theo trường hợp true false
        public bool Login(string username, string password)
        {
            //khởi tạo đối tượng db tham chiếu tới connectDB
            connectDB db = new connectDB();
            //khởi tạo users có kiểu là list<user> = đối tượng db.getusers(),phương thức này của đói tượng đã có giá trị trả về là users
            List<user> users = db.GetUsers();
            //so sánh dữ liệu từ người dùng nhập vào với dữ liệu trong db,sử dụng ToLower và trim để loại bỏ các khoảng trắng
                foreach (user u in users)
                {
                    if (u.Name.ToLower().Trim() == username.ToLower().Trim() && u.Password.Trim() == password.Trim())
                    {
                    return true;
                    }
                }

                return false;
            
        }
    }
}







