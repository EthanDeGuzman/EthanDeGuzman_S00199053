using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EthanDeGuzman_S00199053
{
    public class Game
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double CriticScore { get; set; }
        public string Description { get; set; }
        public string Platform { get; set; }
        public decimal Price { get; set; }
        public string Game_Image { get; set; }

        public void DecreasePrice(double number)
        {
            Price -= (decimal) number;
        }
    }

    public class GameData : DbContext
    {
        public GameData() : base("MyGameData") { }

        public DbSet<Game> Game { get; set; }
    }
}
