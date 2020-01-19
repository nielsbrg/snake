namespace Snake.Application.Renderers
{
    using Snake.Application.Game;
    using System.Drawing;
    using System.Windows.Forms;

    public class ScoreRenderer : IRenderer
    {
        private readonly Label label;
        private readonly ScoreController scoreController;

        public ScoreRenderer(Label label, ScoreController scoreController)
        {
            this.label = label;
            this.scoreController = scoreController;
        }

        public void Render(Graphics g)
        {
            var score = scoreController.Score.ScoreAmount;
            label.Text = $"{score}";
            label.Invalidate();
        }
    }
}
