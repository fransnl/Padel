using Xunit;
using Padel;

namespace PadelTest
{
    public class ScoreTest
    {
        //Frans Nilsson Lidström, Ghasem Soltani, Sophie Lindström, Pontus Hedman

        /// <summary>
        /// Tests Score.Increases() 
        /// </summary>
        [Fact]
        public void TestScore()
        {
            Score score = new Score();
            
            score.Increase();

            Assert.Equal(1, score._Score);
        }
    }
}
