using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace Olive
{
    class Navegacion
    {

        private Uri url;
        private WebBrowser navegador;
        public Navegacion()
        {
            this.navegador = new WebBrowser();
            this.url = new Uri("http://www.google.es", UriKind.RelativeOrAbsolute);
            navegador.Navigate(url); 
        }
        public WebBrowser obtenbrouser()
        {
            return navegador; 
        }
        public void navega()
        {
            navegador.Navigate(url);
        }

        public Uri geturl()
        {
            return url;
        }
        public void seturl(string ruta)
        {
            this.url = new Uri(ruta, UriKind.RelativeOrAbsolute);
        }
    }
}
