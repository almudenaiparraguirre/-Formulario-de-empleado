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
using Microsoft.Win32;

namespace Formulario_de_empleados
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
                    // Carga la imagen seleccionada en el control de imagen
                    BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                    imagenPrevisualizacion.Source = bitmapImage;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message);
                }
            }
        }

        private void Txt_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    if (textBox.Name == "txtDireccion")
                    {
                        textBox.Text = "Dirección";
                    }
                    else if (textBox.Name == "txtCiudad") 
                    {
                        textBox.Text = "Ciudad";
                    }
                    else if (textBox.Name == "txtProvincia")
                    {
                        textBox.Text = "Provincia";
                    }
                    else if (textBox.Name == "txtCodigoPostal")
                    {
                        textBox.Text = "Codigo postal";
                    }
                    else if (textBox.Name == "txtPais")
                    {
                        textBox.Text = "País";
                    }
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }
    }
}
