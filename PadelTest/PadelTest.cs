using System;
using Xunit;
using Padel;
using System.Collections.Generic;

namespace PadelTest
{
    public class PadelTest
    {
        #region Match test
        [Fact]
        public void MatchListTest()
        {
            Player player = new Player("Sten");

            Match match = new Match(3, player, new Player("Göran"));

            for (int i = 0; i < 3; i++)
            {
                match.Point(player);
            }

            Assert.Equal(3, match._sets.Count);
        }
        
        [Fact]
        public void MatchScoreTest() 
        {
            
        }

        #endregion

        #region Set test
        /// <summary>
        /// Calls set.Point method for one player and both players
        /// Compares the expected score to score in list _game on the 0 position
        /// </summary>
        [Theory]
        [InlineData(1, 0, 1, 0)]
        //[InlineData(0, 1, 1, 0)]
        //[InlineData(1, 1, 1, 1)]
        public void SetPointTest(int player1GameScore, int player2GameScore, int player1Expected, int player2Expected) 
        {

            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Set set = new Set();

            if (player1GameScore > 0 )
            {
                set.Point(player1);
                int player1TotScore = set._games[0].Score(player1)._Score;
                Assert.Equal(player1Expected, player1TotScore);
            }
            if (player2GameScore > 0)
            {
                set.Point(player2);
                int player2TotScore = set._games[0].Score(player2)._Score;
                Assert.Equal(player2Expected, player2TotScore);
            }


        }
        #endregion

        #region Game Class
        [Theory]
        [InlineData(0, 4, "Player 1 wins")]
        [InlineData(1, 4, "Player 2 wins")]
        public void GameTest(int gameCase, int expScore, string expectedScoreString) 
        {
            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Game game = new Game(player1, player2);

            for (int i = 0; i < 4; i++)
            {
                if (gameCase == 0) game.Point(player1);
                if (gameCase == 1) game.Point(player2);
            }

            if (gameCase == 0) Assert.Equal(expScore, game.Score(player1)._Score);
            if (gameCase == 1) Assert.Equal(expScore, game.Score(player2)._Score);

            Assert.Equal(expectedScoreString, game.ScoreString());
            
        }
        #endregion

        #region Player class
        [Fact]
        public void PlayerName() 
        {
            Player player = new Player("Gustaf");

            Assert.NotNull(player.Name);
            Assert.NotEmpty(player.Name);
        }

        [Theory]
        [MemberData(nameof(ScoreData))]
        public void PlayerPointScore(int nrOfTimes, int expected)
        {
            Player player = new Player("David");
            
            for (int j = 0; j < nrOfTimes; j++)
            {
                player.Point();
            }

            Assert.Equal(expected, player.Score._Score);
        }
        #endregion

        #region Score class
        [Theory]
        [MemberData(nameof(ScoreData))]
        public void TestScore(int nrOfTimes, int expected) 
        {
            Score score = new Score();
            
            for (int j = 0; j < nrOfTimes; j++)
            {
                score.Increase();
            }

            Assert.Equal(expected, score._Score);
        }
        #endregion

        /// <summary>
        /// Test values for TestScore() and PlayerPointScore()
        /// Value 0: nr of times to call the method that increases the score
        /// Value 1: expected value
        /// </summary>
        public static IEnumerable<object[]> ScoreData()
        {
            yield return new object[] { 1, 1 };
            yield return new object[] { 2, 2 };
            yield return new object[] { 3, 3 };
        }
    }
}
