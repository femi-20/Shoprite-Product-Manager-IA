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
        private void populateBills()
        {
            Con.Open();
            string query = "select * from  BillTb1";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BillsDGV.DataSource = ds.Tables[0];
            Con.Close();
        }
        private void fillcombo()
        {
            Con.Open();
            SqlCommand cmd = new SqlCommand("select CatName from CategoryTb1", Con);
            SqlDataReader rdr;
            rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("Catname", typeof(string));
            dt.Load(rdr);
            SelCb.ValueMember = "CatName";
            SelCb.DataSource = dt;
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
            populate();
            populateBills();
            fillcombo();
        }
        int flag = 0;

        private void SelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.SelDGV.Rows[e.RowIndex];
                ProdName.Text = row.Cells["ProdName"].Value.ToString();
                ProdPrice.Text = row.Cells["ProdPrice"].Value.ToString();
                TotQty.Text = row.Cells["ProdQty"].Value.ToString();
                flag = 1; 
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
            if (printPreviewDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
        }

        private void ProdDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            flag = 1;
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
             int l = 0;
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
                l= Convert.ToInt32(TotQty.Text) - Convert.ToInt32(ProdQty.Text);
            Amt.Text = "Rs  " + Grdtotal;
                SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                Con.Open();
                SqlCommand cmd = new SqlCommand("update  ProductTb1 set   ProdQty = '"+l+" ' where ProdName = " + ProdName.Text + " ", Con);
                cmd.ExecuteNonQuery();
                Con.Close();
                populate();
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (BillID.Text == "")
            {
                MessageBox.Show("Missing Bill ID");
            }
            else
            { 
            try
            {
                SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
                Con.Open();
                string query = "insert into BillTb1 (BillId, SellerName ,BillDate , TotAmt ) values(" + BillID.Text + ",'" + SelName.Text + "','" + DateSg.Text + "', '" + Amt.Text + "')";
                SqlCommand cmd = new SqlCommand(query, Con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Bill added successfully");
                Con.Close();
                populateBills();

            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
            }
        }

        private void ORDERDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 log = new Form1();
            log.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            populate();
            populateBills();
            fillcombo();
            ProdName.Text = "";
            ProdQty.Text = "";
            BillID.Text = "";
            ProdPrice.Text = "";


        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            e.Graphics.DrawString("SHOPRITE", new Font("Century Gotic", 25, FontStyle.Bold), Brushes.Red, new Point(230));
            e.Graphics.DrawString("Bill ID :"+ BillsDGV.SelectedRows[0].Cells[0].Value.ToString(), new Font("Century Gotic", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(100,100));
            e.Graphics.DrawString("Seller Name  :" + BillsDGV.SelectedRows[0].Cells[1].Value.ToString(), new Font("Century Gotic", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(100, 100));
            e.Graphics.DrawString(" Date :" + BillsDGV.SelectedRows[0].Cells[2].Value.ToString(), new Font("Century Gotic", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(70, 100));
            e.Graphics.DrawString(" Total Amount  :" + BillsDGV.SelectedRows[0].Cells[3].Value.ToString(), new Font("Century Gotic", 20, FontStyle.Bold), Brushes.BlueViolet, new Point(100, 100));

        }

        private void SelCb_SelectionChangedCommitted(object sender, EventArgs e)
        {
            Con.Open();
            string query = "select ProdName,ProdQty from ProductTb1 where ProdCat= ' " + SelCb.SelectedValue.ToString() + "'";
            SqlDataAdapter sda = new SqlDataAdapter(query, Con);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            SelDGV.DataSource = ds.Tables[0];
            Con.Close();
        }

       
    }
}
