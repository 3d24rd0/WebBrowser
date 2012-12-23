using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

using System.Web;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

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
            Navegador.SelectedIndex = 0; 
            webBrowser1.GoHome();
            //Llamo para quitar menssages de error/acceso de javascript
            SuppressScriptErrorsOnly(webBrowser1);
        }

        //Esta parte del codigo oculta los errores de scripts sin ocultar el resto de scripts.
        //Se llama con SuppressScriptErrorsOnly(webBrowser1); Actualmente lo llamos desde form1_load
        #region Ocultar Errores de scripts 
        /* codigo sacado de msdn:
         * http://msdn.microsoft.com/es-es/library/vstudio/system.windows.forms.webbrowser.scripterrorssuppressed(v=vs.100).aspx
         * Con poner            
         * webBrowser1.ScriptErrorsSuppressed = false;
         * quitaba lla el error pero me di cuenta que lla no funcionavan otros cuadros de dialogo de javascript
         * por lo que buscando encontre con esto lo que solo lo quita/oculta si da error
         * */

        // Hides script errors without hiding other dialog boxes.
        private void SuppressScriptErrorsOnly(WebBrowser browser)
        {
            // Ensure that ScriptErrorsSuppressed is set to false.
            browser.ScriptErrorsSuppressed = false;
            // Handle DocumentCompleted to gain access to the Document object.
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
        }
        private void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
        }
#endregion

        #region Botones
        //Boton de ir 
        private void Go_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(Navegador.Text);
        }
        //Buscar
        private void Buscar_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("http://google.com/search?q=" + toolStripTextBox1.Text);
        }
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                webBrowser1.Navigate("http://google.com/search?q=" + toolStripTextBox1.Text);
            }
        }

        //Recargar
        private void refresh_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }
        //Stop
        private void Cancelar_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }
        //Botone Atras
        private void back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        //Boton Alante
        private void forward_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        //Boton Home
        private void HOME_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }
#endregion 

        /*Convoca el Formulario de Favoritos*/
        private void añadirFavoritosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFavoritos frm = new FormFavoritos();

            frm.Show();
        }
















    }
}
