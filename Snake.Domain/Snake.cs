namespace Snake.Domain
{
    using System.Collections.Generic;
    using Engine;

    public class Snake
    {
        public List<SnakePart> Parts { get; } = new List<SnakePart>();
        public SnakePart Head => Parts[0];
        public Vector2 Position => Parts[0].Position;
        public int PartSize => Head.Width;
        public MoveDirection CurrentDirection { get; private set; }
        public bool IsMoving { get; private set; }

        public int Speed { get; private set; }
        
        public Snake(SnakePart head, int speed)
        {
            this.Parts.Add(head);
            Speed = speed;
        }

        public void SetDirection(MoveDirection targetDirection)
        {
            if(IsOppositeDirection(targetDirection))
            {
                return;
            }

            if(this.CurrentDirection == MoveDirection.Unknown && targetDirection != MoveDirection.Unknown)
            {
                this.IsMoving = true;
            }

            this.CurrentDirection = targetDirection;
        }

        public SnakeMovement GetNextHeadMovement()
        {
            int translateX = 0;
            int translateY = 0;

            var movementPixelAmount = PartSize;

            switch (CurrentDirection)
            {
                case MoveDirection.Up:
                    translateY -= movementPixelAmount;
                    break;
                case MoveDirection.Right:
                    translateX += movementPixelAmount;
                    break;
                case MoveDirection.Down:
                    translateY += movementPixelAmount;
                    break;
                case MoveDirection.Left:
                    translateX -= movementPixelAmount;
                    break;
                case MoveDirection.Unknown:
                    break;
                default: 
                    throw new InvalidMoveDirectionException($"Unknown direction: {CurrentDirection.ToString()}");
            }

            var translation = new Vector2(translateX, translateY) * Speed;
            return new SnakeMovement(Parts[0], translation);
        }

        public void Extend()
        {
            var lastPart = Parts[Parts.Count - 1];
            var lastPartMovement = GetNextMovements()[Parts.Count - 1];
            var newPosition = lastPart.Position - lastPartMovement.Movement;
            Parts.Add(new SnakePart(newPosition, PartSize, PartSize));
        }

        public SnakeMovement[] GetNextMovements()
        {
            var snakeMovements = new SnakeMovement[Parts.Count];
            snakeMovements[0] = GetNextHeadMovement();

            var previousPosition = new Vector2(Parts[0].Position.X, Parts[0].Position.Y);

            for (var i = 1; i < Parts.Count; i++)
            {
                var currentPosition = new Vector2(Parts[i].Position.X, Parts[i].Position.Y);
                var translation = (previousPosition - Parts[i].Position) * Speed;
                snakeMovements[i] = new SnakeMovement(Parts[i], translation);
                previousPosition = currentPosition;
            }

            return snakeMovements;
        }

        public void ApplyMovements(IEnumerable<SnakeMovement> snakeMovements)
        {
            if(!this.IsMoving)
            {
                return;
            }

            foreach(var snakeMovement in snakeMovements)
            {
                snakeMovement.SnakePart.Translate(snakeMovement.Movement);
            }
        }

        private bool IsOppositeDirection(MoveDirection targetDirection)
        {
            return CurrentDirection == MoveDirection.Left && targetDirection == MoveDirection.Right
                || CurrentDirection == MoveDirection.Right && targetDirection == MoveDirection.Left
                || CurrentDirection == MoveDirection.Up && targetDirection == MoveDirection.Down
                || CurrentDirection == MoveDirection.Down && targetDirection == MoveDirection.Up;
        }
    }
}