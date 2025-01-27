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
    public partial class FrmYeniUrun : Form
    {
        public FrmYeniUrun()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtalısf.Text == "" || txtsatısf.Text == "" || txtstok.Text == "" || txtmarka.Text=="" || lookUpEdit1.EditValue == null)
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLURUN t = new TBLURUN();
                t.AD = txtad.Text;
                t.ALISFIYAT = decimal.Parse(txtalısf.Text);
                t.SATISFIYAT = decimal.Parse(txtsatısf.Text);
                t.STOK = int.Parse(txtstok.Text);
                t.MARKA = txtmarka.Text;
                t.KATEGORI = int.Parse(lookUpEdit1.EditValue.ToString());
                db.TBLURUNs.Add(t);
                db.SaveChanges();
                MessageBox.Show("Ürün Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }



        }

        private void FrmYeniUrun_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir Kategori Seçiniz...";
            lookUpEdit1.Properties.DataSource = (from u in db.TBLKATEGORIs
                                                 select new
                                                 {
                                                     u.ID,
                                                     u.AD
                                                 }).ToList();
                                                            
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Tuşu iptal et
            }
        }

        private void txtmarka_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true; // Tuşu iptal et
            }
        }

        private void txtalısf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu iptal et
            }
        }

        private void txtsatısf_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu iptal et
            }
        }

        private void txtstok_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu iptal et
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtad.Text = "";
            txtalısf.Text = "";
            txtmarka.Text = "";
            txtsatısf.Text = "";
            txtstok.Text = "";
            lookUpEdit1.EditValue = null;
        }
    }
}
