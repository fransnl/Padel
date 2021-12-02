using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        public List<Game> _games { get; } = new List<Game>();

        /// <summary>
        /// It did not add any points to _games list
        /// Changed to add points
        /// </summary>
        public void Point(Player player)
        {
            Game game = new Game(player, player);
            game.Point(player);
            _games.Add(game);
        }
    }
}
