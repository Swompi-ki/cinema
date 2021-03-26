using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _4
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        // Авторизация
        private void button1_Click_1(object sender, EventArgs e)
        {
            int Count = 0;
            string query = "select count(*) from user where login ='" + textBox1.Text + "' and password = '" + textBox2.Text + "';";
            MySqlConnection conn = _2.GetDBConnection();
            MySqlCommand cmDB = new MySqlCommand(query,conn);
            cmDB.CommandTimeout = 60; 
            try
            {
                conn.Open();
                Count = Convert.ToInt32(cmDB.ExecuteScalar());
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка подключения к БД");
                MessageBox.Show(ex.Message);
            }
            if (Count > 0) 
            {
                БД Win = new БД();
                Win.Show();
                this.Hide();
            }

        }
        // Закрытие приложения
        private void label6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

}

