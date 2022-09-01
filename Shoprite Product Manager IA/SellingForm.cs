using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Data.SqlClient;


using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace Shoprite_Product_Manager_IA
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }

        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select * from  ProductTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void SellingForm_Load(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
            SqlCommand cmd = new SqlCommand("select CatName,CatId from CategoryTb1", Con);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = cmd;
            DataTable table1 = new DataTable();
            da.Fill(table1);
            SelCb.DataSource = table1;
            SelCb.DisplayMember = "CatName";
            SelCb.ValueMember = "CatId";
            populate();
        }

        private void SelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.SelDGV.Rows[e.RowIndex];
                ProdName.Text = row.Cells["ProdName"].Value.ToString();
                ProdPrice.Text = row.Cells["ProdPrice"].Value.ToString();
            }
                

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ProdPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            DateSg.Text = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString();

        }

        private void DateSg_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ProdName.Text == "" || ProdQty.Text == "")
            {
                MessageBox.Show("Missing  Data");
            
            }
            else { 
            int n = 0, Total = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            int Grdtotal = 0;
            DataGridViewRow newRow = new DataGridViewRow();
            newRow.CreateCells(ORDERDGV);
            newRow.Cells[0].Value = n + 1;
            newRow.Cells[1].Value = ProdName.Text;
            newRow.Cells[2].Value = ProdPrice.Text;
            newRow.Cells[3].Value = ProdQty.Text;
            newRow.Cells[4].Value = Convert.ToInt32(ProdPrice.Text) * Convert.ToInt32(ProdQty.Text);
            ORDERDGV.Rows.Add(newRow);
            n++;
            Grdtotal = Grdtotal + Total;
            Amt.Text = "Rs  " + Grdtotal;
            }


        }
    }
}
