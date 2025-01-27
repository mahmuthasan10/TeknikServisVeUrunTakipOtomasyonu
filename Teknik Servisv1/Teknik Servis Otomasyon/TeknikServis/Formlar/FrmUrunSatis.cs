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
    public partial class FrmUrunSatis : Form
    {
        public FrmUrunSatis()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        
        private void FrmUrunSatis_Load(object sender, EventArgs e)
        {
            lookUpmusteri.Properties.NullText = "Müşteri Seçiniz.";
            lookUppersonel.Properties.NullText = "Personel Seçiniz.";
            lookUpurun.Properties.NullText = "Ürün Seçiniz.";
            lookUpurun.Properties.DataSource = (from x in db.TBLURUNs
                                              select new
                                              {
                                                  x.ID,
                                                  x.AD
                                              }).ToList();

            lookUppersonel.Properties.DataSource = (from y in db.TBLPERSONELs
                                                 select new
                                                 {
                                                     y.ID,
                                                     AD = y.AD + " " + y.SOYAD
                                                 }).ToList();
            lookUpmusteri.Properties.DataSource = (from i in db.TBLMUSTERIs
                                             select new
                                             {
                                                 i.ID,
                                                 AD = i.AD + " " + i.SOYAD
                                             }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            var id = lookUpurun.EditValue;
            var deger = db.TBLURUNs.Find(id);
            int stok = int.Parse(txtadet.Text);
            
            if (txtadet.Text=="" || txtserino.Text=="" || txttarih.Text== "______" || lookUpmusteri.EditValue==null || lookUppersonel.EditValue==null || lookUpurun.EditValue==null)
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (deger.STOK == 0)
            {
                MessageBox.Show("Ürünün Stoğu Bittmiştir Stoğu Güncelleyiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (stok>deger.STOK)
            {
                MessageBox.Show("Ürünün Stoğundan fazla İstediniz Lütfen Stoğu Kontrol Ediniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLURUNSATIS u = new TBLURUNSATIS();
                u.ADET = int.Parse(txtadet.Text);
                u.MUSTERI = int.Parse(lookUpmusteri.EditValue.ToString());
                u.PERSONEL = short.Parse(lookUppersonel.EditValue.ToString());
                u.TARIH = DateTime.Parse(txttarih.Text);
                u.URUN = int.Parse(lookUpurun.EditValue.ToString());
                u.URUNSERINO = txtserino.Text;
                db.TBLURUNSATISs.Add(u);
                deger.STOK -= int.Parse(txtadet.Text);
                db.SaveChanges();
                MessageBox.Show("Yeni Satış Yapıldı Müşteriye Hayırlı Olsun !", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txttarih_Click_1(object sender, EventArgs e)
        {
            txttarih.Text = DateTime.Now.ToShortDateString();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtadet.Text = "";
            txtserino.Text = "";
            txttarih.Text = "______";
            lookUpmusteri.EditValue = null;
            lookUppersonel.EditValue = null;
            lookUpurun.EditValue = null;
        }

        private void txtadet_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu iptal et
            }
        }
    }
}
