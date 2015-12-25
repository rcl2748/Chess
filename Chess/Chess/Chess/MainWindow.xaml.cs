using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ChessPiece DraggingPiece { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MouseUp += OnMouseUp;
            BCanvas.MouseMove += OnMouseMove;
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {

            if (DraggingPiece != null)
            {
                Point mousePos = args.GetPosition(null);
                DraggingPiece.MovePieceToPosition(mousePos.X - 37, mousePos.Y - 37);
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            if (DraggingPiece != null)
            {
                Point point = args.GetPosition(null);
                ChessSquare square = BoardUtils.GetChessSquare(point);
                DraggingPiece.Move(square);
                Panel.SetZIndex(DraggingPiece, 0);
                DraggingPiece = null;
            }
        }
    }
}
