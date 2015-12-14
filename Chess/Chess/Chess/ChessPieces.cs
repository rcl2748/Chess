using System;
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
        public ChessSquare Position { get; set; }

        public ChessPiece()
        {
            MouseDown += OnMouseDown;
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
        public const char Letter = 'K';
        public static BitmapImage WhiteTexture = BoardUtils.GetTexture("wk.png");
        public static BitmapImage BlackTexture = BoardUtils.GetTexture("bk.png");

        public King()
        {
            Type = PieceType.KING;
        }

        public King(ChessSquare initPosition) : this()
        {
            Position = initPosition;
            Source = Side == Side.WHITE ? WhiteTexture : BlackTexture;
        }

        protected override bool OnMoveValidation(ChessSquare square)
        {
            return true; //NYI
        }
    }
}
