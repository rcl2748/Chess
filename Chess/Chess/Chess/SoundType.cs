using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Windows;

namespace Chess
{
    public static class SoundTypeExtensions
    {
        private const string SoundDir = @"resources\Sounds\";
        private static readonly Dictionary<SoundType, SoundPlayer> Filenames = new Dictionary<SoundType, SoundPlayer>();

        static SoundTypeExtensions()
        {
            Filenames.Add(SoundType.Move, new SoundPlayer(Properties.Resources.move));
            Filenames.Add(SoundType.Check, new SoundPlayer(Properties.Resources.check));
            Filenames.Add(SoundType.GameEnd, new SoundPlayer(Properties.Resources.game_end));
            Filenames.Add(SoundType.GameStart, new SoundPlayer(Properties.Resources.game_start));
            Filenames.Add(SoundType.Castle, new SoundPlayer(Properties.Resources.castle));
            Filenames.Add(SoundType.Capture, new SoundPlayer(Properties.Resources.capture));
        }

        public static void Play(this SoundType type)
        {
            SoundPlayer player = Filenames[type];
            player.Stream.Position = 0;
            player.Play();
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