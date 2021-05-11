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

namespace EthanDeGuzman_S00199053
{
    /*========================================================================
        Name: Ethan De Guzman
        Student Number: S00199053
        Github Link: https://github.com/EthanDeguzman/EthanDeGuzman_S00199053
     =========================================================================*/
    public partial class MainWindow : Window
    {

        GameData db = new GameData();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] Sort = { "PC", "Xbox", "PS", "Switch" };
            filterPlatform.ItemsSource = Sort;

            var query = from g in db.Game
                        select g;

            lstGame.ItemsSource = query.ToList();
        }

        private void lstGame_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Game selectedGame = lstGame.SelectedItem as Game;

            if (selectedGame != null)
            {
                tblkDetails.Text = string.Format(
                $"Game Name: {selectedGame.Name}" + $"\nDescription: {selectedGame.Description}"
                + $"\nPlatform: {selectedGame.Platform}" + $"\nPrice: {selectedGame.Price}"
                );
            }
        }

        private void filterPlatform_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedPlatform = filterPlatform.SelectedItem as string;

            if (selectedPlatform == "PC")
            {
                var query = from g in db.Game
                            where g.Platform.Contains("PC")
                            select g;

                lstGame.ItemsSource = null;
                lstGame.ItemsSource = query.ToList();
            }
            else if (selectedPlatform == "Xbox")
            {
                var query = from g in db.Game
                            where g.Platform.Contains("Xbox")
                            select g;

                lstGame.ItemsSource = null;
                lstGame.ItemsSource = query.ToList();
            }
            else if (selectedPlatform == "PS")
            {
                var query = from g in db.Game
                            where g.Platform.Contains("PS")
                            select g;

                lstGame.ItemsSource = null;
                lstGame.ItemsSource = query.ToList();
            }
            else if (selectedPlatform == "Switch")
            {
                var query = from g in db.Game
                            where g.Platform.Contains("Switch")
                            select g;

                lstGame.ItemsSource = null;
                lstGame.ItemsSource = query.ToList();
            }
            else
            {
                var query = from g in db.Game
                            select g;

                lstGame.ItemsSource = null;
                lstGame.ItemsSource = query.ToList();
            }
        }
    }
}
