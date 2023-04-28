using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static System.Net.WebRequestMethods;
using System.Runtime.InteropServices.WindowsRuntime;
using WindowsFormsApp3;
using System.Data;

namespace WindowsFormsApp3.Models
{
    //tạo class user để tham chiếu
    public class user
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public user(string Name, string Password)
        {
            this.Name = Name;
            this.Password = Password;
        }
    }
    //tạo class kết nối 
    public class connectDB
    {
        //biến connectionString lưu trữ chuỗi kết nối
        private string _connectionString;
        //phương thức khởi tạo thực hiện việc gán chuỗi kết nối cho connectionString
        public connectDB()
        {
            _connectionString = "Data Source=LAPTOP-7UJJVL2N\\SQLSEVER;Initial Catalog=thuchanh;Integrated Security=True;";


        }
        //phương thức lấy dữ liệu từ DB có kiểu dữ liệu trả về là một list<user>(list được tham chiếu tới class user)
        public List<user> GetUsers()
        {
            //khời tạo đối tượng users có kiểu dữ liệu là một list<user>
            List<user> users = new List<user>();
            //Sử dụng block using giúp tối ưu,đồng thời khởi tạo đối tượng connection được tham chiếu tới class sqlconnection phục vụ cho việc kết nối csdl
            using (SqlConnection connection = new SqlConnection(_connectionString))//phương thức khởi tạo của class cần đối số để thực hiện,cụ thể khi new đối tượng sqlconnection thì gán biến connectionString để thực hiện việc kết nối
            {
                connection.Open(); //kết nối mở
                string query = "SELECT * FROM dbUser";//query tới from 
                SqlCommand command = new SqlCommand(query, connection);//thực hiện lệnh truy vấn,có các tham số là truy vấn và kết nối db,tuy nhiên mới chỉ xử lý không có dữ liệu trả về
                DataTable dataTable = new DataTable();//khởi tạo đối tượng datatable tham chiếu tới class  DataTable nhằm mục đích xử lý các dữ liệu được gán,lưu trữ ở dạng table
                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);// khởi tạo đối tượng dataAdapter tham chiếu tới class SqlDataAdapter nhằm mục đích lưu trữ dữ liệu trả về,đối số là cách để class SqlDataAdapter kết nối và xử lý cho nên ta gán đối tượng command
                dataAdapter.Fill(dataTable);//phương thức fill trong SqlDataAdapter nhằm đổ dữ liệu cho một biến hay đối tượng bất kỳ,cụ thể ta có đối tượng datatable.Và datatable sẽ xử lý dữ liệu bằng các phương thức của mình
                //chạy vòng lặp foreach để lọc dữ liệu và gán cho users
                foreach (DataRow row in dataTable.Rows)//Datarow là một class con của datatable nó đại diện cho mỗi trường dữ liệu trong datatable bao gồm 1 hàng dữ liệu như "name","password";còn datatable.rows là rất nhiều.có thể hiểu datatable.rows là một mảng còn row là 1 phần tử trong mảng ấy.
                {
                    user user = new user(row["name"].ToString(), row["password"].ToString());//gán dữ liệu name và password cho đối tượng user,đối tượng row này sẽ truy cập tới cột name và lấy giá trị trong cột name đó,password cũng vậy
                    users.Add(user);//thêm giá trị cho users bằng phương thức add.Lúc này dữ liệu có kiểu là list<user>,tức là một list có name và password được tham chiếu từ class user
                }
            }

            return users;//trả về giá trị users
        }
    }

   
    



}

