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
    public partial class FrmMusteri : Form
    {
        public FrmMusteri()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        void listele()
        {
            var degerler = from u in db.TBLMUSTERIs
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                               İL=u.TBLIL.IL
                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLILs
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.IL
                                                 }).ToList();
        }
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txttelefon.Text = "";
            txtmail.Text = "";        
            lookUpEdit1.EditValue = null;
        }
        private void FrmMusteri_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir İl Seçiniz...";
            listele();
            temizle();
            
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Müşteriyi Seçmediniz Gridin Üzerine Basıp Müşteriyi Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(txtid.Text);
                var deger = db.TBLMUSTERIs.Find(id);
                deger.AD = txtad.Text;
                deger.SOYAD = txtsoyad.Text;
                deger.TELEFON = txttelefon.Text;
                deger.MAIL = txtmail.Text;
                deger.IL = int.Parse(lookUpEdit1.EditValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Müşteri Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

           
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Müşteriyi Seçmediniz Gridin Üzerine Basıp Müşteriyi Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult secim = new DialogResult();
                secim = MessageBox.Show("Müşteri Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secim == DialogResult.Yes)
                {
                    int id = int.Parse(txtid.Text);
                    var deger = db.TBLMUSTERIs.Find(id);
                    db.TBLMUSTERIs.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Müşteri Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                }
                else
                {
                    listele();
                }
            }
            
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                txtsoyad.Text = gridView1.GetFocusedRowCellValue("SOYAD").ToString();
                txtmail.Text = gridView1.GetFocusedRowCellValue("MAIL").ToString();
                txttelefon.Text = gridView1.GetFocusedRowCellValue("TELEFON").ToString();               
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("İL").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }
        }
    }
}
