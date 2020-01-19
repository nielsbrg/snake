namespace Snake.Application.Renderers
{
    using Snake.Domain;
    using System.Drawing;
    using System.Drawing.Drawing2D;

    public class SnakeRenderer : IRenderer
    {
        private readonly Snake snake;
        private readonly SolidBrush bodyPartBrush;
        private readonly SolidBrush headBrush;

        public SnakeRenderer(Snake snake)
        {
            var settings = Properties.Settings.Default;
            this.snake = snake;
            this.bodyPartBrush = new SolidBrush(settings.BodyColor);
            this.headBrush = new SolidBrush(settings.HeadColor);
        }

        public void Render(Graphics graphics)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            RenderSnakeHead(graphics, snake.Parts[0]);

            for(var i = 1; i < snake.Parts.Count; i++)
            {
                RenderSnakePart(graphics, snake.Parts[i]);
            }
        }

        private void RenderSnakeHead(Graphics graphics, SnakePart head)
        {
            var rect = new Rectangle(head.Position.X, head.Position.Y, head.Width, head.Height);
            graphics.FillEllipse(headBrush, rect);
        }

        private void RenderSnakePart(Graphics graphics, SnakePart bodyPart)
        {
            var rect = new Rectangle(bodyPart.Position.X, bodyPart.Position.Y, bodyPart.Width, bodyPart.Height);
            graphics.FillRectangle(bodyPartBrush, rect);
        }
    }
}
