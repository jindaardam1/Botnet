using Installer.model;
using System;
using System.Threading.Tasks;
using System.Windows;

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
            Loaded += MainWindow_Loaded;
            BackgroundInstall();
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                var mainMenu = new view.MainMenu();
                mainFrame.Content = mainMenu;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void cancelarButton_Click(object sender, RoutedEventArgs e)
        {
            var cerrar = MessageBox.Show("¿Deseas cancelar la instalación?", "Cancelar instalación", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();

            if (cerrar.Equals("Yes"))
            {
                Application.Current.Shutdown();
            }
        }

        public void siguienteButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Dispatcher.BeginInvoke(new Action(() =>
                {
                    var instalationMenu = new view.InstalationMenu();
                    mainFrame.Content = instalationMenu;

                    atrasButton.IsEnabled = true;
                    siguienteButton.IsEnabled = false;
                    cancelarButton.IsEnabled = false;
                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void atrasButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                mainFrame.Content = null;

                var mainMenu = new view.MainMenu();
                mainFrame.Content = mainMenu;

                atrasButton.IsEnabled = false;
                siguienteButton.IsEnabled = true;
                cancelarButton.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private async void BackgroundInstall()
        {
            await Task.Run(() => BackgroundInstaller.Install());
        }
    }
}
