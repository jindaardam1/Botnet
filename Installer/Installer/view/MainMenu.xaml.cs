using Installer.utils;
using System.Windows;
using System.Windows.Controls;

namespace Installer.view
{
    /// <summary>
    /// Lógica de interacción para MainMenu.xaml
    /// </summary>
    public partial class MainMenu : UserControl
    {
        public MainMenu()
        {
            InitializeComponent();
            SetTexts();
        }

        private void SetTexts()
        {
            TextBlockHeader.Text = App.TextResource.GetTranslatedMainMenuHeaderText();

            CheckBoxTexts.ItemsSource = App.TextResource.GetTranslatedMainMenuCheckBoxTexts();
        }
    }
}
