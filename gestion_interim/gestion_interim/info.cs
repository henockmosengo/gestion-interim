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
    public partial class info : Form

    {
        MySqlConnection cn = new MySqlConnection("datasource = localhost; port=3306; database=rva_interim; UID=root;pwd=");
        MySqlCommand cmd;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Bunifu.Framework.UI.BunifuCustomDataGrid dtgvtout;
        MySqlDataReader dr;
        public info()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void info_Load(object sender, EventArgs e)
        {
            cn.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT Direction,Division ,Service,Bureau,nom,postnom,code_interim,duree,debut,fin FROM direction,division,service,bureau,agent,interim   ", cn);
            DataTable dtbl = new DataTable();
            da.Fill(dtbl);
            dtgvtout.DataSource = dtbl;
            cn.Close();

            //INFO G
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

        private void InitializeComponent()
        {
           

        }

        private void info_Load_1(object sender, EventArgs e)
        {

        }
    }
}
