using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TeknikServis.Formlar
{
    public partial class FrmSatislar : Form
    {
        public FrmSatislar()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        void listele()
        {
            var degerler = from x in db.TBLURUNSATISs
                           select new
                           {
                               x.HAREKETID,
                               x.TBLURUN.AD,
                               x.URUNSERINO,
                               MÜŞTERİ = x.TBLMUSTERI.AD + " " + x.TBLMUSTERI.SOYAD,
                               PERSONEL = x.TBLPERSONEL.AD + " " + x.TBLPERSONEL.SOYAD,
                               x.TARIH,
                               x.ADET
                               
                           };
            gridControl1.DataSource = degerler.ToList();
        }
        private void FrmSatislar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
