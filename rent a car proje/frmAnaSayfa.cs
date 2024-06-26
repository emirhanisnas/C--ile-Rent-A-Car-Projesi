﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rent_a_car_proje
{
    public partial class frmAnaSayfa : Form
    {
        public frmAnaSayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmMüsşteriEkle ekle = new frmMüsşteriEkle();
            ekle.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmAracKayıt kayıt = new frmAracKayıt();
            kayıt.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmMüşteriListele listele = new frmMüşteriListele();
            listele.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmAraçListele listele = new frmAraçListele();
            listele.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmSözleşme sözleşme= new frmSözleşme();
            sözleşme.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmSatış satış = new frmSatış();
            satış.ShowDialog();
        }

        private void frmAnaSayfa_Load(object sender, EventArgs e)
        {

        }
    }
}
