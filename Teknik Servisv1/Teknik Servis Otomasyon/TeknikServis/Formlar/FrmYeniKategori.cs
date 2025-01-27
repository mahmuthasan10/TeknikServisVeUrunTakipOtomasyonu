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
    public partial class FrmYeniKategori : Form
    {
        public FrmYeniKategori()
        {
            InitializeComponent();
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            if (txtad.Text != "" && txtad.Text.Length <= 30)
            {
                TBLKATEGORI t = new TBLKATEGORI();
                t.AD = txtad.Text;
                db.TBLKATEGORIs.Add(t);
                db.SaveChanges();
                MessageBox.Show("Kategori Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Kategori ad boş geçilemez ve 30 karakterden fazla olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
       

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

        private void Btntemizle_Click(object sender, EventArgs e)
        {
            txtad.Text = "";
        }
    }
}
