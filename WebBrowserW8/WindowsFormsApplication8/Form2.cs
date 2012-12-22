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
    public partial class FormFavoritos : Form
    {
        static string nombreFav = "";
        static string UrlFav = "";

        public FormFavoritos()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            nombreFav = textBox1.Text;
            FormFavoritos fav = new FormFavoritos();
            fav.Favoritos_XML();   
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UrlFav = textBox2.Text;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Favoritos_XML(); 
        }
        private void Favoritos_XML()
        {
          string nombre = nombreFav;
          XDocument FavoritosXML = new XDocument(new XDeclaration("1.0", "utf-8", "yes"),
          new XElement ("Favoritos",  
          new XElement("Nombre" ,
          new XAttribute ("Nombrem", nombre))
          ));
          FavoritosXML.Save(@"C:\Users\Fran\Desktop");
            MessageBox.Show("Se ha creado un XML"); 
        }

    }
}
