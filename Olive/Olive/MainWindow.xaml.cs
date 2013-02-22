using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;

namespace Olive
{
    public partial class MainWindow : Window
    {
        private List<TabItem> _tabs;
        private TabItem _tab;//Pestaña de añadir mas pestañas
        private int ID_Pest = 0; //Necesario id para cerrar pestañas debe de ser un valor unico sin posivilidad de repetir.
        private Navegacion[] Motor = new Navegacion[30];

        private string ruta_Archivos = "../../Configuracion/ArchivosXml/";
        private string ruta_favo = "Favoritos.xml";
        private string ruta_Histo = "Historial.xml";
        private string Main_xmlCarpeta = "MainCarpetas.xml";
        private string ultimapaginavisitada = "Olive";

        public MainWindow()
        {
            try{
                InitializeComponent();
                _tabs = new List<TabItem>();//Iniciar array _tabs
                TabAdding();//Agregamos la pestaña de crear mas.
                this.AddTabItem();//Agregamos la primera pestaña normal
                comprobarArchivosXML(ruta_favo, ruta_Archivos);
                comprobarArchivosXML(ruta_Histo, ruta_Archivos);
                comprobarArchivosXML(Main_xmlCarpeta, ruta_Archivos);
                Muestra_favoritos(ruta_Archivos + ruta_favo);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error iniciar la aplicaccion \n Error:"+ex);
            }
        }
     //Button from tabsitems Button_Close_Click
        #region tabitems
        private void TabAdding()
        {
            if (ID_Pest < 1)
            {
                _tab = new TabItem();//Creamos la tab de agregar mas tabs
                _tab.Header = "+";
                _tabs.Add(_tab); //Añadimos la tab al array
            }
        }
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString(); //Saca el nombre de la pestaña en la que esta el boton
            MessageBox.Show(tabName + Pestañas.SelectedIndex);

            var item = Pestañas.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;
            //TabItem tabselect = FindResource("tab0");
            if (tab != null)//Posible error
            {
                if (_tabs.Count < 3)//queda solo una pestaña < 3 
                {
                    Close();
                }
                else
                {
                   /* TabItem selectedTab = Pestañas.SelectedItem as TabItem;// tab seleccionada
                    if (selectedTab == null || selectedTab.Equals(tab))//Si la pestaña seleccionada es borrada, enfocamos otra.
                    {
                        selectedTab = _tabs[0];
                    }
                    Pestañas.DataContext = null;// clear tab control binding
                    _tabs.Remove(tab);//Borramos del listado
                    Pestañas.DataContext = _tabs; // restablece pestañas
                    */
                    tab.Focus();
                    int temp = Pestañas.SelectedIndex +1;
                    MessageBox.Show(Pestañas.SelectedIndex.ToString() + Pestañas.Items.Count.ToString());

                    Navegacion[] Motor2 = new Navegacion[30];
                    int w = 0;
                    for (int i = temp; i >= Pestañas.Items.Count - 1; i++)
                    {
                        Motor2[w] = Motor[i];
                        w++;
                    }
                    w = 0;
                    for (int z = temp; z >= Pestañas.Items.Count - 1; z++)
                    {
                        Motor[z] = Motor2[w];
                        w++;
                        if (z == Pestañas.Items.Count - 2)
                        {
                            MessageBox.Show(z.ToString() + "kik");
                            w = z;
                        }
                    }

                   // Motor[w] = null;
                    Pestañas.DataContext = null;// clear tab control binding
                    _tabs.Remove(tab);//Borramos del listado
                    Pestañas.DataContext = _tabs; // restablece pestañas
                    navegas.Children.Clear();
             
                    //navegas.Children.Add(Motor[w].getbrouser());
                   // ComboFavoritos.Text = Motor[w].geturl().ToString();
                }
            }
        }
        private void AddTabItem()
        {
            //agregamos motor
            Pestañas.DataContext = null; //Lista a null
            TabItem tab = new TabItem();
            tab.Header = string.Format("Tab {0}", _tabs.Count);//Header path textblock definido en XAml
            tab.Name = string.Format("tab{0}", ID_Pest);//Dandole id a la pestaña
            tab.HeaderTemplate = Pestañas.FindResource("Plant_tabs") as DataTemplate;//agregar template creado en xaml
            _tabs.Insert(_tabs.Count - 1, tab);// Inserta antes de la ultima pestaña 
            Pestañas.DataContext = _tabs;// bind tab control
            Pestañas.SelectedItem = tab;// select newly added tab item
            //Agregamos motor
            Motor[ID_Pest] = new Navegacion("http://www.google.es");
            WebBrowser a = Motor[ID_Pest].getbrouser();
            a.LoadCompleted += navegador_LoadCompleted;
            navegas.Children.Add(Motor[ID_Pest].getbrouser());
            ID_Pest++;//Sacamos new id
        }
        private void Tab_change(object sender, SelectionChangedEventArgs e)//Cuando cambia la seleccion de pestaña
        {
            TabItem tab = Pestañas.SelectedItem as TabItem;
            if (tab == null) return;
            if (!tab.Equals(_tab))
            {
                if (Pestañas.SelectedIndex >= 0)
                {
                    try
                    {
                        navegas.Children.Clear();
                        navegas.Children.Add(Motor[Pestañas.SelectedIndex].getbrouser());
                        ComboFavoritos.Text = Motor[Pestañas.SelectedIndex].geturl().ToString();
                    }
                    catch { }
                }
            }
        }
        #endregion

