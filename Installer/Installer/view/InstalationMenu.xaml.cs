using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Installer.view
{
    /// <summary>
    /// Lógica de interacción para InstalationMenu.xaml
    /// </summary>
    public partial class InstalationMenu : UserControl
    {
        public static ArrayList InstallationProgressComments = new ArrayList()
        {
            "Starting the installation...",
            "Preparing files...",
            "Installing components...",
            "Configuring options...",
            "Finishing the installation...",
            "Verifying system requirements...",
            "Checking for updates...",
            "Optimizing performance settings...",
            "Backing up existing data...",
            "Initializing installation process...",
            "Resolving dependencies...",
            "Applying patches...",
            "Setting up shortcuts...",
            "Configuring registry settings...",
            "Launching post-installation tasks..."
        };

        private readonly Random random = new Random();
        private static bool isStarted = false;

        public InstalationMenu()
        {
            InitializeComponent();
            Loaded += InstalationMenu_Loaded;
        }

        private void InstalationMenu_Loaded(object sender, RoutedEventArgs e)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;

            timer.Interval = TimeSpan.FromSeconds(0);

            progressBarInsallation.Maximum = InstallationProgressComments.Count - 1;
            progressBarInsallation.Minimum = 0;
            progressBarInsallation.Value = 0;

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                var mainWindow = Window.GetWindow(this) as MainWindow;

                if (mainWindow != null)
                {
                    var atrasButton = mainWindow.atrasButton;

                    if (atrasButton != null)
                    {
                        atrasButton.IsEnabled = false;
                    }
                }
                isStarted = true;
            }

            progressBarInsallation.Value++;

            if (progressBarInsallation.Value >= progressBarInsallation.Maximum)
            {
                ((DispatcherTimer)sender).Stop();

                MessageBox.Show("No se ha podido instalar el programa porque no es compatible con tu equipo.", "Error en la instalación", MessageBoxButton.OK, MessageBoxImage.Error);

                LoadFinalUserControl();
            }

            int index = random.Next(InstallationProgressComments.Count);
            string comment = (string)InstallationProgressComments[index];
            textBlockProgress.Text = comment;

            ((DispatcherTimer)sender).Interval = TimeSpan.FromSeconds(GetRandomInterval());
        }


        private double GetRandomInterval()
        {
            return random.NextDouble() * (1.3 - 0.4) + 0.4;
        }

        private void LoadFinalUserControl()
        {
            var mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {
                var atrasButton = mainWindow.atrasButton;
                var cancelarButton = mainWindow.cancelarButton;
                var siguienteButton = mainWindow.siguienteButton;

                if (atrasButton != null)
                {
                    atrasButton.Visibility = Visibility.Hidden;
                }

                if (cancelarButton != null)
                {
                    cancelarButton.Visibility = Visibility.Hidden;
                }

                if (siguienteButton != null)
                {
                    siguienteButton.Content = "Finalizar";
                    siguienteButton.IsEnabled = true;
                    siguienteButton.Click += CloseApp;
                }

                var mainFrame = mainWindow.mainFrame;

                if (mainFrame != null)
                {
                    try
                    {
                        var finalMenu = new FinalMenu();
                        mainFrame.Content = finalMenu;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }

        private void CloseApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
