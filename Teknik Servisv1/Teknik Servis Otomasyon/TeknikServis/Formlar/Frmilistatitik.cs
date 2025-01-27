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

namespace TeknikServis.Formlar
{
    public partial class Frmilistatitik : Form
    {
        public Frmilistatitik()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        SqlConnection baglanti = new SqlConnection(@"Data Source=DESKTOP-6A1L86K;Initial Catalog=DBTEKNIKSERVIS;Integrated Security=True");
        private void Frmilistatitik_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = db.TBLMUSTERIs.OrderBy(x => x.TBLIL.IL).GroupBy(y => y.TBLIL.IL).Select(z => new
            {
                IL = z.Key,
                Toplam = z.Count()
            }).ToList();

            
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select IL,count(*) from TBLMUSTERI group by IL", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            baglanti.Close();
            

    
        }
    }
}
