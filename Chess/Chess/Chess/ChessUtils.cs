using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Chess
{
    public class ChessMove
    {
        public bool IsCapture { get; set; }
        public bool IsCastleQueenside { get; set; }
        public bool IsCastleKingside { get; set; }
        public PieceType? PromotionTo { get; set; }
        public ChessSquare From { get; set; }
        public ChessSquare To { get; set; }
        public PieceType Type { get; set; }
        public Side Side { get; set; }
        public bool IsValid { get; }

        public ChessMove(ChessPiece piece, ChessSquare from, ChessSquare to)
        {
            Type = piece.Type;
            Side = piece.Side;
            From = from;
            To = to;
            IsValid = piece.ValidateMove(to);
        }
    }

    public enum Side
    {
        White,
        Black
    }

    public class BoardUtils
    {
        public static int MoveCount = 0;
        public static readonly List<ChessMove> Moves = new List<ChessMove>();
        public const int SquareSize = 53;
        public const int BoardSize = 424;
        public static Side SideToMove = Side.White;
        private static readonly Dictionary<PieceType, string> WhiteTextureSources = new Dictionary<PieceType, string>();
        private static readonly Dictionary<PieceType, string> BlackTextureSources = new Dictionary<PieceType, string>();
        private static readonly List<ChessPiece> WhitePieces = new List<ChessPiece>();
        private static readonly List<ChessPiece> BlackPieces = new List<ChessPiece>();
        static BoardUtils()
        {
            // Declare pieces' textures
            WhiteTextureSources.Add(PieceType.King, "wk.png");
            WhiteTextureSources.Add(PieceType.Queen, "wq.png");
            WhiteTextureSources.Add(PieceType.Rook, "wr.png");
            WhiteTextureSources.Add(PieceType.Bishop, "wb.png");
            WhiteTextureSources.Add(PieceType.Knight, "wn.png");
            WhiteTextureSources.Add(PieceType.Pawn, "wp.png");

            BlackTextureSources.Add(PieceType.King, "bk.png");
            BlackTextureSources.Add(PieceType.Queen, "bq.png");
            BlackTextureSources.Add(PieceType.Rook, "br.png");
            BlackTextureSources.Add(PieceType.Bishop, "bb.png");
            BlackTextureSources.Add(PieceType.Knight, "bn.png");
            BlackTextureSources.Add(PieceType.Pawn, "bp.png");
        }

        public static void Move(ChessMove move)
        {
            Moves.Add(move);
            MoveCount = Moves.Count / 2;
        }

        public static ChessPiece GetPieceAt(ChessSquare square, Side side)
        {
            return (side == Side.White ? WhitePieces : BlackPieces).FirstOrDefault(piece => piece.Position == square);
        }

        public static void AddPiece(ChessPiece piece)
        {
            (piece.Side == Side.White ? WhitePieces : BlackPieces).Add(piece);
        }

        // Get texture path of a piece
        public static BitmapImage GetTexture(Side side, PieceType type)
        {
            string path = side == Side.White ? WhiteTextureSources[type] : BlackTextureSources[type];
            return new BitmapImage(new Uri(@"resources\Images\" + path, UriKind.Relative));
        }

        public static ChessSquare GetChessSquare(Point point)
        {
            double x = point.X - 10;
            double y = point.Y - 10;
            double file = (x / SquareSize);
            double rank = ((BoardSize - y) / SquareSize);
            if (rank > 0 && file > 0 && file < 8 && rank < 8)
            {
                return new ChessSquare((byte)file, (byte)rank);
            }
            return ChessSquare.Invalid;
        }

        public static byte GetFile(char file)
        {
            return (byte)(file - 97);
        }

        public static char GetFile(byte file)
        {
            return (char)(file + 97);
        }
        public static byte GetRank(char file)
        {
            return (byte)(file - 49);
        }

        public static char GetRank(byte file)
        {
            return (char)(file + 49);
        }

        public static void SwitchSide()
        {
            SideToMove = SideToMove == Side.White ? Side.Black : Side.White;
        }
    }
}