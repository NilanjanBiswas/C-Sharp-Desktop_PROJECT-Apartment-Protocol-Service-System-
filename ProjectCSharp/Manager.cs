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
    public partial class Manager : Form
    {
        int countf = 1;
        public Manager()
        {
            InitializeComponent();

        }
        String connectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";
        string value;
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            value = "SERVENT";
        }

        private void RadioButton2_Click(object sender, EventArgs e)
        {
            //TextBox txt = new TextBox();
            //txt.Location = new Point(197, 499);

            
                AddNewTextBox();
            
        }
            public System.Windows.Forms.TextBox AddNewTextBox()
            {
                System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
                this.Controls.Add(txt);
            txt.Location = new Point(130, 70);
            txt.Height = 50;
            txt.Width = 100;
            countf = countf - 1;
            return txt;
            }
        void SetVisible()
        {
            System.Windows.Forms.TextBox txt = new System.Windows.Forms.TextBox();
            this.Controls.Add(txt);
            txt.Hide();

        }


        private void RadioButton1_Click(object sender, EventArgs e)
        {
            //radioButton2.Enabled = false;

            SetVisible();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox7.Text != "" && textBox6.Text != "" && textBox5.Text != "" && textBox4.Text != "" && textBox9.Text != "" && textBox8.Text != "")
                {
                    SqlConnection sql = new SqlConnection(connectionString);
                    sql.Open();
                    SqlCommand cmd = sql.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into stuff values('" + textBox7.Text + "','" + textBox6.Text + "','" + textBox5.Text + "','" + textBox4.Text + "','" + textBox9.Text + "','" + textBox8.Text + "')";
                    cmd.ExecuteNonQuery();





                    MessageBox.Show("Stuff Added");
                    textBox7.Text = "";
                    textBox6.Text = "";
                    textBox5.Text = "";
                    textBox4.Text = "";
                    textBox9.Text = "";
                    textBox8.Text = "";
                }



                else
                {
                    MessageBox.Show("Not Added");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong input");
            }

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            value = "STUFF";
        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            try {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.ConnectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";







                string query = "select * from service_charge where flatno='" + textBox1.Text.Trim() + "' and month_year='" + textBox2.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, sql);

                SqlDataAdapter sda = new SqlDataAdapter(query, sql);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);



                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show(" paid already !!!");
                    button4.Enabled = false;



                }

                else
                {
                    MessageBox.Show("Not paid !!");
                    button4.Enabled = true;

                }

            }
            catch (SqlException)
            {
                MessageBox.Show("Try again!!!");

            }
            
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                //if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                //{
                    SqlConnection sql = new SqlConnection(connectionString);

                       sql.Open();


                if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    
                           SqlCommand cmdd = sql.CreateCommand();
                        cmdd.CommandType = CommandType.Text;
                        cmdd.CommandText = "insert into service_charge values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
                        cmdd.ExecuteNonQuery();



                        
                        MessageBox.Show(" Service Charge paid!!");
                        textBox3.Text = "";
                        textBox2.Text = "";
                        textBox1.Text = "";
                    }
                else
                {
                    MessageBox.Show(" Uncessful !!");
                }
            }
            //else


            //    {
            //        MessageBox.Show(" Uncessful !!");
            //    }

        //}
            catch (SqlException)
            {
              MessageBox.Show("Try again!!!");

            }
        //}
    }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                Environment.Exit(1);
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to Sign Out?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {

                Form1 fm = new Form1();
                fm.Show();
                this.Hide();
            }
        }
    }
    }

