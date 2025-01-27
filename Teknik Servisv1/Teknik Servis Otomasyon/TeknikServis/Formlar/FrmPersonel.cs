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
    public partial class FrmPersonel : Form
    {
        public FrmPersonel()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        void listele()
        {
            var degerler = from u in db.TBLPERSONELs
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.SOYAD,
                               u.MAIL,
                               u.TELEFON,
                               u.TC
                           };
            gridControl1.DataSource = degerler.ToList();
            
        }
        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            txttelefon.Text = "";
            txtmail.Text = "";
            txttc.Text = "";
           
        }
        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Personeli Seçmediniz Gridin Üzerine Basıp Personeli Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(txtid.Text);
                var deger = db.TBLPERSONELs.Find(id);
                deger.AD = txtad.Text;
                deger.SOYAD = txtsoyad.Text;
                deger.TELEFON = txttelefon.Text;
                deger.MAIL = txtmail.Text;
                deger.TC = txttc.Text;
                db.SaveChanges();
                MessageBox.Show("Personel Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Personeli Seçmediniz Gridin Üzerine Basıp Personeli Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult secim = new DialogResult();
                secim = MessageBox.Show("Personel Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secim == DialogResult.Yes)
                {
                    int id = int.Parse(txtid.Text);
                    var deger = db.TBLPERSONELs.Find(id);
                    db.TBLPERSONELs.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Personel Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            listele();
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
                txttc.Text = gridView1.GetFocusedRowCellValue("TC").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Hata");
            }
        }
    }
}
