using System;
using System.Media;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess
{
    public abstract class ChessPiece : Image
    {
        private static ChessPiece DraggingPiece { get; set; }
        private Image image
        public PieceType Type { get; }

        public Side Side { get; }

        private ChessSquare _position;
        public ChessSquare Position
        {
            get { return _position; }
            set
            {
                _position = value;
                MovePieceToPosition(value);
            }
        }

        public ChessPiece(PieceType type, Side side, ChessSquare initPosition)
        {
            MouseDown += OnMouseDown;
            Type = type;
            Side = side;
            BoardUtils.AddPiece(this);
            Source = BoardUtils.GetTexture(Side, Type);
            Width = BoardUtils.SquareSize;
            Height = BoardUtils.SquareSize;
        }
        public bool Move(ChessSquare square)
        {
            if (BoardUtils.SideToMove == Side && square != ChessSquare.Invalid && square != Position)
            {
                ChessMove move = new ChessMove(this, Position, square);
                if (move.IsValid)
                {
                    Position = square;
                    SoundType.Move.Play();
                    BoardUtils.SwitchSide();
                    return true;
                }
            }
            MovePieceToPosition(Position);
            return false;
        }

        public void MovePieceToPosition(double x, double y)
        {
            Canvas.SetLeft(this, x);
            Canvas.SetTop(this, y);
        }

        public void MovePieceToPosition(ChessSquare square)
        {
            double x = BoardUtils.SquareSize * square.File;
            double y = BoardUtils.BoardSize - BoardUtils.SquareSize * (square.Rank + 1);
            MovePieceToPosition(x, y);
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            MainWindow.DraggingPiece = this;
            Panel.SetZIndex(this, 1);
        }

        public bool ValidateMove(ChessSquare square)
        {
            return OnMoveValidation(square); //NYI
        }

        // Abstract method that checks if a move is legal
        // Returns true if legal, false otherwise
        protected abstract bool OnMoveValidation(ChessSquare square);
    }

    public class King : ChessPiece
    {
        public King(Side side, ChessSquare initPosition) : base(PieceType.King, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Queen : ChessPiece
    {
        public Queen(Side side, ChessSquare initPosition) : base(PieceType.Queen, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Rook : ChessPiece
    {
        public Rook(Side side, ChessSquare initPosition) : base(PieceType.Rook, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Bishop : ChessPiece
    {
        public Bishop(Side side, ChessSquare initPosition) : base(PieceType.Bishop, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Knight : ChessPiece
    {
        public Knight(Side side, ChessSquare initPosition) : base(PieceType.Knight, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Pawn : ChessPiece
    {
        public Pawn(Side side, ChessSquare initPosition) : base(PieceType.Pawn, side, initPosition)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
}
