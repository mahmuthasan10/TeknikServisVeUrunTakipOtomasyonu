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
    public partial class FrmYeniPersonel : Form
    {
        public FrmYeniPersonel()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void btnekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text == "" || txtsoyad.Text == "" || txttel.Text == "" || txtmail.Text == "" || txttc.Text=="")
            {
                MessageBox.Show("Lütfen Bilgileri Eksiksiz Giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                TBLPERSONEL t = new TBLPERSONEL();
                t.AD = txtad.Text;
                t.SOYAD = txtsoyad.Text;
                t.MAIL = txtmail.Text;
                t.TC = txttc.Text;
                t.TELEFON = txttel.Text;
                db.TBLPERSONELs.Add(t);
                db.SaveChanges();
                MessageBox.Show("Personel Başarıyla Eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            txtmail.Text = "";
            txttc.Text = "";
            txttel.Text = "";
            
        }
    }
}
