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
using System.Collections;

namespace WindowsFormsApplication8
{

    public partial class Form1 : Form
    {
        ArrayList ListaPestaña = new ArrayList();
        int ContarPestaña = 0;

        public Form1()
        {
            InitializeComponent();
            
        }

        /* método de controlde eventos y colocará el cursor en el método en la vista Código.*/
        private void Form1_Load(object sender, EventArgs e)
        {
            Navegador1.SelectedIndex = 0; 
           // webBrowser1.GoHome();
            //Llamo para quitar menssages de error/acceso de javascript
           // SuppressScriptErrorsOnly(webBrowser1);
            CrearPestaña();
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
            getCurrentBrowser().Navigate(Navegador.Text);
        }
        //Buscar
        private void Buscar_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Navigate("http://google.com/search?q=" + toolStripTextBox1.Text);
        }
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                getCurrentBrowser().Navigate("http://google.com/search?q=" + toolStripTextBox1.Text);
            }
        }

        //Recargar
        private void refresh_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Refresh();
        }
        //Stop
        private void Cancelar_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().Stop();
        }
        //Botone Atras
        private void back_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().GoBack();
        }

        //Boton Alante
        private void forward_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().GoForward();
        }
        //Boton Home
        private void HOME_Click(object sender, EventArgs e)
        {
            getCurrentBrowser().GoHome();
        }
        private void newtab_Click(object sender, EventArgs e)
        {
            CrearPestaña();
        }

        private void closeTap_Click(object sender, EventArgs e)
        {
            EliminarPestaña();
        }
#endregion 

        #region Pestañas

        private void WebBrowser_completa(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            String text = getCurrentBrowser().Url.Host.ToString();
            Navegador1.SelectedTab.Text = text;
        }


        private void CrearPestaña()
        {

            TabPage NuevaPestaña = new TabPage("Nueva Pestaña ");
            ContarPestaña++; //variable que lleva el control de la cantidad de pestaña creada
            ListaPestaña.Add(NuevaPestaña);
            Navegador1.SelectedTab = NuevaPestaña; //seleccionamos la pestaña 
            Navegador1.TabPages.Add(NuevaPestaña); //cargamos la pestaña en el control 


            //
            WebBrowser browser = new WebBrowser();
            NuevaPestaña.Controls.Add(browser);
            browser.GoHome();
            browser.Dock = DockStyle.Fill;
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(WebBrowser_completa);


        }
        private void EliminarPestaña()
        {
            if (ContarPestaña != 1)
            {
                //ListaPestaña.Remove(tabControl1.SelectedTab);
                //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
               // ContarPestaña--;
                Navegador1.TabPages.RemoveAt(Navegador1.SelectedIndex);
               // browserTabControl.TabPages.RemoveAt(browserTabControl.SelectedIndex);
            }
            else
            {
                Close();
            }


        }

        #endregion

        #region tools
        private WebBrowser getCurrentBrowser()
        {
            WebBrowser a = (WebBrowser)Navegador1.SelectedTab.Controls[0];
            return a;
        }
        #endregion



    }
}
