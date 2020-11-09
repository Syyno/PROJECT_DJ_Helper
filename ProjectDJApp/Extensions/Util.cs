using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;

namespace ProjectDJApp.Extensions
{
    public static class Util
    {
        public static void SaveResults(int savingType, List<Track> playlist, string path)
        {
            if (savingType == 1)
                SaveInTxt(playlist, path);
            else
                RenameTracks(playlist, path);
        }

        private static void SaveInTxt(List<Track> playlist, string path)
        {
            using (System.IO.StreamWriter file =
                new System.IO.StreamWriter(path + "\\mixsuggestion.txt", false))
            {
                int i = 1;
                foreach (Track track in playlist)
                {
                    file.WriteLine($"{i}. {track.Name}");
                    i++;
                }
                file.Flush();
            }
        }

        private static void RenameTracks(List<Track> playlist, string path)
        {
            int i = 1;
            foreach (Track track in playlist)
            {
                string oldFullPath = path + '/' + track.Name + ".mp3";
                string newFullPath = path + '/' + i + ". " + track.Name + ".mp3";
                System.IO.File.Move(oldFullPath, newFullPath);
                i++;
            }
        }

        public static void WriteSeparator()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(new string('-', 40));
            Console.ForegroundColor = color;
        }
    }
}
