using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using System.Windows.Media.Animation;

namespace CifradoresClasicos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool cifrarCesar = true;
        private cifradorCesar cifrador;

        public MainWindow()
        {
            InitializeComponent();
            cifrador = new cifradorCesar();
        }

        private void CambiaraDescifrarCesar(object sender, RoutedEventArgs e) {
            cifrarCesar = false;
        }
        private void cambiarCifrarCesar(object sender, RoutedEventArgs e) {
            cifrarCesar = true;
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void VerticallyExpandMe_TextChanged(object sender, TextChangedEventArgs e) {
            string prueba = cifrador.cifrar(VerticallyExpandMe.Text,13);
            Expandir2.Text = prueba;
        }

    }
}
