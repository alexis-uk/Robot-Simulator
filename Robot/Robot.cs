using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robot
{
    public enum Direction
    {
        NORTH, SOUTH, EAST, WEST
    }

    public enum TurnDirection
    {
        RIGHT, LEFT
    }

    public class Robot 
    {
        private readonly Tabletop tableTop;

        #region Properties

        /// <summary>
        /// Robot Position
        /// </summary>
        public Point Position { get; private set; }

        /// <summary>
        /// Returns true or false if the robot is placed in tabletop
        /// </summary>
        public bool IsPlaced { get; private set; } = false;

        /// <summary>
        /// Robot Status
        /// </summary>
        public string Report
        {
            get
            {
                return $"{Position.X},{Position.Y},{Direction.ToString()}";
            }
        }

        /// <summary>
        /// Robot facing direction
        /// </summary>
        public Direction Direction
        {
            get; set;
        }
        #endregion

        #region Constructors
        public Robot(Tabletop tableTop)
        {
            this.tableTop = tableTop;
        }
        #endregion

        #region private methods
        /// <summary>
        /// Validates if a position is valid in the tabletop
        /// </summary>
        /// <param name="position">Position to validate</param>
        /// <returns>True if is valid</returns>
        private bool ValidateNewPosition(Point position)
        {
            return (tableTop.Height >= position.Y && tableTop.Width >= position.X && position.X >= 0 && position.Y >= 0);
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Places the robot in tabletop coordinates
        /// </summary>
        /// <param name="startPosition">Coordinates</param>
        /// <param name="direction">Facing Direction</param>
        /// <returns></returns>
        public bool Place(Point startPosition, Direction direction=Direction.NORTH)
        {
            if (ValidateNewPosition(startPosition))
            {
                this.Position = startPosition;
                this.Direction = direction;
                IsPlaced = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Moves the robot one unit in the direction it faces
        /// </summary>
        /// <returns></returns>
        public bool Move()
        {
            if (!IsPlaced)
                return false;
            Point newPosition;

            switch (Direction)
            {
                case Direction.NORTH:
                    newPosition = new Point(Position.X, Position.Y + 1);
                    if (ValidateNewPosition(newPosition))
                    {
                        this.Position = newPosition;
                        return true;
                    }
                    else {
                        return false;
                    }
                case Direction.SOUTH:
                    newPosition = new Point(Position.X, Position.Y - 1);
                    if (ValidateNewPosition(newPosition))
                    {
                        this.Position = newPosition;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.EAST:
                    newPosition = new Point(Position.X + 1, Position.Y);
                    if (ValidateNewPosition(newPosition))
                    {
                        this.Position = newPosition;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case Direction.WEST:
                    newPosition = new Point(Position.X - 1, Position.Y);
                    if (ValidateNewPosition(newPosition))
                    {
                        this.Position = newPosition;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
            }
            return false;
        }

        /// <summary>
        /// Turns the robot in the indicated direction
        /// </summary>
        /// <param name="turnDirection"></param>
        /// <returns></returns>
        public bool Turn(TurnDirection turnDirection)
        {
            switch (turnDirection)
            {
                case TurnDirection.RIGHT:
                    switch (this.Direction)
                    {
                        case Direction.NORTH:
                            this.Direction = Direction.EAST;
                            break;
                        case Direction.SOUTH:
                            this.Direction = Direction.WEST;
                            break;
                        case Direction.EAST:
                            this.Direction = Direction.SOUTH;
                            break;
                        case Direction.WEST:
                            this.Direction = Direction.NORTH;
                            break;
                        default:
                            break;
                    }
                    break;
                case TurnDirection.LEFT:
                    switch (this.Direction)
                    {
                        case Direction.NORTH:
                            this.Direction = Direction.WEST;
                            break;
                        case Direction.SOUTH:
                            this.Direction = Direction.EAST;
                            break;
                        case Direction.EAST:
                            this.Direction = Direction.NORTH;
                            break;
                        case Direction.WEST:
                            this.Direction = Direction.SOUTH;
                            break;
                        default:
                            break;
                    }
                    break;
            }
            return true;
        }
        #endregion
    }
}
