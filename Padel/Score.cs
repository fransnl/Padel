using System;

namespace Padel
{
    public class Score
    {
        public int _Score;

        public void Increase()
        {
            if (_Score < 30)
            {
                _Score += 15;
            }
            else
            {
                _Score += 10;

            }
        }
    }
}
