using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace MySchool菜单功能
{
    public class Program
    {
        static void Main()
        {
            SqlConnection connection = null;
            SqlDataReader datareader = null;
            try
            {
                string connstring = "Data Source = .;DataBase = MySchool;User ID = sa;pwd = 23002";
                connection = new SqlConnection(connstring);
                connection.Open();

                Console.WriteLine("1.登录");
                Console.WriteLine("2.查看学生用户列表");
                Console.WriteLine("3.查看指定学生的所有基本信息");
                Console.WriteLine("4.修改学生生日信息");
                Console.WriteLine("5.查询指定学生姓名");
                Console.WriteLine("6.查询年级信息");
                Console.WriteLine("7.删除学生信息");
                Console.WriteLine("8.退出");

                Console.WriteLine("请输入数字：1~8");
                int num = int.Parse(Console.ReadLine());
                while (num == 1)
                {
                    Console.WriteLine("请输入用户名：");
                    string LoginId = Console.ReadLine();
                    Console.WriteLine("请输入密码：");
                    string LoginPwd = Console.ReadLine();
                    string sqlcommand = string.Format("SELECT COUNT(*) FROM Admin where loginid = '{0}' and loginpwd = '{1}'", LoginId, LoginPwd);
                    SqlCommand command = new SqlCommand(sqlcommand, connection);
                    command.ExecuteScalar();
                    int result = Convert.ToInt32(command.ExecuteScalar());
                    if (result == 1)
                    {
                        Console.WriteLine("登录成功。");
                    }
                    else
                    {
                        Console.WriteLine("登录失败。");
                    }
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 2)
                {
                    Console.WriteLine("查看学生用户列表");
                    string sqldatareader = "SELECT StudentNo,StudentName,LoginPwd,Phone,Email FROM Student";
                    SqlCommand command = new SqlCommand(sqldatareader, connection);
                    datareader = command.ExecuteReader();
                    Console.WriteLine("--------------------");
                    Console.WriteLine("学号\t姓名\t密码\t电话\t邮箱");
                    Console.WriteLine("--------------------");
                    while (datareader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}", datareader["StudentNo"], datareader["StudentName"], datareader["LoginPwd"], datareader["Phone"], datareader["Email"]);
                    }
                    Console.WriteLine("--------------------");
                    datareader.Close();
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 3)
                {
                    Console.WriteLine("查看指定学生的所有基本信息");
                    string sqldatareader = "SELECT * FROM Student WHERE StudentNo=56";
                    SqlCommand command = new SqlCommand(sqldatareader, connection);
                    datareader = command.ExecuteReader();
                    Console.WriteLine("--------------------");
                    Console.WriteLine("学号\t密码\t姓名\t性别\t电话\t地址\t出生日期\t邮箱\t身份证");
                    Console.WriteLine("--------------------");
                    while (datareader.Read())
                    {
                        Console.WriteLine("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\t{8}", datareader[0], datareader[1], datareader[2], datareader[3], datareader[4], datareader[5], datareader[6], datareader[7], datareader[8]);
                    }
                    Console.WriteLine("--------------------");
                    datareader.Close();
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 4)
                {
                    Console.WriteLine("修改学生生日信息");
                    string sql = string.Format("UPDATE Student SET BornDate='1999-06-04 00:00:00.000' WHERE StudentNo=12");
                    SqlCommand command = new SqlCommand(sql, connection);
                    int updateresult = command.ExecuteNonQuery();
                    if (updateresult > 0)
                    {
                        Console.WriteLine("修改成功");
                    }
                    else
                    {
                        Console.WriteLine("修改失败");
                    }
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 5)
                {
                    Console.WriteLine("查询指定学生姓名");
                    string sqlname = "SELECT StudentNo, StudentName FROM Student";
                    SqlCommand command = new SqlCommand(sqlname, connection);
                    datareader = command.ExecuteReader();
                    Console.Write("姓名：");
                    string stuName = string.Empty;
                    datareader.Read();
                    stuName = Convert.ToString(datareader["StudentName"]);
                    Console.WriteLine(datareader["StudentName"]);
                    datareader.Close();
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 6)
                {
                    Console.WriteLine("查询年级信息");
                    string sqlgrade = string.Format("select * from Grade");
                    SqlCommand command = new SqlCommand(sqlgrade, connection);
                    datareader = command.ExecuteReader();
                    Console.WriteLine("年级信息：");
                    while (datareader.Read())
                    {
                        Console.WriteLine("{0}\t{1}", datareader[0], datareader[1]);
                    }
                    datareader.Close();
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 7)
                {
                    Console.WriteLine("删除学生信息");
                    string sqldelete = string.Format("DELETE FROM Student WHERE StudentNo =23");
                    SqlCommand command = new SqlCommand(sqldelete, connection);
                    int delete = command.ExecuteNonQuery();
                    if (delete > 0)
                    {
                        Console.WriteLine("删除成功！");
                    }
                    else
                    {
                        Console.WriteLine("删除失败！");
                    }
                    num = int.Parse(Console.ReadLine());
                }

                while (num == 8)
                {
                    Console.WriteLine("退出");
                    return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                connection.Close();
                Console.WriteLine("数字有误");
                Console.ReadLine();
            }
        }
    }
}
