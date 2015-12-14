using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace Chess
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public const int SquareSize = 53;
        public static ChessPiece DraggingPiece { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            MouseUp += OnMouseUp;
            MouseMove += OnMouseMove;
        }

        private void OnMouseMove(object sender, MouseEventArgs args)
        {

            if (DraggingPiece != null)
            {
                Point mousePos = args.GetPosition(null);
                Thickness margin = DraggingPiece.Margin;
                margin.Left = mousePos.X - 27;
                margin.Top = mousePos.Y - 27;
                DraggingPiece.Margin = margin;
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs args)
        {
            Point point = args.GetPosition(null);
            double x = point.X - 10;
            double y = point.Y - 10;
           // DraggingPiece.ValidateMove()
            DraggingPiece = null;
        }
    }
}
