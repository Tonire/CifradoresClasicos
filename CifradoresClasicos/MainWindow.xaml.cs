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
        private CifradorCesar cifrador;

        public MainWindow()
        {
            InitializeComponent();
            cifrador = new CifradorCesar();
        }

        private void CambiaraDescifrarCesar(object sender, RoutedEventArgs e) {
            cifrarCesar = false;
            imagenSubir.Opacity = 0.6;
            imagenBajar.Opacity = 0;
            textoCifrado_TextChanged(null, null);
        }
        private void cambiarCifrarCesar(object sender, RoutedEventArgs e) {
            cifrarCesar = true;
            imagenSubir.Opacity = 0;
            imagenBajar.Opacity = 0.6;
            textoPlano_TextChanged(null,null);
        }

        private void MetroWindow_Loaded(object sender, RoutedEventArgs e) {
            
        }

        private void textoPlano_TextChanged(object sender, TextChangedEventArgs e) {
            if (cifrarCesar) {
                string cifrado = cifrador.cifrar(textoPlano.Text, 13);
                textoCifrado.Text = cifrado;
            }
        }

        private void textoCifrado_TextChanged(object sender, TextChangedEventArgs e) {
            if (!cifrarCesar) {
                string descifrado = cifrador.descifrar(textoCifrado.Text, 13);
                textoPlano.Text = descifrado;
            }
        }

    }
}
