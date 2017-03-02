using System;
using System.Collections.Generic;
using System.Threading;
using PlayerLib.Interfaces;

namespace PlayerLib
{
    public enum ActionType
    {
        Play = 1,
        Pause,
        Stop,
        RecordSong,
        PauseRecording,
        StopRecording
    }

    public class Player : IPlayable, IRecordable
    {
        private Record Song;

        private Dictionary<ActionType, Action> actions;

        public Player()
        {
            actions = new Dictionary<ActionType, Action>
            {
                {ActionType.Play, Play},
                {ActionType.Pause, (this as IPlayable).Pause},
                {ActionType.Stop, (this as IPlayable).Stop},
                {ActionType.RecordSong, Record},
                {ActionType.PauseRecording, (this as IRecordable).Pause},
                {ActionType.StopRecording, (this as IRecordable).Stop}
            };
        }

        public void Execute()
        {
            Console.WriteLine("1) Play song;");
            Console.WriteLine("2) Pause song;");
            Console.WriteLine("3) Stop song;");
            Console.WriteLine("4) Record song;");
            Console.WriteLine("5) Pause record;");
            Console.WriteLine("6) Stop record;");
            Console.WriteLine("7) Quit");

            ActionType type = GetActionType();

            while (actions.ContainsKey(type))
            {
                actions[type].Invoke();
                type = GetActionType();
            }
        }

        public void Play()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Playing {Song.Name}");
        }

        public void Record()
        {
            Console.Write("Enter the song name: ");
            string name = Console.ReadLine();
            Console.Write("Enter lenght: ");
            string lenght = string.Format("{##.##}", Convert.ToDouble(Console.ReadLine()));
            Song = new Record(name, Convert.ToDouble(lenght));

            Console.WriteLine($"{Song.Name} is recording...");
        }

        void IRecordable.Pause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Recording of {Song.Name} is paused...");
        }

        void IRecordable.Stop()
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(Song != null
                ? $"{Song.Name} is recorded! It's Lenght is {Song.Lenght}"
                : "You didn't start the recording of song!");
        }

        void IPlayable.Pause()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{Song.Name} playing is paused...");
        }

        void IPlayable.Stop()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Stopping...");
            Thread.Sleep(200);
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"Song {Song.Name} has been stopped!");
        }

        ActionType GetActionType() => (ActionType) Convert.ToInt32(Console.ReadKey().KeyChar.ToString());
    }
}