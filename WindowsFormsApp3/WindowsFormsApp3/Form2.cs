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

namespace WindowsFormsApp3
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(button1, "Предоставляет управление пользователями");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            toolTip2.SetToolTip(button2, "Предоставляет управление продукцией");
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_16is27DataSet.Catalog". При необходимости она может быть перемещена или удалена.
            this.catalogTableAdapter.Fill(this._16is27DataSet.Catalog);

            panel2.Visible = false;
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_16is27DataSet.Account". При необходимости она может быть перемещена или удалена.
            this.accountTableAdapter.Fill(this._16is27DataSet.Account);
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel3.Visible = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection conn;
            SqlCommand cmd = new SqlCommand();

            string query = "INSERT INTO [Account] ([Login],[Password],[Surname],[Name],[E-mail],[Type]) VALUES ('" + Login.Text + "','" + Password.Text + "','" + Surname.Text + "','" + Name2.Text + "','" + Mailbox.Text + "','" + Type2.Text + "')";
            conn = new SqlConnection(path);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Данные успешно сохранены");

            panel2.Visible = true;
            panel1.Visible = false;
            Login.Text = "";
            Password.Text = "";
            Surname.Text = "";
            Name2.Text = "";
            Mailbox.Text = "";
            Type2.Text = "";
            this.accountTableAdapter.Fill(this._16is27DataSet.Account);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection conn;
            SqlCommand cmd = new SqlCommand();

            string query = "DELETE FROM dbo.Account where Login = '" + Login.Text +"'";
            conn = new SqlConnection(path);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Успешно удалено");
            this.accountTableAdapter.Fill(this._16is27DataSet.Account);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel2.Visible = false;
            panel1.Visible = false;

        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection conn;
            SqlCommand cmd = new SqlCommand();

            string query = "INSERT INTO [Catalog] ([Name],[Type of boat],[Number of places for rowers],[Tree variety],[color],[Base price],[Mast presence]) VALUES ('" + namebox.Text + "','" + typebox.Text + "','" + rowbox.Text + "','" + varbox.Text + "','" + colorbox.Text + "','" + pricebox.Text + "','" + 1 +"')";
            conn = new SqlConnection(path);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Данные успешно сохранены");

            
            namebox.Text = "";
            typebox.Text = "";
            rowbox.Text = "";
            varbox.Text = "";
            colorbox.Text = "";
            pricebox.Text = "";
            mastbox.Text = "";
            this.catalogTableAdapter.Fill(this._16is27DataSet.Catalog);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string path = @"Data Source=sqlstud; Initial Catalog=16is27; Persist Security Info=True; User ID=16is27; Password=16is27";
            SqlConnection conn;
            SqlCommand cmd = new SqlCommand();

            string query = "DELETE FROM dbo.Catalog where name = '" + namebox.Text + "'";
            conn = new SqlConnection(path);
            conn.Open();
            cmd.Connection = conn;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Успешно удалено");
            this.catalogTableAdapter.Fill(this._16is27DataSet.Catalog);
        }
    }
}
