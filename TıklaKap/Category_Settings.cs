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
    public partial class Category_Settings : Form
    {
        public Category_Settings()
        {
            InitializeComponent();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        void list()
        {
            var kategoriler = db.TBLKATEGORI.ToList();
            dataGridView1.DataSource = kategoriler;
        }
        private void PicList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            TBLKATEGORI t = new TBLKATEGORI();
            t.ad = TxtCatName.Text;
            db.TBLKATEGORI.Add(t);
            db.SaveChanges();
            MessageBox.Show("Kategori Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void PicDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var ktg = db.TBLKATEGORI.Find(x);
            db.TBLKATEGORI.Remove(ktg);
            db.SaveChanges();
            MessageBox.Show("Kategori Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void PicUpdate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var ktg = db.TBLKATEGORI.Find(x);
            ktg.ad = TxtCatName.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            General gn = new General();
            gn.Show();
            this.Hide();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtCatName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
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
