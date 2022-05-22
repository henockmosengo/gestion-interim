using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gestion_interim
{
    public partial class login : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource = localhost; port=3306; database=authentique; UID=root;pwd=");
        MySqlCommand cmd;
        MySqlDataReader dr;
        public login()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            tras.ShowSync(panel2);
            pictureBox2.Visible = false;
            
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            //validation du button login
            int i = 0;
            cn.Open();
            MySqlCommand cmd = cn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM `login` WHERE nom='" + txtid.Text + "' and mdp='" + txtmdp.Text + "' ";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());
            if (i == 0)
            {
                MessageBox.Show(" identifiant et mot de pass invalide");
            }
            else
            {
                Form Form1 = new Form1();
                Form1.Show();
                this.Hide();
            }
            cn.Close();
        }

        private void btnannuler2_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtmdp_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void txtid_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            tras.HideSync(panel2);
            pictureBox2.Visible = true;
        }

        private void btnvalider1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd =  new MySqlCommand("UPDATE `login` SET   `nom`='" + txtid.Text + "' , mdp='" + txtmdp.Text + "' where id=1 ",cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("la modification effectuer");
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
