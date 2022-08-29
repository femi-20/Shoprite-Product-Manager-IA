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

namespace Shoprite_Product_Manager_IA
{
    public partial class CategoryForm : Form
    {
        public CategoryForm()
        {
            InitializeComponent();
        }


        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Con.Open();
                string query = "insert into CategoryTb1 (CatId, CatName ,CatDesc) values(" +CatIdTb.Text+ ",'" +CatNameTb.Text+ "','" +CatDescTb.Text+ "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("category added successfully");
                Con.Close();
                populate();
            }
            catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
         
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from CategoryTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CatDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CatDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.CatDGV.Rows[e.RowIndex];
                CatIdTb.Text = row.Cells["CatId"].Value.ToString();
                CatNameTb.Text = row.Cells["CatName"].Value.ToString();
                CatDescTb.Text = row.Cells["CatDesc"].Value.ToString();
            }

            
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  CategoryTb1 where CatID = '" + CatIdTb.Text + "'", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category deleted successfully");
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
                if (CatIdTb.Text == "" || CatNameTb.Text == "" || CatDescTb.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {
                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update CategoryTb1 set CatName = '" + CatNameTb.Text + "',CatDesc = '" + CatDescTb.Text + "' where CatId =" + CatIdTb.Text + " ", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("category updated successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void CatDGV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProductManager prod = new ProductManager();
            prod.Show();
            this.Hide();
        }
    }
}
