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
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand("select CatId,CatName from CategoryTb1", Con);
        SqlDataAdapter da = new SqlDataAdapter();
        da.SelectCommand = cmd;
        DataTable table1 = new DataTable();
            da.Fill(table1);
            CatCb.DataSource = table1;
            CatCb.DisplayMember = "CatName";
            CatCb.ValueMember = "CatId";
            populate();

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
                CatCb.SelectedValue= row.Cells["ProdPrice"].Value.ToString();
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
    }
}
