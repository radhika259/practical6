using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;


namespace P6_form_
{
    public partial class Form1 : Form
    {
        string imgPath;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string source = @"C:\DOTNET\P6(FORM)\P6(FORM)\PROPERTIES\DATABASE1.MDF";
            string select = "select count(*) from tblStudent";
            SqlConnection conn = new SqlConnection(source);
            SqlCommand cmd = new SqlCommand(select, conn);
            conn.Open();
            int i = Convert.ToInt16(cmd.ExecuteScalar());
            int textBox1 = i + 1;

            string insert = "insert into tblStudent(Name,Email,Phone No,Gender,Address,imgStudent) values ( " + textBox1 + ",'" + textBox3 + "','" + textBox4 + "','" + radioButton1 + "','" + richTextBox1 + "','" + (imgPath == null ? "" : imgPath) + "' )";
            cmd = new SqlCommand(insert, conn);

            i = cmd.ExecuteNonQuery();
             //object imgStudent = null;
            if (imgPath != null)
           imgStudent.Image.Save(imgPath);
            MessageBox.Show("You are Done!!!");
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "Jpg|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                imgPath = @"C:\Pictures" + openFileDialog1.SafeFileName;
                imgStudent.Image = Image.FromFile(openFileDialog1.FileName);
            }

        }
    }
}


