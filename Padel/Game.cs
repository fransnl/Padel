using System;

namespace Padel
{
    public class Game
    {
        //made properties to access in test
        public Player _player1 { get; }
        public Player _player2 { get; }

        public Game(Player player1, Player player2)
        {
            _player1 = player1;
            _player2 = player2;
        }

        //changed to give point to player in the in parameter instead of just _player1
        public void Point(Player player)
        {
            player.Point();
        }

        //changed to return in parameter player score instead of _player1 score
        public Score Score(Player player)
        {
            return player.Score;
        }

        //changed to _player1.Score._Score > 3 because you win a game with 15+15+10
        public string ScoreString()
        {
            if (_player1.Score._Score > 3)
            {
                return "Player 1 wins";
            }

            return "Player 2 wins";
        }
    }
}
