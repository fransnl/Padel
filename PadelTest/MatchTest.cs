using Xunit;
using Padel;
using System.Collections.Generic;

namespace PadelTest
{
    public class MatchTest
    {
        //Frans Nilsson Lidström, Ghasem Soltani, Sophie Lindström, Pontus Hedman

        [Fact]
        public void MatchListTest()
        {
            Match match = new Match(3, new Player("Sten"), new Player("Göran"));
            
            Assert.Equal(3, match._sets.Count);
        }

        /// <summary>
        /// Testing player in parameters in constructor to match
        /// </summary>
        [Fact]
        public void MatchConstructorTest()
        {
            Player player1 = new Player("Göran");
            Player player2 = new Player("Albert");

            Match match = new Match(3,player1, player2);

            Assert.Equal(player1, match._player1);
            Assert.Equal(player2, match._player2);
        }

        /// <summary>
        /// Calls Match.Point() method for one player and both players
        /// Compares the expected score to score in list _set on the 0 position
        /// </summary>
        [Theory]
        [InlineData(1, 0, 1, 0)]
        [InlineData(1, 1, 1, 0)]
        public void SetPointTest(int player1SetScore, int player2SetScore, int player1Expected, int player2Expected)
        {

            Player player1 = new Player("Sten");
            Player player2 = new Player("Bertil");

            Match match = new Match(3, player1, player2);

            if (player1SetScore == 1)
            {
                match.Point(player1);
            }
            if (player2SetScore == 1)
            {
                match.Point(player2);
            }

            int player1Score = match._sets[0]._games[0].Score(player1)._Score;
            int player2Score = match._sets[0]._games[0].Score(player2)._Score;

            Assert.Equal(player1Expected, player1Score);
            Assert.Equal(player2Expected, player2Score);
        }

        [Fact]
        public void MatchScoreTest()
        {
            Match match = new Match(3, new Player("Göran"), new Player("Sten"));

            var matchScore = match.MatchScore();

            matchScore.Increase();

            Assert.Equal(1, matchScore._Score);
        }
    }
}
