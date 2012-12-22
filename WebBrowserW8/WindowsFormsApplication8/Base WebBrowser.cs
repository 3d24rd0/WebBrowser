using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;


namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /* método de controlde eventos y colocará el cursor en el método en la vista Código.*/
        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0; 
            webBrowser1.GoHome();
        }

        /*Boton de ir hay que conseguir que se ejecute pulsando Enter*/ 
        private void button1_Click(object sender, EventArgs e)
        {
            /*webBrowser1.Navigate(new Uri(comboBox1.SelectedItem.ToString()));*/
            webBrowser1.Navigate(comboBox1.Text.ToString());
        }

        /*Botones Atras, Siguiente y Home los añadiremos tmb en el menu*/
        private void button2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }
        /*Convoca el Formulario de Favoritos*/
        private void añadirFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFavoritos frm = new FormFavoritos();

            frm.Show();
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                webBrowser1.Navigate(comboBox1.Text.ToString());

            }
        }

      

    }
}
