using System;
using System.Collections.Generic;

namespace Padel
{
    public class Set
    {
        //changed to property to access in test
        public List<Game> _games { get; } = new List<Game>();

        public void Point(Player player)
        {
            _games[0].Point(player);
        }
    }
}
