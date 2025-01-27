using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
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
    public partial class FrmArizaListesi : Form
    {
        public FrmArizaListesi()
        {
            InitializeComponent();
        }
        void listele()
        {
            gridView1.OptionsView.ColumnAutoWidth = false;
            var degerler = from x in db.TBLURUNARIZAs
                           select new
                           {
                               x.ISLEMID,
                               SERİNO=x.TBLURUNSATIS.URUNSERINO,
                               TARİH=x.GELISTARIH,
                               x.DURUM,
                               AÇIKLAMA=x.ACIKLAMA
                           };
            
           

            gridControl1.DataSource = degerler.ToList();

        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmArizaListesi_Load(object sender, EventArgs e)
        {
            
            listele();
            gridView1.OptionsView.ColumnAutoWidth = false;
            gridView1.Columns["ISLEMID"].Width = 100;
            gridView1.Columns["SERİNO"].Width = 100;
            gridView1.Columns["TARİH"].Width = 150;
            gridView1.Columns["DURUM"].Width = 250;
            gridView1.Columns["AÇIKLAMA"].Width = 900;


        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }
    }
}
