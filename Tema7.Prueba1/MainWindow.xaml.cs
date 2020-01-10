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

        public MainWindow()
        {
           cliente = new CLIENTE();
            InitializeComponent();

            contexto = new BaseDatosInformeEntities();

            contexto.CLIENTES.Load();

            ClientesListBox.DataContext = contexto.CLIENTES.Local;
            ClienteEliminarComboBox.DataContext = contexto.CLIENTES.Local;
            ClienteModificarComboBox.DataContext = contexto.CLIENTES.Local;

            InsertarStackPanel.DataContext = new CLIENTE();
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
    }
}
