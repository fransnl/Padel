using System;

namespace Padel
{
    public class Player
    {
        //Made properties to access in test
        public string Name { private set; get; }
        //instantiated new score, otherwise we get ObjectNullException
        public Score Score { private set; get; } = new Score();
        
        public Player(string name)
        {
            Name = name;
        }
        
        public void Point()
        {
            Score.Increase();
        }
    }
}
