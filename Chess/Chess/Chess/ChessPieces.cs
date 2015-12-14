using System;
using System.Diagnostics;
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
            set { _position = value; }
        }

        public ChessPiece()
        {
            MouseDown += OnMouseDown;
            Source = BoardUtils.GetTexture(Side, Type);
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
