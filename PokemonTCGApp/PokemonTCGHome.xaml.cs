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

using System.IO;

namespace PokemonTCGApp
{
    /// <summary>
    /// Interaction logic for PokemonTCGHome.xaml
    /// </summary>
    public partial class PokemonTCGHome : Page
    {
        public PokemonTCGHome()
        {
            InitializeComponent();            
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            string folderName = setListBox.SelectedValue.ToString();

            PokemonGenerationsPage pkmnGensPage = new PokemonGenerationsPage(this.setListBox.SelectedItem, folderName);
            this.NavigationService.Navigate(pkmnGensPage);
        }      
    }
}
