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
    public partial class FrmArizaGuncelleme : Form
    {
        public FrmArizaGuncelleme()
        {
            InitializeComponent();
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmArizaDetaylari_Load(object sender, EventArgs e)
        {

            
            lookUpserino.Properties.NullText = "SeriNo Seçiniz.";
            
            lookUpserino.Properties.DataSource = (from i in db.TBLURUNARIZAs
                                                  select new
                                                  {
                                                     
                                                      i.ISLEMID,
                                                      i.TBLURUNSATIS.URUNSERINO
                                                  }).ToList();
                                                  
           
        }
        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (lookUpserino.EditValue==null || txttarih.Text== "______" || comboBox1.Text=="")
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (comboBox1.Text == "Arıza Tamamlandı (Arızalı Ürün Silinir)")
                {
                    var id = lookUpserino.EditValue;
                    var deger = db.TBLURUNARIZAs.Find(id);
                    db.TBLURUNARIZAs.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Arıza İşlemi Başarıyla Tamamlandı.(Arıza Listesinden Silinmiştir)", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    var id = lookUpserino.EditValue;
                    var deger = db.TBLURUNARIZAs.Find(id);
                    deger.DURUM = comboBox1.Text;
                    deger.ACIKLAMA = richTextBox1.Text;
                    deger.GELISTARIH = DateTime.Parse(txttarih.Text);
                    db.SaveChanges();

                    MessageBox.Show("Arıza Detayları Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
            comboBox1.Text = "";
            richTextBox1.Text = "";
        }

        
    }
}
