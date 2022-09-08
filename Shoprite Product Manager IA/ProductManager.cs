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
    public partial class ProductManager : Form
    {
        public ProductManager()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");


        private void ProductManager_Load(object sender, EventArgs e)
    {
            populate();
            fillcombo();

    }
        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTb1", Con);
            SqlDataReader rdr ;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Catname", typeof(string));
            dt.Load(rdr);
            CatCb.DataSource = dt;
            CatCb.ValueMember = "CatName";
            ProdCb2.DataSource = dt;
            ProdCb2.ValueMember = "CatName";
            Con.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
               

                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("update  ProductTb1 set  ProdName = '" + ProdName.Text + "' ,ProdQty = '" + ProdQty.Text + "', ProdPrice = '" + ProdPrice.Text + "' where ProdID = " + ProdID.Text + " ", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("product deleted successfully");
                    Con.Close();
                    populate();
                
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                if (ProdID.Text == "" || ProdName.Text == "" || ProdQty.Text == "" || ProdPrice.Text == "")
                {
                    MessageBox.Show("missing information");
                }
                else
                {

                    SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                    Con.Open();
                    SqlCommand cmd = new SqlCommand("delete from  ProductTb1 where ProdID = '" + ProdID.Text + "'", Con);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("product deleted successfully");
                    Con.Close();
                    populate();
                }
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                Con.Open();
                string query = "insert into ProductTb1 (ProdId, ProdName ,ProdQty , ProdPrice , ProdCat) values(" + ProdID.Text + ",'" + ProdName.Text + "','" + ProdQty.Text + "', '" + ProdPrice.Text + "' , '" + CatCb.SelectedValue.ToString() +"')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("product added successfully");
                Con.Close();
                populate();
         
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            CategoryForm Cat = new CategoryForm();
            Cat.Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.ProdDGV.Rows[e.RowIndex];
                ProdID.Text = row.Cells["ProdId"].Value.ToString();
                ProdName.Text = row.Cells["ProdName"].Value.ToString();
                ProdQty.Text = row.Cells["ProdQty"].Value.ToString();
                ProdPrice.Text = row.Cells["ProdPrice"].Value.ToString();
                CatCb.SelectedValue= row.Cells["ProdCat"].Value.ToString();
            }
        }
        private void populate()
        {
            Con.Open();
            string query = "select * from ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();

        }

        private void CatCb_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 prod = new Form1();
            prod.Show();
            this.Hide();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ProdCb2_SelectionChangedCommited(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select * from ProductTb1 where ProdCat = ' " +ProdCb2.SelectedValue+ "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ProdDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            populate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SellerForm Seller = new SellerForm();
            Seller.Show();
            this.Hide();
        }
    }
}
