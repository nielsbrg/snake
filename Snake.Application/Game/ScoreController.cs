namespace Snake.Application.Game
{
    using Events;
    using Domain;
    using Properties;

    public class ScoreController : IObserver<FoodEatenEvent>
    {
        public Score Score { get; }

        public ScoreController(Score score)
        {
            this.Score = score;
        }

        public void HandleEvent(FoodEatenEvent e)
        {
            Score.Add(Settings.Default.FoodScoreIncrease);
        }
    }
}
