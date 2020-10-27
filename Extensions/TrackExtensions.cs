using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EmbedIO;

namespace ProjectDJApp.Extensions
{
    public static class TrackExtensions
    {
        static List<Track> _unmxiedTracks = new List<Track>();
        static Track _currentTrack = new Track();
        public static List<Track> MixWithStartingTrack(List<Track> inputTracks, Track startingTrack)
        {
            _unmxiedTracks = inputTracks;
            _currentTrack = startingTrack;
            List<Track> result = new List<Track>() { startingTrack };
            _unmxiedTracks.Remove(startingTrack);

            while (_unmxiedTracks.Count != 0)
            {
                Track nextTrack = FindNextTrack(_currentTrack);
                result.Add(nextTrack);
                _currentTrack = nextTrack;
                _unmxiedTracks.Remove(_currentTrack);
            }

            return result;
        }

        public static List<Track> MixOneTrack(List<Track> inputTracks, Track track)
        {
            _unmxiedTracks = inputTracks;
            _unmxiedTracks.Remove(track);
            return FindNextTracks(track);
        }

        private static Track FindNextTrack(Track track)
        {
            Track nextTrack = null;
            switch (track.Key)
            {
                case "1A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                             t => t.Key == "1A" || t.Key == "1B" || t.Key == "2A" || t.Key == "12A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "2A" });
                        }
                        break;
                    }
                case "1B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                                                 t => t.Key == "1B" || t.Key == "1A" || t.Key == "12B" || t.Key == "2B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "2B" });
                        }
                        break;
                    }
                case "2A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "2A" || t.Key == "2B" || t.Key == "1A" || t.Key == "3A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "3A" });
                        }
                        break;
                    }
                case "2B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "2B" || t.Key == "2A" || t.Key == "1B" || t.Key == "3B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "3B" });
                        }
                        break;
                    }
                case "3A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "3A" || t.Key == "3B" || t.Key == "2A" || t.Key == "4A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "4A" });
                        }
                        break;
                    }
                case "3B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "3B" || t.Key == "3A" || t.Key == "2B" || t.Key == "4B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "4B" });
                        }
                        break;
                    }
                case "4A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "4A" || t.Key == "4B" || t.Key == "3A" || t.Key == "5A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "5A" });
                        }
                        break;
                    }
                case "4B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "4B" || t.Key == "4A" || t.Key == "3B" || t.Key == "5B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "5B" });
                        }
                        break;
                    }
                case "5A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "5A" || t.Key == "5B" || t.Key == "4A" || t.Key == "6A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "6A" });
                        }
                        break;
                    }
                case "5B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "5B" || t.Key == "5A" || t.Key == "4B" || t.Key == "6B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "6B" });
                        }
                        break;
                    }
                case "6A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "6A" || t.Key == "6B" || t.Key == "5A" || t.Key == "7A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "7A" });
                        }
                        break;
                    }
                case "6B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "6B" || t.Key == "6A" || t.Key == "5B" || t.Key == "7B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "7B" });
                        }
                        break;
                    }
                case "7A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "7A" || t.Key == "7B" || t.Key == "6A" || t.Key == "8A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "8A" });
                        }
                        break;
                    }
                case "7B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "7B" || t.Key == "7A" || t.Key == "6B" || t.Key == "8B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "8B" });
                        }
                        break;
                    }
                case "8A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "8A" || t.Key == "8B" || t.Key == "7A" || t.Key == "9A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "9A" });
                        }
                        break;
                    }
                case "8B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "8B" || t.Key == "8A" || t.Key == "7B" || t.Key == "9B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "9B" });
                        }
                        break;
                    }
                case "9A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "9A" || t.Key == "9B" || t.Key == "8A" || t.Key == "10A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "10A" });
                        }
                        break;
                    }
                case "9B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "9B" || t.Key == "9A" || t.Key == "8B" || t.Key == "10B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "10B" });
                        }
                        break;
                    }
                case "10A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "10A" || t.Key == "10B" || t.Key == "9A" || t.Key == "11A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "11A" });
                        }
                        break;
                    }
                case "10B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "10B" || t.Key == "10A" || t.Key == "9B" || t.Key == "11B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "11B" });
                        }
                        break;
                    }
                case "11A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "11A" || t.Key == "11B" || t.Key == "10A" || t.Key == "12A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "12A" });
                        }
                        break;
                    }
                case "11B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "11B" || t.Key == "11A" || t.Key == "10B" || t.Key == "12B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "12B" });
                        }
                        break;
                    }
                case "12A":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "12A" || t.Key == "12B" || t.Key == "11A" || t.Key == "1A");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "1A" });
                        }
                        break;
                    }
                case "12B":
                    {
                        Track nextIfFound = _unmxiedTracks.FirstOrDefault(
                            t => t.Key == "12B" || t.Key == "12A" || t.Key == "11B" || t.Key == "1B");
                        if (nextIfFound != null)
                        {
                            nextTrack = nextIfFound;
                        }
                        else
                        {
                            nextTrack = FindNextTrack(new Track() { Key = "1B" });
                        }
                        break;
                    }
                default:
                    break;
            }

            return nextTrack;
        }

        private static List<Track> FindNextTracks(Track track)
        {
            List<Track> result = new List<Track>();
            switch (track.Key)
            {
                case "1A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                             t => t.Key == "1A" || t.Key == "1B" || t.Key == "2A" || t.Key == "12A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "2A" });
                        }
                        break;
                    }
                case "1B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                                                 t => t.Key == "1B" || t.Key == "1A" || t.Key == "12B" || t.Key == "2B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "2B" });
                        }
                        break;
                    }
                case "2A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "2A" || t.Key == "2B" || t.Key == "1A" || t.Key == "3A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "3A" });
                        }
                        break;
                    }
                case "2B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "2B" || t.Key == "2A" || t.Key == "1B" || t.Key == "3B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "3B" });
                        }
                        break;
                    }
                case "3A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "3A" || t.Key == "3B" || t.Key == "2A" || t.Key == "4A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "4A" });
                        }
                        break;
                    }
                case "3B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "3B" || t.Key == "3A" || t.Key == "2B" || t.Key == "4B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "4B" });
                        }
                        break;
                    }
                case "4A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "4A" || t.Key == "4B" || t.Key == "3A" || t.Key == "5A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "5A" });
                        }
                        break;
                    }
                case "4B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "4B" || t.Key == "4A" || t.Key == "3B" || t.Key == "5B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "5B" });
                        }
                        break;
                    }
                case "5A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "5A" || t.Key == "5B" || t.Key == "4A" || t.Key == "6A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "6A" });
                        }
                        break;
                    }
                case "5B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "5B" || t.Key == "5A" || t.Key == "4B" || t.Key == "6B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "6B" });
                        }
                        break;
                    }
                case "6A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "6A" || t.Key == "6B" || t.Key == "5A" || t.Key == "7A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "7A" });
                        }
                        break;
                    }
                case "6B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "6B" || t.Key == "6A" || t.Key == "5B" || t.Key == "7B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "7B" });
                        }
                        break;
                    }
                case "7A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "7A" || t.Key == "7B" || t.Key == "6A" || t.Key == "8A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "8A" });
                        }
                        break;
                    }
                case "7B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "7B" || t.Key == "7A" || t.Key == "6B" || t.Key == "8B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "8B" });
                        }
                        break;
                    }
                case "8A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "8A" || t.Key == "8B" || t.Key == "7A" || t.Key == "9A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "9A" });
                        }
                        break;
                    }
                case "8B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "8B" || t.Key == "8A" || t.Key == "7B" || t.Key == "9B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "9B" });
                        }
                        break;
                    }
                case "9A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "9A" || t.Key == "9B" || t.Key == "8A" || t.Key == "10A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "10A" });
                        }
                        break;
                    }
                case "9B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "9B" || t.Key == "9A" || t.Key == "8B" || t.Key == "10B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "10B" });
                        }
                        break;
                    }
                case "10A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "10A" || t.Key == "10B" || t.Key == "9A" || t.Key == "11A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "11A" });
                        }
                        break;
                    }
                case "10B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "10B" || t.Key == "10A" || t.Key == "9B" || t.Key == "11B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "11B" });
                        }
                        break;
                    }
                case "11A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "11A" || t.Key == "11B" || t.Key == "10A" || t.Key == "12A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "12A" });
                        }
                        break;
                    }
                case "11B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "11B" || t.Key == "11A" || t.Key == "10B" || t.Key == "12B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "12B" });
                        }
                        break;
                    }
                case "12A":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "12A" || t.Key == "12B" || t.Key == "11A" || t.Key == "1A").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "1A" });
                        }
                        break;
                    }
                case "12B":
                    {
                        List<Track> nextTracksIfFound = _unmxiedTracks.Where(
                            t => t.Key == "12B" || t.Key == "12A" || t.Key == "11B" || t.Key == "1B").ToList();
                        if (nextTracksIfFound.Count != 0)
                        {
                            result = nextTracksIfFound;
                        }
                        else
                        {
                            result = FindNextTracks(new Track() { Key = "1B" });
                        }
                        break;
                    }
                default:
                    break;
            }

            return result;
        }

        public static void ShowTrackList(this List<Track> list)
        {
            int i = 1;
            foreach (Track track in list)
            {
                Console.WriteLine($"{i}. {track.Name}. Key = {track.Key}");
                i++;
            }
        }
        public static void ShowInitialTrackList(this string[] arr)
        {
            int i = 1;
            foreach (string track in arr)
            {
                Console.WriteLine($"{i}. {track}");
                i++;
            }
        }
    }
}