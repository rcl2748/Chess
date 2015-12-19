using System.Collections.Generic;
using System.Media;

namespace Chess
{
    public static class SoundTypeExtensions
    {
        private static readonly Dictionary<SoundType, SoundPlayer> Filenames = new Dictionary<SoundType, SoundPlayer>();

        static SoundTypeExtensions()
        {
            Filenames.Add(SoundType.Move, new SoundPlayer("move.mp3"));
            Filenames.Add(SoundType.Check, new SoundPlayer("check.mp3"));
            Filenames.Add(SoundType.GameEnd, new SoundPlayer("game-end.mp3"));
            Filenames.Add(SoundType.GameStart, new SoundPlayer("game-start.mp3"));
            Filenames.Add(SoundType.Castle, new SoundPlayer("castle.mp3"));
            Filenames.Add(SoundType.Capture, new SoundPlayer("capture.mp3"));
        }

        public static SoundPlayer GetSoundPlayer(this SoundType type)
        {
            return Filenames[type];
        }
    }

    public enum SoundType
    {
        Move,
        Check,
        GameEnd,
        GameStart,
        Castle,
        Capture
    }
}