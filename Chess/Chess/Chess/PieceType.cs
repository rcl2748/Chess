using System.Collections.Generic;

namespace Chess
{
    public enum PieceType
    {
        King,
        Queen,
        Rook,
        Bishop,
        Knight,
        Pawn
    }

    public static class PieceTypeExtensions
    {
        private static readonly Dictionary<PieceType, char> PieceNotationLetters = new Dictionary<PieceType, char>();

        static PieceTypeExtensions()
        {
            PieceNotationLetters.Add(PieceType.King, 'K');
            PieceNotationLetters.Add(PieceType.Queen, 'Q');
            PieceNotationLetters.Add(PieceType.Rook, 'R');
            PieceNotationLetters.Add(PieceType.Bishop, 'B');
            PieceNotationLetters.Add(PieceType.Knight, 'N');
        }

        public static char GetNotationChar(this PieceType type)
        {
            return PieceNotationLetters[type];
        }
    }
}