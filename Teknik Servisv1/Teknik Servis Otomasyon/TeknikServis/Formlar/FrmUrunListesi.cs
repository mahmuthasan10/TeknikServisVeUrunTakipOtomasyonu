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
    public partial class FrmUrunListesi : Form
    {
        public FrmUrunListesi()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        void listele()
        {
            var degerler = from u in db.TBLURUNs
                           select new
                           {
                               u.ID,
                               u.AD,
                               u.MARKA,
                               KATEGORI=u.TBLKATEGORI.AD,
                               u.STOK,
                               u.ALISFIYAT,
                               u.SATISFIYAT
                           };
            gridControl1.DataSource = degerler.ToList();
            lookUpEdit1.Properties.DataSource = (from x in db.TBLKATEGORIs
                                                 select new
                                                 {
                                                     x.ID,
                                                     x.AD
                                                 }).ToList();
        }
        void temizle()
        {
            txtalısf.Text = "";
            txtmarka.Text = "";
            txtsatısf.Text = "";
            txtstok.Text = "";
            txtad.Text = "";
            txtid.Text = "";
            lookUpEdit1.EditValue = null;
        }
        private void FrmUrunListesi_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Kategori Seçiniz...";
            listele();
            temizle();


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
                txtmarka.Text = gridView1.GetFocusedRowCellValue("MARKA").ToString();
                txtalısf.Text = gridView1.GetFocusedRowCellValue("ALISFIYAT").ToString();
                txtsatısf.Text = gridView1.GetFocusedRowCellValue("SATISFIYAT").ToString();
                txtstok.Text = gridView1.GetFocusedRowCellValue("STOK").ToString();
                lookUpEdit1.Text = gridView1.GetFocusedRowCellValue("KATEGORI").ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Seçmiş olduğunuz ürünün kategorisi silinmiş günceleme işlemi yapın.");
            }
            
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {
            listele();
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Ürünü Seçmediniz Gridin Üzerine Basıp Ürünü Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult secim = new DialogResult();
                secim = MessageBox.Show("Ürün Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secim == DialogResult.Yes)
                {
                    int id = int.Parse(txtid.Text);
                    var deger = db.TBLURUNs.Find(id);
                    db.TBLURUNs.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Ürün Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    listele();
                }
                else
                {
                    listele();
                }
            }
           

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtid.Text=="")
            {
                MessageBox.Show("Ürünü Seçmediniz Gridin Üzerine Basıp Ürünü Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(txtid.Text);
                var deger = db.TBLURUNs.Find(id);
                deger.AD = txtad.Text;
                deger.STOK = int.Parse(txtstok.Text);
                deger.MARKA = txtmarka.Text;
                deger.ALISFIYAT = decimal.Parse(txtalısf.Text);
                deger.SATISFIYAT = decimal.Parse(txtsatısf.Text);
                deger.KATEGORI = int.Parse(lookUpEdit1.EditValue.ToString());
                db.SaveChanges();
                MessageBox.Show("Ürün Başarıyla Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
           
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}
