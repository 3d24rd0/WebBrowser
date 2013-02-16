using System;
using System.Collections;
using System.Collections.Generic;
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

namespace Olive
{
    public partial class MainWindow : Window
    {
        private List<TabItem> _tabs;
        private TabItem _tab;//Pestaña de añadir mas pestañas
        private int ID_Pest = 0; //Necesario id para cerrar pestañas debe de ser un valor unico sin posivilidad de repetir.
      
        private Navegacion[] Motor = new Navegacion[30];

        public MainWindow()
        {
            try{
                InitializeComponent();
                _tabs = new List<TabItem>();//Iniciar array _tabs
                //Creamos la tab de agregar mas tabs
                _tab = new TabItem();
                _tab.Header = "+";
                //Añadimos la tab al array
                _tabs.Add(_tab);
                //Agregamos la primera pestaña normal
                this.AddTabItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error iniciar la aplicaccion \n Error:"+ex);
            }
        }
        //Añadir Pestaña
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
            navegas.Children.Add(Motor[ID_Pest].getbrouser());
            ID_Pest++;//Sacamos new id
        }

        //Button from tabsitems Button_Close_Click
        private void Button_Close_Click(object sender, RoutedEventArgs e)
        {
            string tabName = (sender as Button).CommandParameter.ToString(); //Saca el nombre de la pestaña en la que esta el boton
            //MessageBox.Show(Pestañas.SelectedIndex.ToString());
            var item = Pestañas.Items.Cast<TabItem>().Where(i => i.Name.Equals(tabName)).SingleOrDefault();
            TabItem tab = item as TabItem;
           if (tab != null)//Posible error
            {
                if (_tabs.Count < 3)//queda solo una pestaña < 3 
                {
                    Close();
                }
                else {
                    TabItem selectedTab = Pestañas.SelectedItem as TabItem;// tab seleccionada
                    if (selectedTab == null || selectedTab.Equals(tab))//Si la pestaña seleccionada es borrada, enfocamos otra.
                    {
                        selectedTab = _tabs[0];
                    }
                    Pestañas.DataContext = null;// clear tab control binding
                    _tabs.Remove(tab);//Borramos del listado
                    Pestañas.DataContext = _tabs; // restablece pestañas
                }
            }
        }

        private void Tab_change(object sender, SelectionChangedEventArgs e)//Cuando cambia la seleccion de pestaña
        {
            TabItem tab = Pestañas.SelectedItem as TabItem;
            if (tab == null) return;
            if (tab != _tab)
            {
                if (ID_Pest -1 > 0)
                {
                    // Pestañas.SelectedIndex.ToString();
                    navegas.Children.Clear();
                    navegas.Children.Add(Motor[Pestañas.SelectedIndex].getbrouser());
                }
            }
        }

        /// <summary>
        /// Pestaña que añade pestañas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region Barra herramientas
        private void TextoUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ComboBox t = e.Source as ComboBox;
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

        private void GuardaFavoritos_Click_1(object sender, RoutedEventArgs e)
        {

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
           // Motor[Pestañas.SelectedIndex].FindName("google");
        }

        private void BotonHome_Click_1(object sender, RoutedEventArgs e)
        {
            Motor[Pestañas.SelectedIndex].goHome();
        }
        #endregion

        private void url_Working(string url)
        {
            Uri ruta;
            //this.Home = new Uri(Home, UriKind.RelativeOrAbsolute);
            if (String.IsNullOrEmpty(url)) return;
            if (url.Equals("about:blank")) return;
            if (!url.StartsWith("http://") || !url.StartsWith("https://"))
            {
                ruta = new Uri("http://" + url, UriKind.RelativeOrAbsolute);
            }
            else
            {
                ruta = new Uri(url, UriKind.RelativeOrAbsolute);
            }
                try
                {
                   // webBrowser1.Navigate(new Uri(url));
                    Motor[Pestañas.SelectedIndex].seturl(ruta);
                }
                catch (System.UriFormatException)
                {
                    return;
                }
            Motor[Pestañas.SelectedIndex].goUrl();
         }
    }
}
