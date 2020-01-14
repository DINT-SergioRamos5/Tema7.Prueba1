using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
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

namespace Tema7.Prueba1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private BaseDatosInformeEntities contexto;
        private CLIENTE cliente;
        CollectionViewSource vista;
        ObservableCollection<CLIENTE> Clientes;

        public MainWindow()
        {
            contexto = new BaseDatosInformeEntities();
            vista = new CollectionViewSource();
            vista.Source = contexto.CLIENTES.Local;

            InitializeComponent();
            contexto.CLIENTES.Include("PEDIDOS").Load();
            ObservableCollection<CLIENTE> Clientes = contexto.CLIENTES.Local;
            
            ClientesListBox.DataContext = Clientes;
            ClienteEliminarComboBox.DataContext = Clientes;
            ClienteModificarComboBox.DataContext = Clientes;
            ClientesDataGrid.DataContext = Clientes; 
            
            InsertarStackPanel.DataContext = new CLIENTE();

            FilterDataGrid.DataContext = vista;
            vista.Filter += Vista_Filter;
        }

        private void Vista_Filter(object sender, FilterEventArgs e)
        {
            CLIENTE item = (CLIENTE)e.Item;

            if (FiltroTextBox.Text == "")
            {
                e.Accepted = true;
            }
            else
            {
                if (item.nombre.Contains(FiltroTextBox.Text))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }

        private void InsertarButton_Click(object sender, RoutedEventArgs e) 
        {
            contexto.CLIENTES.Add((CLIENTE)InsertarStackPanel.DataContext);
            contexto.SaveChanges();            
            InsertarStackPanel.DataContext = new CLIENTE();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.CLIENTES.Remove((CLIENTE)ClienteEliminarComboBox.SelectedItem);
            contexto.SaveChanges();
        }

        private void ModificarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.SaveChanges();
        }

        private void ActualizarButton_Click(object sender, RoutedEventArgs e)
        {
            contexto.SaveChanges();
        }

        private void FiltrarButton_Click(object sender, RoutedEventArgs e)
        {
            vista.View.Refresh();
        }
    }
}
