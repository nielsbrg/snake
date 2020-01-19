namespace Snake.Domain
{
    public class Score
    {
        public int ScoreAmount { get; private set; }

        public void Add(int score)
        {
            ScoreAmount += score;
        }

        public void Subtract(int score)
        {
            ScoreAmount -= score;
        }
    }
}
