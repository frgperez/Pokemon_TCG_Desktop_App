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
using System.Configuration;

using System.IO;
using System.Text.RegularExpressions;

namespace PokemonTCGApp
{
    /// <summary>
    /// Interaction logic for PokemonGenerationsPage.xaml
    /// </summary>
    public partial class PokemonGenerationsPage : Page
    {
        DirectoryInfo dir; 
        List<string> imgList = new List<string>();
        String folderName = "";

        public PokemonGenerationsPage()
        {
            InitializeComponent();
        }

        //Creates grid with Pokemon cards
        void createGrid()
        {
            int pkmnCardCount = 0;
            int rowCount = imgList.Count / 5;
            int colCount = 0;

            if (rowCount <= 0) {
                rowCount = 1;
            }
            if (imgList.Count >= 5)
            {
                colCount = 4;
            }
            else {
                colCount = imgList.Count - 1;
            }

            imgGrid.HorizontalAlignment = HorizontalAlignment.Left;
            imgGrid.VerticalAlignment = VerticalAlignment.Top;
            //imgGrid.ShowGridLines = true;
            imgGrid.Margin = new Thickness(60, 50, 0, 0);

            for (int j = 0; j < rowCount; j++)
            {
                RowDefinition rowDef = new RowDefinition();
                imgGrid.RowDefinitions.Add(rowDef);
                for (int i = 0; i <= colCount; i++)
                {
                    Image pkmnCard = new Image();

                    ColumnDefinition colDef = new ColumnDefinition();
                    imgGrid.ColumnDefinitions.Add(colDef);

                    rowDef.Height = new GridLength(352);
                    colDef.Width = new GridLength(255);

                    //BUTTON STUFF
                    Button btn = new Button();
                    btn.Height = 342;
                    btn.Width = 245;
                    btn.Name = "PKMN_" + pkmnCardCount;
                    btn.Tag = getTag(btn.Name);
                    btn.Cursor = Cursors.Hand;
                    setBtnContent(btn.Tag.ToString(), pkmnCardCount, btn);
                    btn.Click += btn1_Click;
                    Grid.SetColumn(btn, i);
                    Grid.SetRow(btn, j);

                    imgGrid.Children.Add(btn);

                    pkmnCardCount++;
                }
            }

            pkmnCardCount = 0;
        }

        //Gets tag from .settings folder when creating grid
        public string getTag(string cardName) {
            switch (folderName) {
                case "Generations":
                    foreach (SettingsProperty currProperty in Properties.Generations.Default.Properties){
                        if (cardName == currProperty.Name){
                            return Properties.Generations.Default[currProperty.Name].ToString();
                        }
                    }
                    break;
                case "XYPromo":
                    foreach (SettingsProperty currProperty in Properties.XYPromo.Default.Properties) {
                        if (cardName == currProperty.Name) {
                            return Properties.XYPromo.Default[currProperty.Name].ToString();
                        }
                    }
                    break;
                default:
                    return "true";
            }
            return "true";
        }

        // Modifies button content
        // true = turn img normal
        // false = turn img gray
        public void setBtnContent(string cardTag, int count, Button pkmnBtn)
        {
            Image tempImg = new Image();
            if (cardTag == "true")
            {
                tempImg.Source = getPKMNCard(count);
                pkmnBtn.Content = tempImg;
            }
            else {
                tempImg.Source = turnImgGray(count);
                pkmnBtn.Content = tempImg;
            }
        }

        //Saves tag when modified
        public void saveTag(string cardName, string cardTag) {
            switch (folderName) {
                case "Generations":
                    foreach (SettingsProperty currProperty in Properties.Generations.Default.Properties) {
                        if (cardName == currProperty.Name) {
                            Properties.Generations.Default[currProperty.Name] = cardTag;
                            Properties.Generations.Default.Save();
                        }
                    }
                    break;
                case "XYPromo":
                    foreach (SettingsProperty currProperty in Properties.XYPromo.Default.Properties) {
                        if (cardName == currProperty.Name) {
                            Properties.XYPromo.Default[currProperty.Name] = cardTag;
                            Properties.XYPromo.Default.Save();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        //Goes through dir of card set, grabs imgs names and adds to list
        void getImagesNames()
        {
            foreach (var imgFiles in dir.GetFiles())
            {
                imgList.Add(imgFiles.Name);
            }
        }

        //Returns single img of PKMN card
        BitmapImage getPKMNCard(int count)
        {
            //Console.WriteLine(count);
            BitmapImage b = new BitmapImage();
            b.BeginInit();
            b.UriSource = new Uri(dir + "\\" + imgList[count], UriKind.RelativeOrAbsolute);
            b.EndInit();

            return b;
        }

        //Turns single PKMN card img gray
        FormatConvertedBitmap turnImgGray(int count)
        {
            BitmapImage pkmnCard = getPKMNCard(count);

            FormatConvertedBitmap grayBitmap = new FormatConvertedBitmap();
            grayBitmap.BeginInit();
            grayBitmap.Source = pkmnCard;
            grayBitmap.DestinationFormat = PixelFormats.Gray8;
            grayBitmap.EndInit();

            return grayBitmap;
        }

        //Does stuff when Pokemon Card is clicked
        //Turns card gray/normal, flips tag, saves tag
        private void btn1_Click(object sender, RoutedEventArgs e)
        {
            Button btnClicked = (Button)sender;
            string strPKMNCardIndex = Regex.Match(btnClicked.Name, @"\d+").Value;
            int pkmnCardIndex = Int32.Parse(strPKMNCardIndex);
            Image pkmnCard = new Image();

            if (btnClicked.Tag.ToString() == "true"){
                pkmnCard.Source = turnImgGray(pkmnCardIndex);
                btnClicked.Tag = "false";
                saveTag(btnClicked.Name, btnClicked.Tag.ToString());
            }
            else {
                pkmnCard.Source = getPKMNCard(pkmnCardIndex);
                btnClicked.Tag = "true";
                saveTag(btnClicked.Name, btnClicked.Tag.ToString());
            }

            btnClicked.Content = pkmnCard;
        }

        //Called once selection is made from previous page with list box
        public PokemonGenerationsPage(object data, string fldr):this()
        {
            this.DataContext = data;
            folderName = fldr;
            dir = new DirectoryInfo(Environment.CurrentDirectory + "\\Images\\" + folderName);

            getImagesNames();
            createGrid();
        }
    }
}
