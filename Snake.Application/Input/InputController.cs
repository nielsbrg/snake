namespace Snake.Application.Input
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using Domain;
    using Events;

    public class InputController : Observable<DirectionChangedEvent>
    {
        public MoveDirection CurrentDirection { get; private set; }

        public void OnKeyDown(KeyEventArgs e)
        {
            var keyData = e.KeyData;
            var direction = GetMoveDirectionFromKeyData(keyData);
            var oldDirection = CurrentDirection;

            if (direction != MoveDirection.Unknown)
            {
                CurrentDirection = direction;
            }

            if (oldDirection != CurrentDirection)
            {
                System.Console.WriteLine("DirectionChangedEvent => {0}", CurrentDirection);
                NotifyObservers(new DirectionChangedEvent(CurrentDirection));
            }
        }

        private MoveDirection GetMoveDirectionFromKeyData(Keys keyData)
        {
            switch(keyData)
            {
                case Keys.Left:
                case Keys.A:
                    return MoveDirection.Left;
                case Keys.Right:
                case Keys.D:
                    return MoveDirection.Right;
                case Keys.Up:
                case Keys.W:
                    return MoveDirection.Up;
                case Keys.Down:
                case Keys.S:
                    return MoveDirection.Down;
                default: 
                    return MoveDirection.Unknown;
            }
        }
    }
}
