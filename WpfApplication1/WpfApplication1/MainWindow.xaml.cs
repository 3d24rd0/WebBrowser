using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        private void TabItem_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            UserControl name = new UserControl();
            TabItem item = new TabItem();//se manda a llamar el control TabItem.  
            item.Name = "Nombre";//se le asigna un nombre al control.  
            item.Header = "Titulo";//se le pone da un titulo el cual se mostrara en la ventana  
            item.Content = name;
            tabcontrol.Items.Add(item);//se agrega el TabItem al TabControl  
            item.Focus();//con esto se  le da el foco de la ventana al TabItem creado 

        }


    }
}
