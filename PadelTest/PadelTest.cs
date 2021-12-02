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
        #endregion

        #region Set test
        /// <summary>
        /// Returned false, list was out of bounds
        /// Changed Set.Point() method
        /// </summary>
        [Fact]
        public void SetListTest() 
        {
            Set set = new Set();

            for (int i = 0; i < 3; i++)
            {
                set.Point(new Player("Lars"));
            }

            Assert.Equal(3, set._games.Count);
        }

        [Theory]
        [InlineData(3, 0, 40, 0)]
        [InlineData(0, 3, 0, 40)]
        [InlineData(2, 1, 30, 15)]
        public void SetPointTest(int player1GameScore, int player2GameScore, int player1Expected, int player2Expected) 
        {
            int player1TotScore = 0;
            int player2TotScore = 0;

            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Set set = new Set();

            for (int i = 0; i < player1GameScore; i++)
            {
                set.Point(player1);
                player1TotScore = set._games[i].Score(player1)._Score;
            }
            for (int i = 0; i < player2GameScore; i++)
            {
                set.Point(player2);
                player2TotScore = set._games[i].Score(player2)._Score;
            }

            Assert.Equal(player1Expected, player1TotScore);
            Assert.Equal(player2Expected, player2TotScore);
        }
        #endregion

        #region Game Class
        [Theory]
        [InlineData(0, 50, "Player 1 wins")]
        [InlineData(1, 50, "Player 2 wins")]
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
            yield return new object[] { 1, 15 };
            yield return new object[] { 2, 30 };
            yield return new object[] { 3, 40 };
        }
    }
}
