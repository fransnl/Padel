using Xunit;
using Padel;

namespace PadelTest
{
    public class SetTest
    {
        //Frans Nilsson Lidström, Ghasem Soltani, Sophie Lindström, Pontus Hedman

        /// <summary>
        /// Tests if 6 games in list, there are 6 games per set
        /// </summary>
        [Fact]
        public void SetListTest()
        {
            Set set = new Set(new Player("Göran"), new Player("Albert"));

            Assert.Equal(6, set._games.Count);
        }

        /// <summary>
        /// Testing player in parameters in constructor to match
        /// </summary>
        [Fact]
        public void SetConstructorTest() 
        {
            Player player1 = new Player("Göran");
            Player player2 = new Player("Albert");

            Set set = new Set(player1, player2);

            Assert.Equal(player1, set._player1);
            Assert.Equal(player2, set._player2);
        }

        /// <summary>
        /// Calls set.Point method for one player and both players
        /// Compares the expected score to score in list _game on the 0 position
        /// </summary>
        [Theory]
        [InlineData(1, 0, 1, 0)]
        [InlineData(1, 1, 1, 0)]
        public void SetPointTest(int player1GameScore, int player2GameScore, int player1Expected, int player2Expected)
        {

            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Set set = new Set(player1, player2);

            if (player1GameScore == 1)
            {
                set.Point(player1);
            }
            if (player2GameScore == 1)
            {
                set.Point(player2);
            }

            int player1Score = set._games[0].Score(player1)._Score;
            int player2Score = set._games[0].Score(player2)._Score;
            
            Assert.Equal(player1Expected, player1Score);
            Assert.Equal(player2Expected, player2Score);
        }
    }
}
