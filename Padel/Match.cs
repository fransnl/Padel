using System;
using System.Collections.Generic;

namespace Padel
{
    public class Match
    {
        //Made property to access in test
        public List<Set> _sets { get; }
        public Player _player1;
        public Player _player2;

        public Match(int numberOfSets, Player player1, Player player2)
        {
            _sets = new List<Set>(numberOfSets);
            for (int i = 0; i < numberOfSets; i++)
            {
                _sets.Add(new Set(player1, player2));
            }
            _player1 = player1;
            _player2 = player2;
        }

        //both players shouldnt be able to win a set
        public void Point(Player player)
        {
            if (player == _player1 && _sets[0]._player2.Score._Score == 0) _sets[0].Point(player);
            if (player == _player2 && _sets[0]._player1.Score._Score == 0) _sets[0].Point(player);
        }

        public Score MatchScore()
        {
            return new Score();
        }
    }
}
