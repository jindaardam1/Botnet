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

namespace Installer
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Instalar();
        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var cerrar = MessageBox.Show("¿Deseas cancelar la instalación?", "Cancelar instalación", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            if (cerrar.Equals("Yes"))
            {
                Application.Current.Shutdown();
            }
        }

        private void siguienteButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Instalar()
        {
            // TODO: Iniciar el proceso de instalación del malware de forma asíncrona.
        }
    }
}
