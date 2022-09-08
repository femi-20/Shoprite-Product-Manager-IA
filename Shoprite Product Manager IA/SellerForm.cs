using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Shoprite_Product_Manager_IA
{
    public partial class SellerForm : Form
    {
        public SellerForm()
        {
            InitializeComponent();
        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");


        private void SellerForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void populate()
        {
            Con.Open();
            string query = "select * from SellerTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SellerDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void button3_Click(object sender, EventArgs e)
        {

            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
            Con.Open();
            string query = "insert into SellerTb1 (SellerId, SellerName ,SellerAge , SellerPhone , SellerPass) values(" + SellerId.Text + ",'" + SellerName.Text + "','" + SellerAge.Text + "', '" + SellerPhone.Text + "' , '" + SellerPass.Text+ "')";
            SqlCommand cmd = new SqlCommand(query, Con);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Attendant added successfully");
            Con.Close();
            populate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (SellerId.Text == "" || SellerName.Text == "" || SellerAge.Text == "" || SellerPhone.Text == "" || SellerPass.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  SellerTb1 where SellerId = '" + SellerId.Text + "'", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Attendant deleted successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {


                SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                Con.Open();
                SqlCommand cmd = new SqlCommand("update  SellerTb1 set  SellerName = '" + SellerName.Text + "' ,SellerAge = '" + SellerAge.Text + "', SellerPhone = '" + SellerPhone.Text + "', SellerPass = '"+SellerPass.Text+"' where SellerId = " + SellerId.Text + " ", Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Attendant record  updated successfully");
                Con.Close();
                populate();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void SellerDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.SellerDGV.Rows[e.RowIndex];
                SellerId.Text = row.Cells["SellerId"].Value.ToString();
                SellerName.Text = row.Cells["SellerName"].Value.ToString();
                SellerAge.Text = row.Cells["SellerAge"].Value.ToString();
                SellerPhone.Text = row.Cells["SellerPhone"].Value.ToString();
                SellerPass.Text = row.Cells["SellerPass"].Value.ToString();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm Seller = new SellerForm();
            Seller.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 prod = new Form1();
            prod.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategoryForm Cat = new CategoryForm();
            Cat.Show();
            this.Hide();
        }
    }



}
