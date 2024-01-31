using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Telephone_app
{
    public partial class Telephone : Form
    {

        SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=Phone;Integrated Security=True");
        public Telephone()
        {
            InitializeComponent();
        }

        private void Telephone_Load(object sender, EventArgs e)
        {
            Display();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"INSERT INTO MobilePhone
                             (First, Last , Mobile , Email , Category)
                              VALUES ('" + textBox5.Text + "' , '" + textBox1.Text + "' , '" + textBox2.Text + "' , '" + textBox4.Text + "' , '" + comboBox1.Text + "')", conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Saved Successfully!");

            Display();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            textBox5.Focus();

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        void Display()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("Select * FROM MobilePhone", conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.Rows.Clear();
            foreach (DataRow dr in dt.Rows)
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = dr["First"].ToString();
                dataGridView1.Rows[n].Cells[1].Value = dr["Last"].ToString();
                dataGridView1.Rows[n].Cells[2].Value = dr["Mobile"].ToString();
                dataGridView1.Rows[n].Cells[3].Value = dr["Email"].ToString();
                dataGridView1.Rows[n].Cells[4].Value = dr["Category"].ToString();

            }

        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            conn.Open();
            SqlCommand cmd = new SqlCommand(@"DELETE FROM MobilePhone WHERE (Mobile = '" + textBox2.Text + "')", conn);
            cmd.ExecuteNonQuery();

            conn.Close();

            MessageBox.Show("Deleted Successfully!");

            Display();

        }

        private void button4_Click(object sender, EventArgs e)
        {


            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"UPDATE MobilePhone SET First = @First, Last = @Last, Mobile = @Mobile, Email = @Email, Category = @Category WHERE Mobile = @Mobile", conn);
                cmd.Parameters.AddWithValue("@First", textBox5.Text);
                cmd.Parameters.AddWithValue("@Last", textBox1.Text);
                cmd.Parameters.AddWithValue("@Mobile", textBox2.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@Category", comboBox1.Text);

                cmd.ExecuteNonQuery();
                conn.Close();

                MessageBox.Show("Updated Successfully!");

                Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }

    }
    }

