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
        public PieceType Type { get; set; }
        private Side _side;

        public Side Side
        {
            get { return _side; }
            set
            {
                _side = value;
                Source = BoardUtils.GetTexture(Side, Type);
            }
        }

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

        public ChessPiece(PieceType type)
        {
            MouseDown += OnMouseDown;
            Type = type;
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
        public King() : base(PieceType.King)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Queen : ChessPiece
    {
        public Queen() : base(PieceType.Queen)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Rook : ChessPiece
    {
        public Rook() : base(PieceType.Rook)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Bishop : ChessPiece
    {
        public Bishop() : base(PieceType.Bishop)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Knight : ChessPiece
    {
        public Knight() : base(PieceType.Knight)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
    public class Pawn : ChessPiece
    {
        public Pawn() : base(PieceType.Pawn)
        {
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
}
