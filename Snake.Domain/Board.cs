namespace Snake.Domain
{
    using Engine;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Board
    {
        private readonly int boardSpaceSize;

        public Boundaries Boundaries { get; set; }

        public Transform Transform { get; set; }

        public BoardSpace[,] BoardSpaces { get; private set; }

        public Board(Boundaries boundaries, int boardSpaceSize)
        {
            this.boardSpaceSize = boardSpaceSize;
            this.Boundaries = boundaries;
            var width = boundaries.Right - boundaries.Left;
            var height = boundaries.Bottom - boundaries.Top;

            var horizontalSpaces = width / boardSpaceSize;
            var verticalSpaces = height / boardSpaceSize;

            this.BoardSpaces = new BoardSpace[verticalSpaces, horizontalSpaces];
            
            for(var i = 0; i < horizontalSpaces; i++)
            {
                for(var j = 0; j < verticalSpaces; j++)
                {
                    var position = new Vector2(i * boardSpaceSize, j * boardSpaceSize);
                    this.BoardSpaces[j, i] = new BoardSpace(position, boardSpaceSize, boardSpaceSize);
                }
            }

            Transform = new Transform(boundaries.Left, boundaries.Top, width, height);
        }

        /// <summary>
        /// Checks whether a transform is out of bounds
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public bool IsEntityOutOfBounds(Transform transform)
        {
            return Boundaries.IsOutOfBounds(transform);
        }

        /// <summary>
        /// Checks whether the X and Y coordinates of the vector are within the board's bounds.
        /// </summary>
        /// <param name="position">The position to check for validity.</param>
        /// <returns></returns>
        public bool IsValidPosition(Vector2 position)
        {
            var boardSpace = GetBoardSpaceFromPosition(position);
            return boardSpace != null;
        }

        /// <summary>
        /// Updates an entity's position to newPosition
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="oldPosition"></param>
        /// <param name="newPosition"></param>
        public void UpdateBoardPosition(Transform transform, Vector2 oldPosition, Vector2 newPosition)
        {
            var newBoardSpace = GetBoardSpaceFromPosition(newPosition);
            var oldBoardSpace = GetBoardSpaceFromPosition(oldPosition);

            if(newBoardSpace == null)
            {
                throw new EntityOutOfBoundsException();
            }

            oldBoardSpace.OccupyingEntities.Remove(transform);
            newBoardSpace.OccupyingEntities.Add(transform);
        }

        /// <summary>
        /// Converts an X / Y coordinate on the screen to a BoardSpace
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public BoardSpace GetBoardSpaceFromPosition(Vector2 position)
        {
            var horizontalIndex = position.X / boardSpaceSize;
            var verticalIndex = position.Y / boardSpaceSize;

            try
            {
                return BoardSpaces[verticalIndex, horizontalIndex];
            }
            catch(IndexOutOfRangeException)
            {
                return null;
            }
        }

        /// <summary>
        /// Gets all board spaces that are not occupied.
        /// </summary>
        /// <returns></returns>
        public List<BoardSpace> GetFreeBoardSpaces()
        {
            var freeSpaces = new List<BoardSpace>();

            foreach (var boardSpace in BoardSpaces)
            {
                if(!boardSpace.OccupyingEntities.Any())
                {
                    freeSpaces.Add(boardSpace);
                }
            }

            return freeSpaces;
        }
    }
}
