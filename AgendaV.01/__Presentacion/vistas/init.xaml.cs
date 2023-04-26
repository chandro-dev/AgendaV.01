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
using Logica;
using Entidades;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting;

namespace __Presentacion.vistas
{
    /// <summary>
    /// Lógica de interacción para init.xaml
    /// </summary>
    /// 
    public partial class init : Page
    {
        ServicioContactoFamiliar ser_contct_familiar;
        private ContactoFamiliar change_contc;
        public init()
        {
            InitializeComponent();
            ser_contct_familiar = new ServicioContactoFamiliar();
            Datos.ItemsSource = ser_contct_familiar.GetAll();
            
            btnActualizar.IsEnabled = false;
            btnEliminar.IsEnabled=false;
            btnGuardar.IsEnabled = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!ser_contct_familiar.Exist(new ContactoFamiliar { Id = int.Parse(txtTelefono.Text.ToString()), Nombre = txtNombre.Text, Telefono = txtTelefono.Text.ToString(), FechaNacimiento = DateTime.Now })){
                ser_contct_familiar.Add(new ContactoFamiliar { Id = int.Parse(txtTelefono.Text.ToString()), Nombre = txtNombre.Text, Telefono = txtTelefono.Text.ToString(), FechaNacimiento = DateTime.Now });
                Datos.ItemsSource = ser_contct_familiar.GetAll();
                txtTelefono.Text = string.Empty;
                txtNombre.Text = string.Empty;
            }
            else
            {

                MessageBox.Show("Ya existe");
            }
                
        }
        private  void KDTelefono(object sender, RoutedEventArgs e)
        {
            btnGuardar.IsEnabled = true;
            try
            {
                Datos.ItemsSource = ser_contct_familiar.GetByPhone(txtTelefono.Text);
            }
            catch
            {
            }
            }
        private void   KDNombre(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == string.Empty || txtNombre.Text.StartsWith(" ") || txtNombre.Text.Contains(" "))
            {
                btnGuardar.IsEnabled = false;
            }
            else
            {
                try
                {
                    Datos.ItemsSource = ser_contct_familiar.GetByName(txtNombre.Text);
                }
                catch
                {

                }
                btnGuardar.IsEnabled = true;

            }
        }

        private void Datos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            btnActualizar.IsEnabled = true;
            btnEliminar.IsEnabled = true;
            btnGuardar.IsEnabled = false;
            
            try
            {
                if (Datos.SelectedItem !=null)
                {
                    change_contc = (ContactoFamiliar)Datos.SelectedItem;
                    txtNombre.Text = change_contc.Nombre;
                    txtTelefono.Text = change_contc.Telefono;
                }
            }
            catch(Exception )
            {
                
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (change_contc != null && ser_contct_familiar.Delete(change_contc)) {
                change_contc = null;
            }
            Datos.ItemsSource = ser_contct_familiar.GetAll();
            txtTelefono.Text = string.Empty;
            txtNombre.Text = string.Empty;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (change_contc != null)
            {
                change_contc.Telefono = txtTelefono.Text;
                change_contc.Nombre = txtNombre.Text;
                if (ser_contct_familiar.Update(change_contc))
                {
                    change_contc = null;
                    txtTelefono.Text = string.Empty;
                    txtNombre.Text = string.Empty;
                }
            }
            Datos.ItemsSource = ser_contct_familiar.GetAll();

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new FRE());
        }
    }
}
