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

namespace ProjectCSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        String connectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";
        private void Button1_Click(object sender, EventArgs e)
        {

        //    try
        //    {
        //        //if (textBox1.Text != "" && textBox2.Text != "")
        //        //{
        //            SqlConnection sql = new SqlConnection(connectionString);
        //            sql.ConnectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";

        //            sql.Open();
        //            string query = "select * from login where user_name='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
        //            SqlCommand cmd = new SqlCommand(query, sql);
        //            SqlDataReader rdr = cmd.ExecuteReader();

        //            if (rdr.Read())
        //            {
        //                var string1 = rdr.GetString(3).Trim();


        //                if (string1 == "guard")
        //                {
        //                    Guardcs guardp = new Guardcs();
        //                    this.Hide();
        //                    guardp.Show();

        //                }

        //                else if (string1 == "manager")
        //                {
        //                    Manager managerp = new Manager();
        //                    this.Hide();
        //                    managerp.Show();

        //                }
        //                else
        //                {
        //                    MessageBox.Show(" No operational window !!!");
        //                }

        //            }


        //       // }


        //        else if (textBox1.Text == "" && textBox2.Text == "")

        //        {
        //            MessageBox.Show("Invalid User Name Or Password");

        //        }
        //        else
        //        {
        //            MessageBox.Show("Invalid!!!!");
        //        }
        //}
        //    catch (Exception)
        //    {
        //        MessageBox.Show(" Something Worng HAppen!! plz try again !!!");
        //    }


        }

        private void Button2_Click(object sender, EventArgs e)
        {

            //DialogResult dialog = new DialogResult();

            //dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            //if (dialog == DialogResult.Yes)
            //{
            //    System.Environment.Exit(1);
            //}
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                //if (textBox1.Text != "" && textBox2.Text != "")
                //{
                SqlConnection sql = new SqlConnection(connectionString);
                sql.ConnectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";

                sql.Open();
                string query = "select * from login where user_name='" + textBox1.Text.Trim() + "' and password='" + textBox2.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataReader rdr = cmd.ExecuteReader();

                if (rdr.Read())
                {
                    var string1 = rdr.GetString(3).Trim();


                    if (string1 == "guard")
                    {
                        Guardcs guardp = new Guardcs();
                        this.Hide();
                        guardp.Show();

                    }

                    else if (string1 == "manager")
                    {
                        Manager managerp = new Manager();
                        this.Hide();
                        managerp.Show();

                    }
                    else
                    {
                        MessageBox.Show(" No operational window !!!");
                    }

                }


                // }


                else if (textBox1.Text == "" && textBox2.Text == "")

                {
                    MessageBox.Show("Invalid User Name Or Password");

                }
                else
                {
                    MessageBox.Show("Invalid!!!!");
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Something Worng HAppen!! plz try again !!!");
            }


        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
