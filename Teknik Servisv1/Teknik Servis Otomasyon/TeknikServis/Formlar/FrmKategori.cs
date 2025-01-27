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
    public partial class FrmKategori : Form
    {
        public FrmKategori()
        {
            InitializeComponent();
        }
        void listele()
        {
            var degerler = from k in db.TBLKATEGORIs
                           select new
                           {
                               k.ID,
                               k.AD
                           };
            gridControl1.DataSource = degerler.ToList();
        }

        void temizle()
        {
            txtid.Text = "";
            txtad.Text = "";
        }

        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();

        private void FrmKategori_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Kategoriyi Seçmediniz Gridin Üzerine Basıp Kategoriyi Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                int id = int.Parse(txtid.Text);
                var deger = db.TBLKATEGORIs.Find(id);
                deger.AD = txtad.Text;
                db.SaveChanges();
                MessageBox.Show("Kategori Güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
            
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            if (txtid.Text == "")
            {
                MessageBox.Show("Kategoriyi Seçmediniz Gridin Üzerine Basıp Kategoriyi Seçiniz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DialogResult secim = new DialogResult();
                secim = MessageBox.Show("Kategori Silinsin Mi?", "Silme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (secim == DialogResult.Yes)
                {
                    int id = int.Parse(txtid.Text);
                    var deger = db.TBLKATEGORIs.Find(id);
                    db.TBLKATEGORIs.Remove(deger);
                    db.SaveChanges();
                    MessageBox.Show("Kategori Silindi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
            txtid.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
            txtad.Text = gridView1.GetFocusedRowCellValue("AD").ToString();
        }
    }
}
