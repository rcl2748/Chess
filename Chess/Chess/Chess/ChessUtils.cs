using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Chess
{
    [TypeConverter(typeof(ChessSquareTypeConverter))]
    public struct ChessSquare
    {
        public static ChessSquare Invalid = new ChessSquare("");
        public sbyte File { get; set; }
        public sbyte Rank { get; set; }
        public ChessSquare(sbyte file, sbyte rank)
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
            else
            {
                File = -1;
                Rank = -1;
            }
        }

        public string GetSquare()
        {
            return File.ToString() + Rank;
        }
    }

    public class ChessSquareTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text = value as string;

            return text != null ? new ChessSquare(text) : base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }

            return base.CanConvertFrom(context, sourceType);
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
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public enum Side
    {
        White,
        Black
    }

    public class BoardUtils
    {
        public const int SquareSize = 53;
        private static Dictionary<PieceType, string> WhiteTextureSources = new Dictionary<PieceType, string>();
        private static Dictionary<PieceType, string> BlackTextureSources = new Dictionary<PieceType, string>();
        public static Dictionary<PieceType, char> PieceNotationLetters { get; } = new Dictionary<PieceType, char>();

        static BoardUtils()
        {
            // Declare pieces' letters
            /*PieceNotationLetters.Add(PieceType.KING, 'K');
            PieceNotationLetters.Add(PieceType.QUEEN, 'Q');
            PieceNotationLetters.Add(PieceType.ROOK, 'R');
            PieceNotationLetters.Add(PieceType.BISHOP, 'B');
            PieceNotationLetters.Add(PieceType.KNIGHT, 'N');*/

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
            sbyte file = (sbyte)(x / SquareSize);
            sbyte rank = (sbyte)(y / SquareSize);
            if (file < 8 && rank < 8)
            {
                return new ChessSquare(file, rank);
            }
            return ChessSquare.Invalid;
        }

        public static sbyte GetFile(char file)
        {
            return (sbyte)(file - 96);
        }

        public static char GetFile(byte file)
        {
            return (char)(file + 96);
        }
        public static sbyte GetRank(char file)
        {
            return (sbyte)(file - 48);
        }

        public static char GetRank(byte file)
        {
            return (char)(file + 48);
        }
    }
}