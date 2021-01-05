using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TıklaKap
{
    public partial class Stats : BaseForm
    {
        public Stats()
        {
            InitializeComponent();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            General gn = new General();
            gn.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        private void Stats_Load(object sender, EventArgs e)
        {
            label2.Text = db.TBLKATEGORI.Count().ToString();
            label3.Text = db.TBLURUN.Count().ToString() + " Adet";
            label5.Text = db.TBLMUSTERI.Count(x=>x.Durum==true).ToString();
            label7.Text = db.TBLMUSTERI.Count(x=>x.Durum==false).ToString();
            label9.Text = db.TBLURUN.Sum(x => x.Stok).ToString() + " Adet";
            label30.Text = db.TBLSATIS.Sum(z => z.Fiyat).ToString() + " TL";
            label15.Text = (from x in db.TBLURUN orderby x.Fıyat descending select x.UrunAd).FirstOrDefault();
            label13.Text = (from x in db.TBLURUN orderby x.Fıyat ascending select x.UrunAd).FirstOrDefault();
            label11.Text = db.TBLURUN.Count(x => x.Kategorı == 1).ToString();
            label17.Text = (from x in db.TBLMUSTERI select x.MusterıSehır).Distinct().Count().ToString();
            label19.Text = db.MARKAGETIR().FirstOrDefault();

        }

        private void anasayfaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            General gnr = new General();
            gnr.Show();
            this.Hide();
        }

        private void kategoriAyarlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Category_Settings ctg = new Category_Settings();
            ctg.Show();
            this.Hide();
        }

        private void ürünİşlemleriToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Settings prd = new Product_Settings();
            prd.Show();
            this.Hide();
        }

        private void istatistiklerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stats stat = new Stats();
            stat.Show();
            this.Hide();
        }
    }
}
