using Installer.utils;
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
using System.Windows.Shapes;

namespace Installer.viewmodel
{
    /// <summary>
    /// Lógica de interacción para SelectLenguage.xaml
    /// </summary>
    public partial class SelectLenguage : Window
    {
        public SelectLenguage()
        {
            InitializeComponent();

            foreach (Languages language in Enum.GetValues(typeof(Languages)))
            {
                comboBoxLenguages.Items.Add(language);
            }

            comboBoxLenguages.SelectedIndex = 0;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string selectedLanguageText = comboBoxLenguages.SelectedItem.ToString();

            Languages selectedLanguage;

            if (Enum.TryParse(selectedLanguageText, out selectedLanguage))
            {
                switch (selectedLanguage)
                {
                    case Languages.Spanish:
                        App.TextResource = new TextResources(Languages.Spanish);
                        break;
                    case Languages.French:
                        App.TextResource = new TextResources(Languages.French);
                        break;
                    case Languages.Italian:
                        App.TextResource = new TextResources(Languages.Italian);
                        break;
                    case Languages.Portuguese:
                        App.TextResource = new TextResources(Languages.Portuguese);
                        break;
                    case Languages.English:
                        App.TextResource = new TextResources(Languages.English);
                        break;
                    case Languages.German:
                        App.TextResource = new TextResources(Languages.German);
                        break;
                    case Languages.Russian:
                        App.TextResource = new TextResources(Languages.Russian);
                        break;
                    case Languages.Japanese:
                        App.TextResource = new TextResources(Languages.Japanese);
                        break;
                    case Languages.Hindi:
                        App.TextResource = new TextResources(Languages.Hindi);
                        break;
                    case Languages.Chinese:
                        App.TextResource = new TextResources(Languages.Chinese);
                        break;
                    case Languages.Korean:
                        App.TextResource = new TextResources(Languages.Korean);
                        break;
                    default:
                        MessageBox.Show("Error: Invalid language selected.");
                        return;
                }

                OpenMainMenu();

                Close();
            }
            else
            {
                MessageBox.Show("Error: Invalid language selected.");
            }
        }

        private void OpenMainMenu()
        {
            MainWindow mw = new MainWindow();

            mw.Show();
        }
    }
}
