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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Game> AllGames;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            GameData db = new GameData();

            var query = from g in db.Game
                        select g;

            AllGames = query.ToList();

            lstGame.ItemsSource = AllGames;
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
    }
}
