using System;
using System.ComponentModel;
using System.Globalization;

namespace Chess
{
    public class ChessSquareTypeConverter : TypeConverter
    {
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            string text = value as string;

            return text != null ? new ChessSquare(text) : base.ConvertFrom(context, culture, value);
        }
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }
    }

    [TypeConverter(typeof(ChessSquareTypeConverter))]
    public struct ChessSquare
    {
        public bool Equals(ChessSquare other)
        {
            return File == other.File && Rank == other.Rank;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is ChessSquare && Equals((ChessSquare)obj);
        }

        public static ChessSquare Invalid = new ChessSquare("");
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
            else
            {
                File = 8;
                Rank = 8;
            }
        }

        public string GetSquare()
        {
            return File.ToString() + Rank;
        }

        public static bool operator ==(ChessSquare left, ChessSquare right)
        {
            return left.File == right.File && left.Rank == right.Rank;
        }

        public static bool operator !=(ChessSquare left, ChessSquare right)
        {
            return !(left == right);
        }
    }
}