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
    public partial class Frmİstatisitk : Form
    {
        public Frmİstatisitk()
        {
            InitializeComponent();
        }
        DBTEKNIKSERVISEntities db = new DBTEKNIKSERVISEntities();
        private void Frmİstatisitk_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLURUNs.Count().ToString();
            label3.Text = db.TBLKATEGORIs.Count().ToString();
            label5.Text = db.TBLURUNs.Sum(x => x.STOK).ToString();
            label7.Text = (from x in db.TBLURUNs
                           select x.MARKA).Distinct().Count().ToString();
            label15.Text = (from x in db.TBLURUNs
                            orderby x.STOK descending
                            select x.AD).FirstOrDefault();
            label13.Text = (from x in db.TBLURUNs
                            orderby x.STOK ascending
                            select x.AD).FirstOrDefault();
            label9.Text= (from x in db.TBLURUNs
                          orderby x.SATISFIYAT descending
                          select x.AD).FirstOrDefault();
            label19.Text = (from x in db.TBLURUNs
                           orderby x.SATISFIYAT ascending
                           select x.AD).FirstOrDefault();
            label23.Text = db.TBLURUNARIZAs.Count().ToString();
            label17.Text = db.TBLURUNSATISs.Count().ToString();
            label11.Text = db.TBLMUSTERIs.Count().ToString();
            label21.Text = db.TBLPERSONELs.Count().ToString();
        }
    }
}
