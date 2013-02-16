using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace Olive
{
    class Navegacion
    {
        private Uri url;
        private WebBrowser navegador;
        public Uri Home;

        public Navegacion()
        {
            this.navegador = new WebBrowser();
        }
        public Navegacion(string Home)
        {
            this.Home = new Uri(Home, UriKind.RelativeOrAbsolute);
            this.navegador = new WebBrowser();
            navegador.Navigate(Home);
        }
        //getters and setters

        public Uri geturl()
        {
            return url;
        }
        public void seturl(Uri ruta)
        {
            //this.url = new Uri(ruta, UriKind.RelativeOrAbsolute);
            this.url = ruta;
        }


        public WebBrowser getbrouser()
        {
            return navegador;
        }

        //Propiedades
        #region propiedades
        public void goAdelante()
        {
            try
            {
                navegador.GoForward();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo \n Error: " + e );
            }
        }
        public void goAtras()
        {
            try
            {
                navegador.GoBack();
            }
            catch (Exception e)
            {
                MessageBox.Show("No se pudo \n Error: " + e);
            }
        }
        public void goHome()
        {
            try
            {
                navegador.Navigate(Home);
            }
            catch (Exception e)
            {
                MessageBox.Show("Error inesperado \n Error: " + e);
            }
        }
        public void goUrl()
        {
            navegador.Navigate(url);
        }
        public void Refresh()
        {
            navegador.Refresh();
        }
        public void FindName(string find)
        {
            navegador.FindName(find);
        }
        public void search(string find)
        {
            this.url = new Uri("http://google.com/search?q=" + find, UriKind.RelativeOrAbsolute);
            navegador.Navigate(url);
        }
        #endregion

      

    }
}
