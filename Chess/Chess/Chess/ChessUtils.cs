using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Chess
{
    public delegate void PieceMove(ChessSquare square);
    public class ChessSquare
    {
        public byte File { get; set; }
        public byte Rank { get; set; }
        public ChessSquare(byte file, byte rank)
        {
            File = file;
            Rank = rank;
        }

        public ChessSquare(string pos)
        {
            if (pos.Length == 2)
            {
                char[] chars = pos.ToCharArray();
                File = BoardUtils.GetFile(chars[0]);
                Rank = BoardUtils.GetRank(chars[1]);
            }
        }

        public string GetSquare()
        {
            return File.ToString() + Rank;
        }
    }

    public class ChessMove
    {
        public bool IsCapture { get; set; }
        public bool IsCastleQueenside { get; set; }
        public ChessSquare Square { get; set; }
        public PieceType Type { get; set; }

        public ChessMove()
        {

        }
        public ChessMove(ChessSquare square, PieceType type)
        {
            Square = square;
            Type = type;
        }
    }

    public enum PieceType
    {
        KING,
        QUEEN,
        ROOK,
        BISHOP,
        KNIGHT,
        PAWN
    }

    public enum Side
    {
        WHITE,
        BLACK
    }

    public class BoardUtils
    {

        public static event PieceMove PieceMoveEvent;
        private static Dictionary<PieceType, string> WhiteTextureSources = new Dictionary<PieceType, string>();
        private static Dictionary<PieceType, string> BlackTextureSources = new Dictionary<PieceType, string>();

        static BoardUtils()
        {
            // Declare pieces' letters
            /*PieceNotationLetters.Add(PieceType.KING, 'K');
            PieceNotationLetters.Add(PieceType.QUEEN, 'Q');
            PieceNotationLetters.Add(PieceType.ROOK, 'R');
            PieceNotationLetters.Add(PieceType.BISHOP, 'B');
            PieceNotationLetters.Add(PieceType.KNIGHT, 'N');*/

            // Declare pieces' textures
            WhiteTextureSources.Add(PieceType.KING, "bb.png");
        }

        // Get texture path of a piece
        public static BitmapImage GetTexture(string path)
        {
            return new BitmapImage(new Uri("ms-appx:///images/" + path));
        }

        public static ChessSquare GetChessSquare(Point point)
        {
            double x = point.X - 10;
            double y = point.Y - 10;
            byte file = (byte)(x / MainWindow.SquareSize);
            byte rank = (byte)(y / MainWindow.SquareSize);
            if (file > 0 && file < 9 && rank > 0 && rank < 9)
            {
                return new ChessSquare();
            }
            else
            {
                return null;
            }
        }

        public static byte GetFile(char file)
        {
            return (byte)(file - 96);
        }

        public static char GetFile(byte file)
        {
            return (char)(file + 96);
        }
        public static byte GetRank(char file)
        {
            return (byte)(file - 48);
        }

        public static char GetRank(byte file)
        {
            return (char)(file + 48);
        }
    }
}