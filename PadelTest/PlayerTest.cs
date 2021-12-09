using Xunit;
using Padel;

namespace PadelTest
{
    public class PlayerTest
    {
        //Frans Nilsson Lidström, Ghasem Soltani, Sophie Lindström, Pontus Hedman

        /// <summary>
        /// Tests in parameters match with Player.Name
        /// </summary>
        [Fact]
        public void PlayerNameTest()
        {
            Player player = new Player("Gustaf");

            Assert.NotNull(player.Name);
            Assert.NotEmpty(player.Name);
            Assert.Equal("Gustaf", player.Name);
        }

        /// <summary>
        /// Tests Player.Point()
        /// </summary>
        [Fact]
        public void PlayerPointScore()
        {
            Player player = new Player("David");

            player.Point();

            Assert.Equal(1, player.Score._Score);
        }
    }
}
