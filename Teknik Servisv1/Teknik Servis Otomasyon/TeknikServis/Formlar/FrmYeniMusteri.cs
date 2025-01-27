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
    public partial class FrmYeniMusteri : Form
    {
        public FrmYeniMusteri()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void FrmYeniMusteri_Load(object sender, EventArgs e)
        {
            lookUpEdit1.Properties.NullText = "Bir İl Seçiniz...";
            lookUpEdit1.Properties.DataSource = (from u in db.TBLILs
                                                 select new
                                                 {
                                                     u.ID,
                                                     u.IL
                                                 }).ToList();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text=="" || txtsoyad.Text=="" || txttel.Text=="" || txtmail.Text=="" || lookUpEdit1.EditValue==null)
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLMUSTERI t = new TBLMUSTERI();
                t.AD = txtad.Text;
                t.SOYAD = txtsoyad.Text;
                t.TELEFON = txttel.Text;
                t.MAIL = txtmail.Text;
                t.IL = int.Parse(lookUpEdit1.EditValue.ToString());
                db.TBLMUSTERIs.Add(t);
                db.SaveChanges();
                MessageBox.Show("Müşteri Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void btncikis_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            txtad.Text = "";
            txtsoyad.Text = "";
            txttel.Text = "";
            txtmail.Text = "";
            lookUpEdit1.EditValue = null;
        }
    }
}
