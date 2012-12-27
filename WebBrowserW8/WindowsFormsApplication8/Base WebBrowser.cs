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
using System.Net.NetworkInformation;

using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace WindowsFormsApplication8
{
    public partial class Form1 : Form
    {
        ArrayList ListaPestaña = new ArrayList();
        int ContarPestaña = 0;
        //Abra que guardar en xml ??
        String Home = "www.google.es";

        public Form1()
        {
            InitializeComponent();
            
        }

        /* método de controlde eventos y colocará el cursor en el método en la vista Código.*/
        private void Form1_Load(object sender, EventArgs e)
        {
            Navegador1.SelectedIndex = 0; 
            CrearPestaña();
        }

        //Codigo en pruebas, permite control sobre errores de la web...
        #region Complemento de errores
        /// <summary>
        /// En el ejemplo de código siguiente se muestra el uso de este método en una clase derivada de WebBrowser que complementa los eventos WebBrowser normales con el evento NavigateError de la interfaz DWebBrowserEvents2 de OLE. 
        /// http://msdn.microsoft.com/es-es/library/system.windows.forms.webbrowser.createsink%28v=vs.80%29.aspx
        /// </summary>
        public class WebBrowser2 : WebBrowser
        {
            AxHost.ConnectionPointCookie cookie;
            WebBrowser2EventHelper helper;

            [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void CreateSink()
            {
                base.CreateSink();

                // Create an instance of the client that will handle the event
                // and associate it with the underlying ActiveX control.
                helper = new WebBrowser2EventHelper(this);
                cookie = new AxHost.ConnectionPointCookie(
                    this.ActiveXInstance, helper, typeof(DWebBrowserEvents2));
            }

            [PermissionSetAttribute(SecurityAction.LinkDemand, Name = "FullTrust")]
            protected override void DetachSink()
            {
                // Disconnect the client that handles the event
                // from the underlying ActiveX control.
                if (cookie != null)
                {
                    cookie.Disconnect();
                    cookie = null;
                }
                base.DetachSink();
            }

            public event WebBrowserNavigateErrorEventHandler NavigateError;

            // Raises the NavigateError event.
            protected virtual void OnNavigateError(WebBrowserNavigateErrorEventArgs e)
            {
                if (this.NavigateError != null)
                {
                    this.NavigateError(this, e);
                }
            }

            // Handles the NavigateError event from the underlying ActiveX 
            // control by raising the NavigateError event defined in this class.
            private class WebBrowser2EventHelper : StandardOleMarshalObject, DWebBrowserEvents2
            {
                private WebBrowser2 parent;

                public WebBrowser2EventHelper(WebBrowser2 parent)
                {
                    this.parent = parent;
                }

                public void NavigateError(object pDisp, ref object url, ref object frame, ref object statusCode, ref bool cancel)
                {
                    // Raise the NavigateError event.
                    this.parent.OnNavigateError(new WebBrowserNavigateErrorEventArgs((String)url, (String)frame, (Int32)statusCode, cancel));
                }
            }
        }

        // Represents the method that will handle the WebBrowser2.NavigateError event.
        public delegate void WebBrowserNavigateErrorEventHandler(object sender, WebBrowserNavigateErrorEventArgs e);

        // Provides data for the WebBrowser2.NavigateError event.
        public class WebBrowserNavigateErrorEventArgs : EventArgs
        {
            private String urlValue;
            private String frameValue;
            private Int32 statusCodeValue;
            private Boolean cancelValue;

            public WebBrowserNavigateErrorEventArgs(String url, String frame, Int32 statusCode, Boolean cancel)
            {
                urlValue = url;
                frameValue = frame;
                statusCodeValue = statusCode;
                cancelValue = cancel;
            }

            public String Url
            {
                get { return urlValue; }
                set { urlValue = value; }
            }

            public String Frame
            {
                get { return frameValue; }
                set { frameValue = value; }
            }

            public Int32 StatusCode
            {
                get { return statusCodeValue; }
                set { statusCodeValue = value; }
            }

            public Boolean Cancel
            {
                get { return cancelValue; }
                set { cancelValue = value; }
            }
        }

        // Imports the NavigateError method from the OLE DWebBrowserEvents2 
        // interface. 
        [ComImport, Guid("34A715A0-6587-11D0-924A-0020AFC7AC4D"),
        InterfaceType(ComInterfaceType.InterfaceIsIDispatch),
        TypeLibType(TypeLibTypeFlags.FHidden)]
        public interface DWebBrowserEvents2
        {
            [DispId(271)]
            void NavigateError(
                [In, MarshalAs(UnmanagedType.IDispatch)] object pDisp,
                [In] ref object URL, [In] ref object frame,
                [In] ref object statusCode, [In, Out] ref bool cancel);
        }

        #endregion

        //Algunos eventos dependen del complemento
        #region eventos del webbrouser
        //Evento cuando se completa
        private void wb_completa(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

            //Muestro informacion en el laber estado
           // Estado.Text = "Completado"; ********************************* Temporal

            //Damos el nombre a las pestañas
            String text = getCurrentBrowser().Url.Host.ToString();
            Navegador1.SelectedTab.Text = text;

            //Damos nombre al tab de url
            Navegador.Text = getCurrentBrowser().Url.ToString();

            //Si ocurre un error llamo a windows_error
            ((WebBrowser)sender).Document.Window.Error += new HtmlElementErrorEventHandler(Window_Error);
        }
        private void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // Ignore the error and suppress the error dialog box. 
            e.Handled = true;
           // MessageBox.Show("Suppressed error!");

            //Muestro informacion en el laber estado
            Estado.Text = "Suppressed error!"; 

            //Ultima informacion encontrada sobre este error
            //http://msdn.microsoft.com/es-es/library/vstudio/system.windows.forms.htmlelementerroreventargs.handled(v=vs.100).aspx
        }
        private void wb_NavigateError(object sender, WebBrowserNavigateErrorEventArgs e)
        {
            // Display an error message to the user.
            //Muestro informacion en el laber estado
            Estado.Text = "Error :" + e.StatusCode.ToString(); 
            /*
            MessageBox.Show("Cannot navigate to " + e.Url);
            if (e.StatusCode.ToString() == "404")
            {
                MessageBox.Show("Page no found");
            }
            //Lista de errores ¿Creamos IF?
            //http://msdn.microsoft.com/en-us/library/bb268233.aspx
             * */
        }
        #endregion

        #region Botones
        //Boton de ir 
        private void Go_Click(object sender, EventArgs e)
        {
            Estado.Text = "Accediendo"; 
            //getCurrentBrowser().Navigate(Navegador.Text);

            getCurrentBrowser().AccessibleDescription = "Morcilla 1.0";
            getCurrentBrowser().AccessibleName = "Pettit Commite";
            ///En pruebas ****************
            Random random = new Random();
            int num = random.Next(32);
            //cadena aleatoria minusculas de 32 caracteres o menos
            string UA = "User-Agent: " + num + " Web Browser";
           // MessageBox.Show(UA);
            getCurrentBrowser().Navigate(Navegador.Text, "_self", null, UA);

        }
        //Buscar
        private void Buscar_Click(object sender, EventArgs e)
        {
            Estado.Text = "Buscando"; 
            getCurrentBrowser().Navigate(aBuscar(Navegador.Text));
        }
        // Cuando se pulsa un linea.
        private void Navegador_KeyDown(object sender, KeyEventArgs e)
        {
            Estado.Text = "Escribiendo"; 
            if (e.KeyCode == Keys.Enter)
            {
                //Realizo un ping para saver si el host responde Posible opcion extra??
                //Faltaria ajustar el ping si es posible para que sea mas corto XD
                //Servidor caido buscado en google XD
                Estado.Text = "Que operación Realizo"; 
                Ping Pings = new Ping();
                if (Pings.Send(getCurrentBrowser().Url.Host.ToString()).Status == IPStatus.Success)
                {
                    Estado.Text = "Accediendo"; 
                    getCurrentBrowser().Navigate(Navegador.Text);
                }
                else
                {
                    Estado.Text = "Buscando"; 
                    getCurrentBrowser().Navigate(aBuscar(Navegador.Text));
                }
             }
            
            
        }

        //Recargar
        private void refresh_Click(object sender, EventArgs e)
        {
            Estado.Text = "Loading..."; 
            getCurrentBrowser().Refresh();
        }
        //Stop
        private void Cancelar_Click(object sender, EventArgs e)
        {
            Estado.Text = "Stop"; 
            getCurrentBrowser().Stop();
        }
        //Botone Atras
        private void back_Click(object sender, EventArgs e)
        {
            Estado.Text = "Recargando"; 
            getCurrentBrowser().GoBack();
        }

        //Boton Alante
        private void forward_Click(object sender, EventArgs e)
        {
            Estado.Text = "Accediendo"; 
            getCurrentBrowser().GoForward();
        }
        //Boton Home
        private void HOME_Click(object sender, EventArgs e)
        {
            Estado.Text = "Home"; 
            getCurrentBrowser().Navigate(Home);
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

        private void CrearPestaña()
        {
            Estado.Text = "New Tab";
 
            TabPage newtab = new TabPage("Nueva Pestaña ");
            ContarPestaña++; //variable que lleva el control de la cantidad de pestaña creada
            ListaPestaña.Add(newtab);
            Navegador1.SelectedTab = newtab; //seleccionamos la pestaña 
            Navegador1.TabPages.Add(newtab); //cargamos la pestaña en el control 

            //Se crea objeto browser   
            WebBrowser2 wb = new WebBrowser2();
            newtab.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            wb.ScriptErrorsSuppressed = false;
            wb.NavigateError += new WebBrowserNavigateErrorEventHandler(wb_NavigateError);//Control de errores 
            wb.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(wb_completa);// ebento que se ejequta al terminar de cargar la pagina


            wb.Navigate(Home);

        }



        private void EliminarPestaña()
        {

            if (ContarPestaña != 1)
            {
                Estado.Text = "Close Tab";
                //ListaPestaña.Remove(tabControl1.SelectedTab);
                //tabControl1.TabPages.Remove(tabControl1.SelectedTab);
                ContarPestaña--;
                Navegador1.TabPages.RemoveAt(Navegador1.SelectedIndex);
               // browserTabControl.TabPages.RemoveAt(browserTabControl.SelectedIndex);
            }
            else
            {
                Estado.Text = "Exit";
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

        private String aBuscar(string texto) {
            Estado.Text = "Eligiendo motor de busqueda";
            String ruta= "http://google.com/search?q=+";
            ruta +=texto;
            return ruta;
        }

        #endregion
       







    }
}
