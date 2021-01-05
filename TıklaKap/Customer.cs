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
    public partial class Customer : BaseForm
    {
        DbEntityUrunEntities db = new DbEntityUrunEntities();
        void list()
        {
            var musteri = db.TBLMUSTERI.ToList();
            dataGridView1.DataSource = musteri;
        }
        public Customer()
        {
            InitializeComponent();
        }

        private void Customer_Load(object sender, EventArgs e)
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

        private void PicList_Click(object sender, EventArgs e)
        {
            list();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            TxtCusName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtCusSurname.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtCusCity.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
        }

        private void PicAdd_Click(object sender, EventArgs e)
        {
            TBLMUSTERI cus = new TBLMUSTERI();
            cus.MusterıAd = TxtCusName.Text;
            cus.MusterıSoyad = TxtCusSurname.Text;
            cus.MusterıSehır = TxtCusCity.Text;
            cus.Durum = true;
            db.TBLMUSTERI.Add(cus);
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarıyla Eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void PicDelete_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var cust = db.TBLMUSTERI.Find(x);
            db.TBLMUSTERI.Remove(cust);
            db.SaveChanges();
            MessageBox.Show("Müşteri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }

        private void PicUpdate_Click(object sender, EventArgs e)
        {
            int x = Convert.ToInt32(TxtID.Text);
            var cust = db.TBLMUSTERI.Find(x);
            cust.MusterıAd = TxtCusName.Text;
            cust.MusterıSoyad = TxtCusSurname.Text;
            cust.MusterıSehır = TxtCusCity.Text;
            db.SaveChanges();
            MessageBox.Show("Güncelleme Yapıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            list();
        }
    }
}
