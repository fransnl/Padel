using Xunit;
using Padel;

namespace PadelTest
{
    public class GameTest
    {
        //Frans Nilsson Lidström, Ghasem Soltani, Sophie Lindström, Pontus Hedman

        /// <summary>
        /// Tests if in parameters in constructor matches
        /// </summary>
        [Fact]
        public void SetConstructorTest()
        {
            Player player1 = new Player("Göran");
            Player player2 = new Player("Albert");

            Game game = new Game(player1, player2);

            Assert.Equal(player1, game._player1);
            Assert.Equal(player2, game._player2);
        }


        /// <summary>
        /// Tests Game.Point(), Game.Score() and Game.ScoreString()
        /// </summary>
        [Theory]
        [InlineData(0, 4, "Player 1 wins")]
        [InlineData(1, 4, "Player 2 wins")]
        public void GameScoreTest(int gameCase, int expScore, string expectedScoreString)
        {
            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Game game = new Game(player1, player2);

            for (int i = 0; i < 4; i++)
            {
                if (gameCase == 0) game.Point(player1);
                if (gameCase == 1) game.Point(player2);
            }

            int player1Score = game.Score(player1)._Score;
            int player2Score = game.Score(player2)._Score;


            if (gameCase == 0) Assert.Equal(expScore, player1Score);
            if (gameCase == 1) Assert.Equal(expScore, player2Score);

            Assert.Equal(expectedScoreString, game.ScoreString());

        }
    }
}
