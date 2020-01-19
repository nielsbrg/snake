namespace Snake.Application.Renderers
{
    using Game;
    using Snake.Domain;
    using System.Drawing;

    public class SnakeFoodRenderer : IRenderer
    {
        public SnakeFoodController snakeFoodController;

        public SolidBrush foodBrush;

        public SnakeFoodRenderer(SnakeFoodController snakeFoodController)
        {
            this.snakeFoodController = snakeFoodController;
            this.foodBrush = new SolidBrush(Color.Red);
        }

        public void Render(Graphics g)
        {
            snakeFoodController.ActiveFoods.ForEach(snakeFood =>
            {
                RenderSnakeFood(g, snakeFood);
            });
        }

        private void RenderSnakeFood(Graphics g, SnakeFood snakeFood)
        {
            var rect = new Rectangle(snakeFood.Position.X, snakeFood.Position.Y, snakeFood.Width, snakeFood.Height);
            g.FillEllipse(foodBrush, rect);
        }
    }
}
