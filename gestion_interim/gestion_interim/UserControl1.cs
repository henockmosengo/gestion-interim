using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace gestion_interim
{
    public partial class UserControl1 : UserControl
    {
        MySqlConnection cn = new MySqlConnection("datasource = localhost; port=3306; database=rva_interim; UID=root;pwd=");
        MySqlCommand cmd;
        MySqlDataReader dr;
        public UserControl1()
        {
            InitializeComponent();
        }
                            //agent
        private void btnannuler1_Click(object sender, EventArgs e)
        {
            txtmatri.Text = "";
            txtnom.Text = "";
            txtpnom.Text = "";
            txtdtenr.Text = "";
            txttel.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            cmbbureau.Text = "";

        }

        private void btnsuprimer1_Click(object sender, EventArgs e)
        {
            //sup agent
            cn.Open();
            cmd = new MySqlCommand("DELETE * FROM `agent` WHERE matricule='" + txtmatricul.Text + "' ", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer");

        }

        private void btnmodifier1_Click(object sender, EventArgs e)
        {
            // mod agent
            cn.Open();
            cmd = new MySqlCommand("UPDATE `agent` SET `matricule`='" + txtmatri.Text + "',`nom`='" + txtnom.Text + "',`postnom`='" + txtpnom.Text + "',`date_inscrit`='" + txtdtenr.Text + "',`telephone`='" + txttel.Text + "',`code_bureau`='" + cmbbureau.Text + "' WHERE '" + txtmatricul.Text + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("la modification effectuer");
            txtmatri.Text = "";
            txtnom.Text = "";
            txtpnom.Text = "";
            txtdtenr.Text = "";
            txttel.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            cmbbureau.Text = "";

        }

        private void btnvalider1_Click(object sender, EventArgs e)
        {
            // new agent
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `agent`(`matricule`, `nom`, `postnom`, `date_inscrit`, `telephone`, `code_bureau`) VALUES  ('" + txtmatri.Text + "','" + txtnom.Text + "','" + txtpnom.Text + "','" + txtdtenr.Text + "','" + txttel.Text + "','" + cmbbureau.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(" Agent inscrit merci");
            UserControl1_Load(sender, e);

            txtmatri.Text = "";
            txtnom.Text = "";
            txtpnom.Text = "";
            txtdtenr.Text = "";
            txttel.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            cmbbureau.Text = "";
        }
                        //interime
        private void btnannuler2_Click(object sender, EventArgs e)
        {
            txtduree.Text = "";
            txtcdinterim.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            txtmatricul.Text = "";
            cmbfonction.Text = "";
        }

        private void btnsuprimer2_Click(object sender, EventArgs e)
        {
            //sup interim
            cn.Open();
            cmd = new MySqlCommand("DELETE * FROM `interim` WHERE code_interim='" + txtcdinterim.Text + "' ", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer");
            UserControl1_Load(sender, e);
        }

        private void btnmodifier2_Click(object sender, EventArgs e)
        {
            // mod interim
            cn.Open();
            cmd = new MySqlCommand("UPDATE `interim` SET `code_interim`='" + txtcdinterim.Text + "',`duree`='" + txtduree.Text + "',`debut`='" + txtdtdebut.Text + "',`fin`='" + txtdtfin.Text + "',`matricule`='" + txtmatricul.Text + "',`code_fonction`='" + cmbfonction.Text + "' WHERE code_interim`='" + txtcdinterim.Text + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("la modification effectuer");
            txtduree.Text = "";
            txtcdinterim.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            txtmatricul.Text = "";
            cmbfonction.Text = "";
            UserControl1_Load(sender, e);
        }

        private void btnvalider2_Click(object sender, EventArgs e)
        {
            // new interim
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `interim`(`code_interim`, `duree`, `debut`, `fin`, `matricule`, `code_fonction`) VALUES ('" + txtcdinterim.Text + "','" + txtduree.Text + "','" + txtdtdebut.Text + "','" + txtdtfin.Text + "','" + txtmatricul.Text + "','" + cmbfonction.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(" Intérimaire inscrit merci");
            UserControl1_Load(sender, e);

            txtduree.Text = "";
            txtcdinterim.Text = "";
            txtdtdebut.Text = "";
            txtdtfin.Text = "";
            txtmatricul.Text = "";
            cmbfonction.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // new fonction
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `fonction`(`code_fonction`, `libelle`) VALUES ('" + txtcdfonct.Text + "','" + txtfonct.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(" fonction inscrit merci");
            UserControl1_Load(sender, e);
            txtcdfonct.Text = "";
            txtfonct.Text = "";
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            // dtgvinterim
            cn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM interim ", cn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dtgvinterim.DataSource = dtbl;
            cn.Close();
            //dtgv agent
            cn.Open();
            MySqlDataAdapter da1 = new MySqlDataAdapter("SELECT * FROM `agent` ", cn);
            DataTable dtbl1 = new DataTable();
            da1.Fill(dtbl1);
            dtgvagent.DataSource = dtbl1;
            cn.Close();

            // cmb bureau
            cn.Open();
            cmbbureau.Items.Clear();
            cmbbureau.Items.Add("code_bureau");
            cmd = new MySqlCommand("SELECT `code_bureau` from bureau", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbbureau.Items.Add(dr[0]);
            }
            cn.Close();
            //cmb fonction
            cn.Open();
            cmbfonction.Items.Clear();
            cmbfonction.Items.Add("code_fonction");
            cmd = new MySqlCommand("SELECT `code_fonction` from fonction", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbfonction.Items.Add(dr[0]);
            }
            cn.Close();

            //footer
            cn.Open();
            cmd = new MySqlCommand("SELECT nom,postnom,code_interim,code_fonction from agent,interim ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                string snom = dr.GetString("nom");
                string sprenom = dr.GetString("postnom");
                string scode = dr.GetString("code_interim");
                string sfonction = dr.GetString("code_fonction");
                nom.Text = snom;
                prenom.Text = sprenom;
                code.Text = scode;
                fonction.Text = sfonction;
            }
            cn.Close();
        }

        private void bunifuCustomLabel22_Click(object sender, EventArgs e)
        {
 
        }
        
    }
}
