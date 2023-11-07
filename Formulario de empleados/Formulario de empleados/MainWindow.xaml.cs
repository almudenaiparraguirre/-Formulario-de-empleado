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
        private List<Empleado> empleados = new List<Empleado>();
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = empleados;

            dataGrid.AutoGeneratingColumn += (sender, e) =>
            {
                // Cambia los anchos de las columnas según sea necesario
                if (e.PropertyName == "Nombre")
                {
                    e.Column.Width = 200; // Columna Nombre ocupa el espacio restante
                }
                else if (e.PropertyName == "Apellidos")
                {
                    e.Column.Width = 350; // Establece el ancho de la columna Apellidos a 200
                }
                else if (e.PropertyName == "Email")
                {
                    e.Column.Width = 200; // Establece el ancho de la columna Email a 150
                }
                else if (e.PropertyName == "Telefono")
                {
                    e.Column.Width = new DataGridLength(1, DataGridLengthUnitType.Star); // Establece el ancho de la columna Teléfono a 100
                }
            };
        }

        private void AgregarEmpleado(string nombre, string apellidos, string email, string telefono)
        {
            empleados.Add(new Empleado { Nombre = nombre, Apellidos = apellidos, Email = email, Telefono = telefono});
            dataGrid.Items.Refresh(); // Actualizar el DataGrid
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos los archivos|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                try
                {
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

        private void Txt_GotFocus(object sender, RoutedEventArgs e)
        {
            if (sender is TextBox textBox)
            {
                if (textBox.Text == "Dirección" || textBox.Text == "Ciudad" || textBox.Text == "Provincia" || textBox.Text == "Código Postal" || textBox.Text == "País")
                {
                    textBox.Clear();
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text;
            string apellidos = txtApellidos.Text;
            string email = txtEmail.Text;
            string telefono = txtTelefono.Text;

            AgregarEmpleado(nombre, apellidos, email, telefono);

            txtNombre.Clear();
            txtApellidos.Clear();
            txtEmail.Clear();
            txtTelefono.Clear();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public class Empleado
        {
            public string Nombre { get; set; }
            public string Apellidos { get; set; }
            public string Email { get; set; }

            public string Telefono { get; set; }
        }
    }
}
