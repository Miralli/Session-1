using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            timer1.Interval = 15000;
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        static int a = 0;
        

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите логин", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LoginBox.Focus();
                return;
            }

            if (PasswordBox.Text == "")
            {
                MessageBox.Show("Пожалуйста, введите пароль", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                PasswordBox.Focus();
                return;
            }
            try // обработчик исключений, в связке с catch
            {
                if (a < 3)
                {
                    SqlConnection con = new SqlConnection(@"Data Source = sqlstud; Initial Catalog = 16is27; User ID = 16is27; Password = 16is27"); //строка подключения
                    SqlDataAdapter dataAdapter = new SqlDataAdapter("SELECT Count(*) FROM [Account] WHERE Login ='" + LoginBox.Text + "' and Password = '" + PasswordBox.Text + "'and Type='" + 1 + "'", con); //выбираем количесвто строк из таблицы и присваем имя dataAdapter
                    DataTable dt = new DataTable(); // создание таблице с именем dt
                    dataAdapter.Fill(dt); // заполнение таблицы dt из запроса 
                    if (dt.Rows[0][0].ToString() == "1") // условие: если в таблице есть строка, то выполняем
                    {
                        MessageBox.Show("Вы успешно зашли в систему " + LoginBox.Text);
                        this.Hide();
                        Form f0 = new Form2();
                        f0.Show();
                    }
                    else


                    {
                        SqlDataAdapter dataAdapter1 = new SqlDataAdapter("SELECT COUNT(*) FROM [Account] WHERE Login = '" + LoginBox.Text + "' and Password = '" + PasswordBox.Text + "'and Type ='" + 2 + "'", con);
                        DataTable dt1 = new DataTable();
                        dataAdapter1.Fill(dt1);
                        if (dt1.Rows[0][0].ToString() == "1")
                        {
                            MessageBox.Show("Добро пожаловать " + LoginBox.Text);
                            this.Hide();
                            Form f1 = new Form3();
                            f1.Show();
                        }

                        else
                        {
                            SqlDataAdapter dataAdapter2 = new SqlDataAdapter("SELECT COUNT(*) FROM [Account] WHERE Login = '" + LoginBox.Text + "' and Password = '" + PasswordBox.Text + "'and Type = '" + 3 + "'", con);
                            DataTable dt2 = new DataTable();
                            dataAdapter2.Fill(dt2);
                            if (dt2.Rows[0][0].ToString() == "1")
                            {
                                MessageBox.Show("Добро пожаловать " + LoginBox.Text);
                                this.Hide();
                                Form f2 = new Form4();
                                f2.Show();
                            }
                            else
                            {
                                a = a + 1;
                                MessageBox.Show("Не удалось войти в систему... Попробуйте позже", "Вход запрещен", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                LoginBox.Text = "";
                                PasswordBox.Text = "";

                            }

                        }
                    }
                }
                else if (a == 3)
                {
                    int b = timer1.Interval / 1000;
                    timer1.Start();
                    MessageBox.Show("Вы превысили лимит ввода данных, система заблокирована на " + b + " секунд.", "Блокировка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LoginBox.Enabled = false;
                    PasswordBox.Enabled = false;
                    button1.Enabled = false;
                    LoginBox.Text = "";
                    PasswordBox.Text = "";
                    

                }
                
            } 
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LoginBox_TextChanged(object sender, EventArgs e)
        {

        }
        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (timer1.Interval == timer1.Interval) { timer1.Stop(); LoginBox.Enabled = true; PasswordBox.Enabled = true; button1.Enabled = true; MessageBox.Show("Блокировка закончилась. Введите данные"); timer1.Interval = timer1.Interval + 15000; }
            
        }

        
        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                string query = "SELECT * FROM dbo.[Account] Where Login = '" + LoginBox1.Text + "'";
                SqlDataAdapter h = new SqlDataAdapter(query, connection);
                DataTable dt3 = new DataTable();
                h.Fill(dt3);
                if (dt3.Rows[0].ToString() == "1")
                
                
                {
                    MessageBox.Show("Данный логин существует");

                }
                else
                {
                    regist();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            }
            Console.Read();
        }

        private void regist()
        {
            string path = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection conn;
            SqlCommand cmd = new SqlCommand();

            string query = "INSERT INTO [Account] ([Login],[Password],[Surname],[Name],[E-mail],[Type]) VALUES ('" + LoginBox1.Text + "','" + PasswordBox1.Text + "','" + SurnameBox.Text + "','" + NameBox.Text + "','" + MailBox.Text + "','" + 3 + "')";
            conn = new SqlConnection(path);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Данные успешно сохранены");

            panel2.Visible = true;
            panel1.Visible = false;
            LoginBox1.Text = "";
            PasswordBox1.Text = "";
            SurnameBox.Text = "";
            NameBox.Text = "";
            MailBox.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
  
}