using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Help_me
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source = 303-12\\SQLSERVER; Initial catalog = Uspesnay_Rabota_Na_100%; integrated Security = true;"); //Подключение базы данных
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand com = new SqlCommand($"Select * From FIO_M where Login_M = '{textBox1.Text}' and Password = '{textBox2.Text}'", con);//считываение значений из бызы данных в поля логина и пароля 
            SqlDataReader dr = com.ExecuteReader();
            if (dr.HasRows) //Проверка на правильность введенных данных
            {
                dr.Read();
                MessageBox.Show("Вы прошли автроищацию");
                Form2 f = new Form2();
                f.id = Int32.Parse(dr[0].ToString());

                f.Show();
                this.Hide();
                dr.Close();
            }
            else
                MessageBox.Show("Логин или пароль не совпадают");
            con.Close();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
