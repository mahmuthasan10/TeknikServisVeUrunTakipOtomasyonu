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
    public partial class FrmArizaliUrunKaydi : Form
    {
        public FrmArizaliUrunKaydi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmArizaliUrunKaydi_Load(object sender, EventArgs e)
        {
            lookUpserino.Properties.NullText = "SeriNo Seçiniz.";
            /*
            lookUpserino.Properties.DataSource = (from i in db.TBLURUNSATISs
                                                   select new
                                                   {
                                                       i.HAREKETID,
                                                       i.URUNSERINO
                                                       
                                                   }).ToList(); */

            lookUpserino.Properties.DataSource = (from i in db.TBLURUNSATISs
                                                  where !(from j in db.TBLURUNARIZAs
                                                          select j.URUNSATIS).Contains(i.HAREKETID)
                                                  select new
                                                  {
                                                      i.HAREKETID,
                                                      i.URUNSERINO
                                                  }).ToList();

        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {

            if (lookUpserino.EditValue==null || txttarih.Text== "______")
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLURUNARIZA t = new TBLURUNARIZA();
                t.GELISTARIH = DateTime.Parse(txttarih.Text);
                t.URUNSATIS = int.Parse(lookUpserino.EditValue.ToString());
                t.DURUM = "Ürün Kaydoldu.";
                t.ACIKLAMA = "Müşteri Arızalı Ürünü Teslim Etti. Arıza İşlemi Başarıyla Başlamıştır.";
                db.TBLURUNARIZAs.Add(t);
                db.SaveChanges();
                MessageBox.Show("Arızalı Ürün Kaydı Yapıldı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

      

        private void txttarih_Click_1(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            lookUpserino.EditValue = null;
            txttarih.Text = "______";
        }
    }
}
