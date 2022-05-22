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
    public partial class Form1 : Form
    {
        MySqlConnection cn = new MySqlConnection("datasource = localhost; port=3306; database=authentique; UID=root;pwd=");
        MySqlCommand cmd;
        MySqlDataReader dr;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            cn.Open();
            // chargement de combobox
                                      // chargement de la combobox service du bureau
            cmbservice.Items.Clear();
           // cmbservice.Items.Add("code_service");
            cmd = new MySqlCommand("select code_service,Service from service", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbservice.Items.Add(dr[0]);
            }
            cn.Close();

                                     //  chargement de la combobox bureau
            cn.Open();
            cmbdivision.Items.Clear();
            cmbdivision.Items.Add("code_division");
            cmd = new MySqlCommand("select `code_division` from service", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdivision.Items.Add(dr[0]);
            }
            cn.Close();
                                     //  chargement de la combobox direction de la division
            cn.Open();
            cmbdirection.Items.Clear();
            cmbdirection.Items.Add("code_direction");
            cmd = new MySqlCommand("select code_direction from division", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cmbdirection.Items.Add(dr[0]);
            }
            cn.Close();
                                          // chargement de dtgv
            /*
             cn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM direction,division,service,bureau   ", cn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dtgv.DataSource = dtbl;
           */
            cn.Open();
             cmd = new MySqlCommand("SELECT Direction,Division ,Service,bureau FROM direction,division,service,bureau  ", cn);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dtgv.Rows.Add(dr[0], dr[1], dr[2],dr[3]);
            }
            cn.Close();

            txtbureau.Text = "";
            txtcdbureau.Text = "";
           

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnenr1_Click(object sender, EventArgs e)
        {
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `bureau`(`code_bureau`, `Bureau`, `code_service`) VALUES ('"+txtcdbureau.Text+"','"+txtbureau.Text+"','"+cmbservice.Text+"')",cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("bureau inscrit merci");
            Form1_Load(sender,e);
            txtcdbureau.Text = "";
            txtbureau.Text = "";
            cmbservice.Text = "";
        }

        private void btnann1_Click(object sender, EventArgs e)
        {
            txtcdbureau.Text = "";
            txtbureau.Text = "";
            cmbservice.Text = "";

        }

        private void btnann2_Click(object sender, EventArgs e)
        {
            txtservice.Text = "";
            txtservice.Text = "";
            cmbdivision.Text = "";
        }

        private void btnann3_Click(object sender, EventArgs e)
        {
            txtcddivision.Text = "";
            txtdivision.Text = "";
            cmbdirection.Text = "";
        }

        private void btnann4_Click(object sender, EventArgs e)
        {
            txtcddirection.Text = "";
            txtdirection.Text = "";
        }

        private void btnmod1_Click(object sender, EventArgs e)
        {
            //modification bureau
         
            cn.Open();
            cmd = new MySqlCommand("UPDATE `bureau` SET `code_bureau`='" + txtcdbureau.Text + "',`Bureau`='" + txtbureau.Text + "',`code_service`='" + cmbservice.Text + "' WHERE `code_bureau`='" + txtbureau.Text + "' ", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("modification reuci merci");
            Form1_Load(sender, e);
            txtcdbureau.Text = "";
            txtbureau.Text = "";
            cmbservice.Text = "";
           
        }

        private void dtgv_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            // modifier bureau via dtgv
            txtcdbureau.Text = "";
            txtbureau.Text = "";

            int i = e.RowIndex;

            txtcdbureau.Text = dtgv.Rows[i].Cells[0].Value.ToString();
            txtbureau.Text = dtgv.Rows[i].Cells[1].Value.ToString();

            
        }

        private void btnsup1_Click(object sender, EventArgs e)
        {
            // btn suprimer bureau
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM `bureau` WHERE code_bureau='"+txtcdbureau+"'",cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer merci pour la commend");
        }

        private void btnsup2_Click(object sender, EventArgs e)
        {
            //btn sup service
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM `service` WHERE code_service='" + txtcdservice + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer merci pour la commend");
        }

        private void btnmod2_Click(object sender, EventArgs e)
        {
            //btn mod service
            cn.Open();
            cmd = new MySqlCommand("UPDATE `service` SET `code_service`='" + txtcdservice.Text + "',`Service`='" + txtservice.Text + "',`code_division`='" + cmbdivision + "' WHERE `code_service`='" + txtcdservice.Text + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("modification reuci merci");
            Form1_Load(sender, e);
            txtservice.Text = "";
            txtservice.Text = "";
            cmbdivision.Text = "";
        }

        private void btnenr2_Click(object sender, EventArgs e)
        {
            //btn enr service
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `service`(`code_service`, `Service`, `code_division`) VALUES ('" + txtcdservice.Text + "','" + txtservice.Text + "','" + cmbdivision.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Service inscrit merci");
            Form1_Load(sender, e);
            txtservice.Text = "";
            txtservice.Text = "";
            cmbdivision.Text = "";
        }

        private void btnsup3_Click(object sender, EventArgs e)
        {
            //btn sup division
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM `division` WHERE code_division='" + txtcddivision + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer merci pour la commend");
        }

        private void btnmod3_Click(object sender, EventArgs e)
        {
            //btn mod division
            cn.Open();
            cmd = new MySqlCommand("UPDATE `division` SET `code_division`='" + txtcddivision.Text + "',`Division`='" + txtdivision.Text + "',`code_direction`='" + cmbdirection.Text + "' WHERE `code_division`='" + txtcddivision.Text + "' ", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("modification reuci merci");
            Form1_Load(sender, e);
            txtcddivision.Text = "";
            txtdivision.Text = "";
            cmbdirection.Text = "";
        }

        private void btnenr3_Click(object sender, EventArgs e)
        {
            //btn enr division
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `division`(`code_division`, `Division`, `code_direction`) VALUES ('" + txtcddivision.Text + "','" + txtdivision.Text + "','" + cmbdirection.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Division inscrit merci");
            Form1_Load(sender, e);
            txtcddivision.Text = "";
            txtdivision.Text = "";
            cmbdirection.Text = "";
        }

        private void btnsup4_Click(object sender, EventArgs e)
        {
            //btn sup direction
            cn.Open();
            cmd = new MySqlCommand("SELECT * FROM `direction` WHERE code_direction='" + txtcddirection + "'", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("supression effectuer merci pour la commend");
        }

        private void btnmod4_Click(object sender, EventArgs e)
        {
            //btn mod direction
            cn.Open();
            cmd = new MySqlCommand("UPDATE `direction` SET `code_direction`='" + txtcddirection.Text + "',`Direction`='" + txtdirection.Text + "' WHERE `code_direction`='" + txtcddirection.Text + "' ", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("modification reuci merci");
            Form1_Load(sender, e);
            txtcddirection.Text = "";
            txtdirection.Text = "";
        }

        private void btnenr4_Click(object sender, EventArgs e)
        {
            // btn enr direction
            cn.Open();
            cmd = new MySqlCommand("INSERT INTO `direction`(`code_direction`, `Direction`) VALUES ('" + txtcddirection.Text + "','" + txtdirection.Text + "')", cn);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show("Direction inscrit merci");
            Form1_Load(sender, e);
            txtcddirection.Text = "";
            txtdirection.Text = "";
        }

        private void btninfo_Click(object sender, EventArgs e)
        {
            
        }

        private void btninterim_Click(object sender, EventArgs e)
        {
            bunifuTransition1.ShowSync(userControl11);
        }

        private void btnindex_Click(object sender, EventArgs e)
        {
            userControl11.Visible = false;
        }

        private void txtrecherch_OnTextChange(object sender, EventArgs e)
        {
         
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            
            cn.Open();
            dtgv.Rows.Clear();
            cmd = new MySqlCommand("SELECT Direction,Division ,Service,Bureau FROM direction,division,service,bureau WHERE Bureau='"+txtrecherch.Text+"'", cn);
            dr = cmd.ExecuteReader();
            
            while (dr.Read())
            {
                dtgv.Rows.Add(dr[0], dr[1], dr[2], dr[3]);
            }
            cn.Close();
            Form1_Load(sender, e);

                  txtrecherch.text = "";
              
         
        }
      
    }
}
