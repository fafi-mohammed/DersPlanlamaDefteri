using DersProgramiApp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DersProgramiApp
{
    public partial class Form2 : Form
    {
        VeritabaniIslemleri db = new VeritabaniIslemleri();

        public Form2()
        {
            InitializeComponent();
         
        }

        private void ListeyiYenile()
        {
            lstDersler.Items.Clear();
            foreach (var ders in db.DersleriGetir())
            {
                lstDersler.Items.Add(ders); // doğrudan nesne eklendi
            }
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            Ders d;
            if (chkUygulamali.Checked)
            {
                d = new UygulamaliDers(
                    txtDersAdi.Text,
                    txtGun.Text,
                    txtSaat.Text,
                    txtLabNo.Text
                );
            }

            else
            {
                d = new Ders(
                    txtDersAdi.Text,
                    txtGun.Text,
                    txtSaat.Text
                );
            }

            db.DersEkle(d);
            MessageBox.Show("Ders eklendi.");
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            lstDersler.Items.Clear();
            foreach (var ders in db.DersleriGetir())
            {
                lstDersler.Items.Add(ders.BilgiVer());
            }

        }

        private void lstDersler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstDersler.SelectedItem is Ders secilen)
            {
                txtDersAdi.Text = secilen.DersAdi;
                txtGun.Text = secilen.Gun;
                txtSaat.Text = secilen.Saat;

                if (secilen is UygulamaliDers ud)
                {
                    chkUygulamali.Checked = true;
                    txtLabNo.Text = ud.LabNo;
                }
                else
                {
                    chkUygulamali.Checked = false;
                    txtLabNo.Clear();
                }
            }
        }

       
    }

}



