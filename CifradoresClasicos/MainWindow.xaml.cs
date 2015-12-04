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
using MahApps.Metro.Controls.Dialogs;

namespace CifradoresClasicos
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private bool cifrarCesar = true;
        private bool cifrarPlayfair = true;
        private CifradorCesar cifrador;
        private CifradorPlayfair playfair;
        private char[,] matriz = null;
        public MainWindow()
        {
            InitializeComponent();
            cifrador = new CifradorCesar();
            playfair = new CifradorPlayfair();
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
            //Cuando se carga la ventana
            IList<int> listaDesplazamientosEnteros = new List<int>();
            for (int i = 1; i < 51; i++) {
                listaDesplazamientosEnteros.Add(i);
            }
            comboDesplazamiento.ItemsSource = listaDesplazamientosEnteros;
            
        }

        private void textoPlano_TextChanged(object sender, TextChangedEventArgs e) {
            if (cifrarCesar && comboDesplazamiento.SelectedValue != null) {
                string cifrado = cifrador.cifrar(textoPlano.Text, int.Parse(comboDesplazamiento.SelectedValue.ToString()));
                textoCifrado.Text = cifrado;
            } else {
                if (comboDesplazamiento.SelectedValue == null && cifrarCesar) {
                    mostrarMensaje("Error desplazamiento", "Primero debes seleccionar un desplazamiento!");
                }
            }
        }

        private void textoCifrado_TextChanged(object sender, TextChangedEventArgs e) {
            if (!cifrarCesar && comboDesplazamiento.SelectedValue != null) {
                string descifrado = cifrador.descifrar(textoCifrado.Text, int.Parse(comboDesplazamiento.SelectedValue.ToString()));
                textoPlano.Text = descifrado;
            } else {
                if (comboDesplazamiento.SelectedValue == null && !cifrarCesar) {
                    mostrarMensaje("Error desplazamiento", "Primero debes seleccionar un desplazamiento!");
                }
            }
        }
        /*Playfair*/
        private void claveCifradoPlayfair_TextChanged(object sender, TextChangedEventArgs e) {
            if (claveCifradoPlayfair.Text != "") {
                string hola = claveCifradoPlayfair.Text.ToUpper();
                playfair.generarMatriz(hola);
                matriz = playfair.getMatriz();

                _0.Content = matriz[0, 0];
                _1.Content = matriz[0, 1];
                _2.Content = matriz[0, 2];
                _3.Content = matriz[0, 3];
                _4.Content = matriz[0, 4];

                _5.Content = matriz[1, 0];
                _6.Content = matriz[1, 1];
                _7.Content = matriz[1, 2];
                _8.Content = matriz[1, 3];
                _9.Content = matriz[1, 4];

                _10.Content = matriz[2, 0];
                _11.Content = matriz[2, 1];
                _12.Content = matriz[2, 2];
                _13.Content = matriz[2, 3];
                _14.Content = matriz[2, 4];

                _15.Content = matriz[3, 0];
                _16.Content = matriz[3, 1];
                _17.Content = matriz[3, 2];
                _18.Content = matriz[3, 3];
                _19.Content = matriz[3, 4];

                _20.Content = matriz[4, 0];
                _21.Content = matriz[4, 1];
                _22.Content = matriz[4, 2];
                _23.Content = matriz[4, 3];
                _24.Content = matriz[4, 4];

                if (cifrarPlayfair) {
                    textoPlanoPlayfair_TextChanged(null,null);
                } else {
                    textoCifradoPlayfair_TextChanged(null, null);
                }

            }
        }

        private void cambiarDescifrarPlayfair(object sender, RoutedEventArgs e) {
            imagenSubirPlayfair.Opacity = 0.6;
            imagenBajarPlayfair.Opacity = 0;
            cifrarPlayfair = false;
        }

        private void cambiarCifrarPlayfair(object sender, RoutedEventArgs e) {
            imagenSubirPlayfair.Opacity = 0;
            imagenBajarPlayfair.Opacity = 0.6;
            cifrarPlayfair = true;
        }

        private void textoPlanoPlayfair_TextChanged(object sender, TextChangedEventArgs e) {
            if (cifrarPlayfair && matriz != null) {
                string cifrado = playfair.cifrar(textoPlanoPlayfair.Text, claveCifradoPlayfair.Text.ToUpper());
                textoCifradoPlayfair.Text = cifrado;
            }
            if (matriz == null) {
                mostrarMensaje("No hay clave!", "Necesitas escribir una clave de cifrado primero. Con ella se generá la matriz de cifrado.");
            }
        }

        private async void mostrarMensaje(string titulo, string mensaje) {
            await this.ShowMessageAsync(titulo, mensaje);
        }

        private void textoCifradoPlayfair_TextChanged(object sender, TextChangedEventArgs e) {
            if (!cifrarPlayfair && ((textoCifradoPlayfair.Text.Length % 2) == 0) && matriz != null) {
                string descifrado = playfair.descifrar(textoCifradoPlayfair.Text.ToUpper(), claveCifradoPlayfair.Text.ToUpper());
                textoPlanoPlayfair.Text = descifrado;
            }
            if (matriz == null) {
                mostrarMensaje("No hay clave!", "Necesitas escribir una clave de cifrado primero. Con ella se generá la matriz de cifrado.");
            }
        }

    }
}