        #region toolbar1
        private void Pestañas_MouseLeftButtonUp(object sender, MouseButtonEventArgs e) 
        {
            TabItem tab = Pestañas.SelectedItem as TabItem;
            if (tab == null) return;
            if (tab == _tab) //Si la pestaña seleccionada es la de añadir
            {
                AddTabItem();
            }
        } 
        private void Pestañas_KeyUp_1(object sender, KeyEventArgs e)
        {
            TabItem tab = Pestañas.SelectedItem as TabItem;
            if (tab == null) return;
            if (e.Key == Key.Enter)
            {
                if (tab == _tab) //Si la pestaña seleccionada es la de añadir
                {
                    AddTabItem();
                }
            }
        }
        private void Pulsateclas(object sender, KeyEventArgs e)
        {
            // Ctrl + t Crea una pestaña
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.T))
            {
                AddTabItem();
            }
            //Ctrl + P Imprime 
            if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.P))
            {
                PrintDialog dialog = new PrintDialog();

                MessageBoxResult respuesta = MessageBox.Show("Desea imprimir ? ", "Impresión", MessageBoxButton.OKCancel);
                if (respuesta == MessageBoxResult.OK)
                {
                    // Imprimir la pantalla
                    if (dialog.ShowDialog() == true)
                    {
                        dialog.PrintVisual(this, "Impresión");
                    }
                }
                }

                //Ctrl + N Nueva ventana
                if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
                {
                    MainWindow window = new MainWindow();
                    window.Show();

                }
            // Ctrl + F
             if ((Keyboard.Modifiers == ModifierKeys.Control) && (e.Key == Key.N))
              {
                  //Encontrar alguna manera de buscar en el contenido del webbrowser.              Ya ace algo con ctrl + f por defecto
              }
        }
        private void TextoUrl_KeyDown(object sender, KeyEventArgs e)
        {
            ComboBox t  = e.Source as ComboBox;
            if (e.Key == Key.Enter)
            {
                url_Working(t.Text);
            }
        }
        private void Batras(object sender, RoutedEventArgs e)
        {
            Motor[Pestañas.SelectedIndex].goAtras();

        }
        private void Badelante_Click_1(object sender, RoutedEventArgs e)
        {
            Motor[Pestañas.SelectedIndex].goAdelante();
        }
        private void ComboFavoritos_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            MessageBox.Show("lol" + ComboFavoritos.SelectedIndex.ToString());
            char[] a = ComboFavoritos.SelectedItem.ToString().ToCharArray();
            Boolean estas = false;
            string temp = "";
            for(int o = 0; o < a.Length; o++)
            {
                if (estas)
                {
                    //MessageBox.Show(a[o].ToString());
                    temp += a[o];
                }
                if(a[o].Equals('\n') && !estas){
                   // MessageBox.Show(a[o].ToString());
                    estas = true;
                }
            }
            Motor[Pestañas.SelectedIndex].seturl(new Uri(temp, UriKind.RelativeOrAbsolute));
            Motor[Pestañas.SelectedIndex].goUrl();
            //MessageBox.Show(Motor[Pestañas.SelectedIndex].geturl().ToString());
            //url_Working(temp);
        }
        private void Refrescar_Click_1(object sender, RoutedEventArgs e)
        {
            Motor[Pestañas.SelectedIndex].Refresh();
        }
        private void TextoBuscar_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                TextBox t = e.Source as TextBox;
                Motor[Pestañas.SelectedIndex].search(t.Text);
            }
        }
        private void BotonBuscar_Click_1(object sender, RoutedEventArgs e)
        {
            //Motor[Pestañas.SelectedIndex];
        }
        private void BotonHome_Click_1(object sender, RoutedEventArgs e)
        {
            Motor[Pestañas.SelectedIndex].goHome();
        }    
        private void SearchIcon_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {//Imagen de texbox para buscar
            Motor[Pestañas.SelectedIndex].search(Busca.Text);
        }
        private void EliminarF_Click_1(object sender, RoutedEventArgs e)
        {
            
           // Favoritos.Children.Add()
        }

        private void OkF_Click_1(object sender, RoutedEventArgs e)
        {
            // nombrecarpeta, nombre 
            string nombre = Nombre_Nombre.Text;
            if (Nombre_Nombre.Text.Equals("") || Nombre_Nombre.Text == null)
            {
                nombre = Motor[Pestañas.SelectedIndex].getName();
            }
            if (Nombre_Carpeta.Text.Equals("") || Nombre_Carpeta.Text == null)
            {
                CrearFavorito(nombre, Motor[Pestañas.SelectedIndex].geturl().ToString(), (ruta_Archivos + ruta_favo));
            }
            else
            {
                if (!existexml_carpetas(Nombre_Carpeta.Text))
                {
                    xml_crea_carpeta_favoritos(Nombre_Carpeta.Text);//insertamos en xml main
                    CrearXml(ruta_Archivos, Nombre_Carpeta.Text);//creamos archivo nuevo.
                }
                //insertamos en archivo de la carpeta correspondiente
                CrearFavorito(nombre, Motor[Pestañas.SelectedIndex].geturl().ToString(),(ruta_Archivos + Nombre_Carpeta.Text));

            }

          //  MessageBox.Show(nombre + Nombre_Carpeta.Text);
           // CrearFavorito(Motor[Pestañas.SelectedIndex].getName(), Motor[Pestañas.SelectedIndex].geturl().ToString(), (ruta_Archivos + ruta_favo));
           // Muestra_favoritos(ruta_Archivos + ruta_favo);
        }
        #endregion
        #region tools
        private void url_Working(string url)
        {
            Uri ruta;
            if (String.IsNullOrEmpty(url)) return;
            if (url.Equals("about:blank")) return;
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                ruta = new Uri("http://" + url, UriKind.RelativeOrAbsolute);
            }
            else
            {
                ruta = new Uri(url, UriKind.RelativeOrAbsolute);
            }
                try
                {
                    Motor[Pestañas.SelectedIndex].seturl(ruta);
                }
                catch
                {
                    return;
                }
            Motor[Pestañas.SelectedIndex].goUrl();
         }
        void navegador_LoadCompleted(object sender, NavigationEventArgs e) //Actualiza la url del combobox
        {
            try
            {
                ComboFavoritos.Text = Motor[Pestañas.SelectedIndex].geturl().ToString();
                CrearHistorial(Motor[Pestañas.SelectedIndex].getName(), Motor[Pestañas.SelectedIndex].geturl().ToString(), (ruta_Archivos + ruta_Histo));
            }
            catch { }
        }  
        #endregion
        #region xml
        public void comprobarArchivosXML(string ArchivoXml, String ruta)
        {
            ArchivoXml = ruta + ArchivoXml;
            if (CrearCarpetaXml(ruta))
            {
                if (!ArchivoExiste(ArchivoXml))
                {
                    CrearXml(ArchivoXml,"");
                }
            }
        }
        public static bool CrearCarpetaXml(string Ruta)
        {
            try
            {
                if (Directory.Exists(Ruta))
                {
                    return true;
                }
                else
                {
                    Directory.CreateDirectory(Ruta);
                    return true;
                }
            }
            catch
            {
                return false;//No fue posible crear el directorio...
            }
        }
        public static bool ArchivoExiste(string Ruta)
        {
            try
            {
                if (File.Exists(Ruta))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        private static bool CrearXml(string Ruta_archivo, String Nombre_archivo)
        {
            try
            {
                if (Nombre_archivo != "")
                {
                    if (Ruta_archivo == "../../Configuracion/ArchivosXml/Favoritos.xml")
                    {
                        XmlTextWriter EscribirRec = new XmlTextWriter(Ruta_archivo, System.Text.Encoding.UTF8);
                        EscribirRec.Formatting = Formatting.Indented;
                        EscribirRec.Indentation = 2;
                        EscribirRec.WriteStartDocument(false);
                        EscribirRec.WriteComment("Lista de Favoritos");
                        EscribirRec.WriteStartElement("favoritos");
                        EscribirRec.WriteEndElement();
                        EscribirRec.WriteEndDocument();
                        EscribirRec.Close();
                        return true;
                    }
                    if (Ruta_archivo == "../../Configuracion/ArchivosXml/Historial.xml")
                    {
                        XmlTextWriter EscribirRec = new XmlTextWriter(Ruta_archivo, System.Text.Encoding.UTF8);
                        EscribirRec.Formatting = Formatting.Indented;
                        EscribirRec.Indentation = 2;
                        EscribirRec.WriteStartDocument(false);
                        EscribirRec.WriteComment("Lista de Historial");
                        EscribirRec.WriteStartElement("Historial");
                        EscribirRec.WriteEndElement();
                        EscribirRec.WriteEndDocument();
                        EscribirRec.Close();
                        return true;
                    }


                    if (Ruta_archivo == "../../Configuracion/ArchivosXml/MainCarpetas.xml")
                    {
                        XmlTextWriter EscribirRec = new XmlTextWriter(Ruta_archivo, System.Text.Encoding.UTF8);
                        EscribirRec.Formatting = Formatting.Indented;
                        EscribirRec.Indentation = 2;
                        EscribirRec.WriteStartDocument(false);
                        EscribirRec.WriteComment("Lista de Carpetas Contenedoras de favoritos");
                        EscribirRec.WriteStartElement("Carpeta");
                        EscribirRec.WriteEndElement();
                        EscribirRec.WriteEndDocument();
                        EscribirRec.Close();
                        return true;
                    }
                }
                else
                {
                    XmlTextWriter EscribirRec = new XmlTextWriter(Ruta_archivo + Nombre_archivo, System.Text.Encoding.UTF8);
                    EscribirRec.Formatting = Formatting.Indented;
                    EscribirRec.Indentation = 2;
                    EscribirRec.WriteStartDocument(false);
                    EscribirRec.WriteComment("Lista de Carpetas Contenedoras de favoritos");
                    EscribirRec.WriteStartElement("Carpeta");
                    EscribirRec.WriteEndElement();
                    EscribirRec.WriteEndDocument();
                    EscribirRec.Close();
                    return true;

                }
                return false;
            }
            catch
            {
                return false;
            }
        }
        public static bool CrearFavorito(string Nombre, string url, string rutafavorito)
        {
            XmlDocument XmlDoc;
            XmlNode Raiz;
            XmlNode ident;
            try
            {
                XmlDoc = new XmlDocument();
                XmlDoc.Load(rutafavorito);
                Raiz = XmlDoc.DocumentElement;
                ident = Raiz; // las transacciones quedarán en las exitosas  
                XmlElement NuevaTransaccion = XmlDoc.CreateElement("Favorito"); //Como vamos a llamar el nuevo nodo  
                NuevaTransaccion.InnerXml = "<Nombre></Nombre><Url></Url>"; // Este es el contenido que va a tener el nuevo nodo  
                NuevaTransaccion.AppendChild(XmlDoc.CreateWhitespace("\r\n"));
                NuevaTransaccion["Nombre"].InnerText = Nombre;
                NuevaTransaccion["Url"].InnerText = url;
                ident.InsertAfter(NuevaTransaccion, ident.LastChild);
                XmlTextWriter EscribirRec = new XmlTextWriter(rutafavorito, System.Text.Encoding.UTF8);
                XmlDoc.WriteTo(EscribirRec);
                EscribirRec.Close();
                return true;
            }
            catch
            {
                return false; 
            }
        }
        public bool CrearHistorial(string Nombre, string url, string rutafavorito)
        {
            XmlDocument XmlDoc;
            XmlNode Raiz;
            XmlNode ident;
            try
            {
                if (Nombre != ultimapaginavisitada && ultimapaginavisitada != "")
                {
                    ultimapaginavisitada = Nombre;
                    DateTime Hoy = DateTime.Now;
                    String fecha_actual = Hoy.ToString("dd-MM-yyyy");
                    String HoraActual = Hoy.ToString("T", CultureInfo.InstalledUICulture);
                    XmlDoc = new XmlDocument();
                   
                    XmlDoc.Load(rutafavorito);
                    Raiz = XmlDoc.DocumentElement;
                    ident = Raiz; // las transacciones quedarán en las exitosas  
                    XmlElement NuevoRegistro = XmlDoc.CreateElement("Historial"); //Como vamos a llamar el nuevo nodo  
                    NuevoRegistro.InnerXml = "<Nombre></Nombre><Url></Url><Dia></Dia><Hora></Hora>"; // Este es el contenido que va a tener el nuevo nodo  
                    NuevoRegistro.AppendChild(XmlDoc.CreateWhitespace("\r\n"));
                    NuevoRegistro["Nombre"].InnerText = Nombre;
                    NuevoRegistro["Url"].InnerText = url;
                    NuevoRegistro["Dia"].InnerText = fecha_actual.ToString();
                    NuevoRegistro["Hora"].InnerText = HoraActual.ToString();


                    ident.InsertAfter(NuevoRegistro, ident.LastChild);
                    XmlTextWriter EscribirRec = new XmlTextWriter(rutafavorito, System.Text.Encoding.UTF8);
                    XmlDoc.WriteTo(EscribirRec);
                    EscribirRec.Close();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;  
            }
        }
        public bool xml_crea_carpeta_favoritos(string Nombre)
        {//inserta en main xml nombres de las carpetas
            XmlDocument XmlDoc;
            XmlNode Raiz;
            XmlNode ident;
            try
            {
                XmlDoc = new XmlDocument();
                XmlDoc.Load(ruta_Archivos+Main_xmlCarpeta);
                Raiz = XmlDoc.DocumentElement;
                ident = Raiz; // las transacciones quedarán en las exitosas  
                XmlElement NuevaTransaccion = XmlDoc.CreateElement("File"); //Como vamos a llamar el nuevo nodo  
                NuevaTransaccion.InnerXml = "<Nombre></Nombre>"; // Este es el contenido que va a tener el nuevo nodo  
                NuevaTransaccion.AppendChild(XmlDoc.CreateWhitespace("\r\n"));
                NuevaTransaccion["Nombre"].InnerText = Nombre;
                ident.InsertAfter(NuevaTransaccion, ident.LastChild);
                XmlTextWriter EscribirRec = new XmlTextWriter(ruta_Archivos + Main_xmlCarpeta, System.Text.Encoding.UTF8);
                XmlDoc.WriteTo(EscribirRec);
                EscribirRec.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Muestra_favoritos(string archivo)
        {
            String nombre = "";
            String Url = "";
            Boolean primero = false;
            Boolean segundo = false;
            XmlTextReader reader = new XmlTextReader(archivo);
            ComboFavoritos.Items.Clear();//Limpia antes de llenar.
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: //Display the text in each element
                        if (reader.Name == "Nombre")
                        {
                            nombre = reader.ReadString();
                            primero = true;
                        }
                        if (reader.Name == "Url")
                        {
                            Url = reader.ReadString();
                            segundo = true;
                        }
                        if (primero == true && segundo == true)
                        {
                            ComboFavoritos.Items.Add(nombre + "\n" + Url);
                            primero = false;
                            segundo = false;
                        }
                        break;
                }
            }
        }
        public Boolean existexml_carpetas(String nombre)
        {
            XmlTextReader reader = new XmlTextReader("../../Configuracion/ArchivosXml/MainCarpetas.xml");
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element: //Display the text in each element
                        if (reader.Name == "Nombre")
                        {
                           if(reader.ReadString() == nombre)
                           {
                               return true;
                           }
                        }
                        break;
                }
            }
            return false;
        }
        #endregion xml



    }
}
