using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        //changed to property to access in test
        public List<Game> _games { get; }
        public Player _player1;
        public Player _player2;

        //created a constructor that adds 6 games to _games, otherwise Point() gets out of range exeption
        public Set(Player player1, Player player2)
        {
            _games = new List<Game>(6);

            for (int i = 0; i < 6; i++)
            {
                _games.Add(new Game(player1, player2));
            }
            _player1 = player1;
            _player2 = player2;
        }

        //both players shouldnt be able to win a game
        public void Point(Player player)
        {
            if (player == _player1 && _games[0]._player2.Score._Score == 0) _games[0].Point(player);
            if (player == _player2 && _games[0]._player1.Score._Score == 0) _games[0].Point(player);
        }
    }
}
