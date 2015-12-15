using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Chess
{
    public abstract class ChessPiece : Image
    {
        private static ChessPiece DraggingPiece { get; set; }
        public PieceType Type { get; set; }
        public Side Side { get; set; }
        private ChessSquare _position;
        public ChessSquare Position
        {
            get
            {
                return _position;
            }
            set
            {
                _position = value;
                Debug.WriteLine(value.File + ":" + value.Rank);
                MovePieceToPosition(value);
            }
        }

        public ChessPiece()
        {
            MouseDown += OnMouseDown;
            Source = BoardUtils.GetTexture(Side, Type);
            Width = BoardUtils.SquareSize;
            Height = BoardUtils.SquareSize;
        }
        public bool Move(ChessSquare square)
        {
            if (ValidateMove(square))
            {
                Position = square;
                return true;
            }
            return false;
        }

        public void MovePieceToPosition(double x, double y)
        {
            //            margin.Right = 800 - x - BoardUtils.SquareSize - 10;
            //            margin.Bottom = 500 - y - BoardUtils.SquareSize * 2;
            //            Margin = new Thickness(x, y, 0, 0);
            //            MainWindow.BoardCanvas.Set
            Canvas.SetLeft(this, x - 10);
            Canvas.SetTop(this, y - 10);
            Width = BoardUtils.SquareSize;
            Height = BoardUtils.SquareSize;
        }

        public void MovePieceToPosition(ChessSquare square)
        {
            double x = 10 + BoardUtils.SquareSize * square.File;
            double y = 10 + BoardUtils.SquareSize * square.Rank;
            MovePieceToPosition(x, y);
        }


        private void OnMouseDown(object sender, MouseButtonEventArgs mouseButtonEventArgs)
        {
            MainWindow.DraggingPiece = this;
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
        public King()
        {
            Type = PieceType.King;
        }

        public King(ChessSquare initPosition) : this()
        {
            Position = initPosition;
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
}
