

using System.Data;
using System.Data.SqlClient;


namespace Shoprite_Product_Manager_IA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        SqlConnection Con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Utilisateur\Documents\shoprite.db.mdf;Integrated Security=True;Connect Timeout=30");

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username, user_password;


            username = txt_username.Text;
            user_password = txt_userpasword.Text;
            
            try
            {
                if (txt_username.Text == "" || txt_userpasword.Text == "")
                {
                    MessageBox.Show("enter username and password ");
                }

                else 
                {
                    if (RoleCb.SelectedItem.ToString() == "ADMIN")
                    {


                        if (txt_username.Text == "Admin" && txt_userpasword.Text == "admin") 
                        {
                            username = txt_username.Text;
                            user_password = txt_userpasword.Text;

                            ProductManager prod = new ProductManager();
                            prod.Show();
                            this.Hide();

                        }
                        else
                        {
                            MessageBox.Show(" invalid login ");
                            txt_username.Clear();
                            txt_userpasword.Clear();

                            txt_username.Focus();
                        }
                    }

                    else  if  (RoleCb.SelectedItem.ToString() == "ATTENDANT")

                    {
                        MessageBox.Show(" You are an Attendant");
                        ProductManager prod = new ProductManager();
                        prod.Show();
                        this.Hide();
                    }

                }
               
            }
            catch
            {
                MessageBox.Show("");
            }
            finally
            {
                Con.Close();
            }
                
        }

        private void label6_Click(object sender, EventArgs e)
        {
            txt_username.Clear();
            txt_userpasword.Clear();

            txt_username.Focus();
        }
    }

}