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
    public partial class Guardcs : Form
    {
        public Guardcs()
        {
            InitializeComponent();

        }
        String connectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";
        string value;

        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();
            SqlCommand cmd = sql.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select flat_number,owner_name,mobile_number,fathers_name from flat_owner";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();


              }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {


        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.ConnectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";







                string query = "select * from " + value + " where name='" + textBox2.Text.Trim() + "'";
                SqlCommand cmd = new SqlCommand(query, sql);

                SqlDataAdapter sda = new SqlDataAdapter(query, sql);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);



                if (dt.Rows.Count == 1)
                {
                    MessageBox.Show(" User Found !!!");



                }

                else
                {
                    MessageBox.Show("Not a User");

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something went Wrong!! Please Try Again!!");
            }

        }

        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            value = "flat_members";
        }

        private void Guardcs_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'apartmentServiceProtocolDataSet2.guest' table. You can move, or remove it, as needed.
            this.guestTableAdapter.Fill(this.apartmentServiceProtocolDataSet2.guest);
            // TODO: This line of code loads data into the 'apartmentServiceProtocolDataSet1.log' table. You can move, or remove it, as needed.
            this.logTableAdapter.Fill(this.apartmentServiceProtocolDataSet1.log);

        }

        private void RadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            value = "servent";
        }

        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            value = "stuff";

        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            SqlConnection sql = new SqlConnection();
            sql.ConnectionString = "Data Source=DESKTOP-O6TEKPG;Initial Catalog=ApartmentServiceProtocol;Integrated Security=True";
            SqlDataAdapter adapter = new SqlDataAdapter();
            sql.Open();
            //SqlDataReader dr;
            SqlCommand command = new SqlCommand("select flat_number,owner_name,mobile_number,fathers_name from flat_owner where flat_number LIKE @name", sql);
            command.Parameters.Add(new SqlParameter("@name", "%" + textBox1.Text.Trim() + "%"));
            command.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter adt = new SqlDataAdapter(command);
            adt.Fill(dt);
            dataGridView1.DataSource = dt;
            sql.Close();


        }

        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //guest entry button
            DateTime entry = DateTime.Now;



            try
            {
                if (textBox3.Text != "" && textBox4.Text != "" && textBox3.Text != "" && textBox4.Text != "")
                {
                    SqlConnection sql = new SqlConnection(connectionString);
                    sql.Open();
                    SqlCommand cmd = sql.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "insert into guest values('" + textBox4.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + entry.ToString() + "','" + null + "')";
                    cmd.ExecuteNonQuery();





                    MessageBox.Show("Guest Added");
                    textBox3.Text = "";
                    textBox4.Text = "";
                    textBox5.Text = "";
                    textBox6.Text = "";
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

        private void Button6_Click(object sender, EventArgs e)
        {
            //guest exit
            DateTime eexit = DateTime.Now;
            //textBox3.Text = "";
            try
            {
                if (textBox3.Text != "")
                {
                    SqlConnection sql = new SqlConnection(connectionString);
                    sql.Open();
                    SqlCommand cmd = sql.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "update  guest set exit_time='" + eexit.ToString() + "' where name='" + textBox3.Text + "' and exit_time='" + null + "'";
                    cmd.ExecuteNonQuery();
                    int i = cmd.ExecuteNonQuery();



                    sql.Close();


                    MessageBox.Show("Guest Exit Sucess");
                    textBox3.Text = "";

                }

                else
                {
                    MessageBox.Show("Unsucessful !!!!!!!!!!!!!");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No record Found!!");

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DateTime entry = DateTime.Now;
            //textBox2.Text = "";



            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                string query = "select * from " + value + " where name='" + textBox2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter sda = new SqlDataAdapter(query, sql);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);
                sql.Close();


                Console.Out.WriteLine("try");


                if (dt.Rows.Count == 1)
                {
                    sql = new SqlConnection(connectionString);
                    sql.Open();
                    query = "select * from  log where name='" + textBox2.Text.Trim() + "' and type='" + value + "'and exit_time='"+null+"'";
                    cmd = new SqlCommand(query, sql);
                    sda = new SqlDataAdapter(query, sql);
                    ada = new SqlDataAdapter(cmd);
                    dt = new DataTable();
                    ada.Fill(dt);
                    sql.Close();

                    Console.Out.WriteLine("1stIF");


                    if (dt.Rows.Count > 0)
                    {

                        Console.Out.WriteLine("Already Entered!!");
                        MessageBox.Show(" Already Entered!!");
                    }
                    else
                    {


                        Console.Out.WriteLine("Already Entered!!Else");
                        sql = new SqlConnection(connectionString);
                        sql.Open();
                        SqlCommand cmdd = sql.CreateCommand();
                        cmdd.CommandType = CommandType.Text;
                        cmdd.CommandText = "insert into log values('" + textBox2.Text + "','" + value + "','" + entry.ToString() + "','" + null + "') ";
                        cmdd.ExecuteNonQuery();
                        dt = new DataTable();
                        dataGridView1.DataSource = dt;



                        sql.Close();
                        MessageBox.Show(" Added");
                        textBox2.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show(" Search plz!!");
                }
                
            }
            catch (Exception)
            {
                MessageBox.Show("Wrong input");
            }

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ///exit registered user
            DateTime eexit = DateTime.Now;
            //textBox2.Text = "";

            try
            {
                SqlConnection sql = new SqlConnection(connectionString);
                sql.Open();
                string query = "select * from  log where name='" + textBox2.Text.Trim() + "' and type='" + value + "'and exit_time=''";
                SqlCommand cmd = new SqlCommand(query, sql);
                SqlDataAdapter sda = new SqlDataAdapter(query, sql);
                SqlDataAdapter ada = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                ada.Fill(dt);



                if (dt.Rows.Count == 1)
                {


                    SqlConnection nsql = new SqlConnection(connectionString);
                    nsql.Open();
                    SqlCommand cmdd = sql.CreateCommand();
                    cmdd.CommandType = CommandType.Text;
                    cmdd.CommandText = "update  log set exit_time='" + eexit.ToString() + "' where name='" + textBox2.Text.Trim() + "' and type='" + value + "'and exit_time='" + null + "'";
                    cmdd.ExecuteNonQuery();



                    sql.Close();
                    MessageBox.Show(" Exit Sucess");
                }
                else
                {
                    MessageBox.Show(" wrong input");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No record Found!!");

            }


        }

        private void Button5_Click(object sender, EventArgs e)
        {
            DialogResult dialog = new DialogResult();

            dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                System.Environment.Exit(1);
            }
        }

        private void DataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
           



        }

        private void Button7_Click(object sender, EventArgs e)
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
