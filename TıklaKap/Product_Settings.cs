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
    public partial class Product_Settings : BaseForm
    {
        public Product_Settings()
        {
            InitializeComponent();
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

        private void PicClear_Click(object sender, EventArgs e)
        {
            TxtID.Text = " ";
            TxtProductName.Text = " ";
            TxtBrand.Text = "";
            CmbCategory.Text = "";
            TxtPrice.Text = "";
            TxtStock.Text = "";
            Txtİnformation.Text = "";
        }
        private void Product_Settings_Load(object sender, EventArgs e)
        {
            var kategoriler = (from x in db.TBLKATEGORI
                               select new
                               {
                                   x.ID,
                                   x.ad
                               }
                               ).ToList();
            CmbCategory.ValueMember = "ID";
            CmbCategory.DisplayMember = "ad";
            CmbCategory.DataSource = kategoriler;
            liste();
        }
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        void liste()
        {
            dataGridView1.DataSource = (from x in db.TBLURUN
                                        select new
                                        {
                                            x.ID,
                                            x.UrunAd,
                                            x.Marka,
                                            x.Stok,
                                            x.Fıyat,
                                            x.TBLKATEGORI.ad,
                                            x.Durum
                                        }).ToList();
        }
        private void PicList_Click(object sender, EventArgs e)
        {
            liste();
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            TBLURUN t = new TBLURUN();
            t.UrunAd = TxtProductName.Text;
            t.Marka = TxtBrand.Text;
            t.Stok = short.Parse(TxtStock.Text);
            t.Kategorı = int.Parse(CmbCategory.SelectedValue.ToString());
            t.Fıyat = decimal.Parse(TxtPrice.Text);
            t.Durum = true;
            db.TBLURUN.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void PicDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBLURUN.Find(x);
            db.TBLURUN.Remove(urun);
            db.SaveChanges();
            MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            liste();
        }

        private void PicUpdate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var urun = db.TBLURUN.Find(x);
            urun.UrunAd = TxtProductName.Text;
            urun.Stok = short.Parse(TxtStock.Text);
            urun.Marka = TxtBrand.Text;
            urun.Kategorı = int.Parse(CmbCategory.SelectedValue.ToString());
            urun.Fıyat = decimal.Parse(TxtPrice.Text);
            urun.Durum = bool.Parse(Txtİnformation.Text.ToString());
            db.SaveChanges();
            MessageBox.Show("Ürün Güncellendi","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            liste();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtProductName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtBrand.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtStock.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            TxtPrice.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            Txtİnformation.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            CmbCategory.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
