using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
<<<<<<< HEAD
using System.Data.SqlClient;
=======
>>>>>>> 96406d1bf29979ad77fb11f4ff1f7c1fee7db72b
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
<<<<<<< HEAD
using System.Data.SqlClient;
=======
>>>>>>> 96406d1bf29979ad77fb11f4ff1f7c1fee7db72b

namespace Shoprite_Product_Manager_IA
{
    public partial class SellingForm : Form
    {
        public SellingForm()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");
        private void populate()
        {
            Con.Open();
            string query = "select ProdName , ProdQty from  ProductTb1";
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
            populate();
        }

        private void SelDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            ProdName.Text = SelDGV.SelectedRows[0].Cells[0].Value.ToString(); 
            ProdQty.Text = SelDGV.SelectedRows[0].Cells[1].Value.ToString();
        }
=======
>>>>>>> 96406d1bf29979ad77fb11f4ff1f7c1fee7db72b
    }
}
