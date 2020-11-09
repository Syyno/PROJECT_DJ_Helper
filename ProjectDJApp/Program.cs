using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ProjectDJApp.Extensions;
using SpotifyAPI.Web;
using Swan.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.FileExtensions;

namespace ProjectDJApp
{
    class Program
    {
        static void Main(string[] args)
        {
            
            #region получение пути к папке с треками

            Console.WriteLine("Введи путь до папки с треками. Пример - D:\\Music\\FolderWithTracksForMix");
            string path = Console.ReadLine();
            while (!Directory.Exists(path))
            {
                Console.WriteLine("Директория не существует! Попробуйте еще раз");
                Console.WriteLine("Введи путь до папки с треками. Пример - D:\\Music\\FolderWithTracksForMix");
                path = Console.ReadLine();
            }
            Util.WriteSeparator();

            Console.WriteLine("Папка найдена. Список треков в папке:\n");
            string[] initTracks = Directory.GetFiles(path).Where(f => f.EndsWith(".mp3")).Select(file => Path.GetFileNameWithoutExtension(file)).ToArray();
            initTracks.ShowInitialTrackList();
            Util.WriteSeparator();

            #endregion

            #region подключение к spotify api
            //полчение clientId и clientSecret для доступа к Spotify API
            var connectionInfo = new ConfigurationBuilder().SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName).AddJsonFile("appsettings.json").Build();
            
            var config = SpotifyClientConfig
                .CreateDefault()
                .WithAuthenticator(new ClientCredentialsAuthenticator(connectionInfo["ConnectionInfo:clientId"], connectionInfo["ConnectionInfo:clientSecret"]));

            var spotify = new SpotifyClient(config);

            #endregion

            #region получение информации о тональности через spotify api  

            //треки, которые не удалось найти
            List<string> notFoundTracks = new List<string>();
            //треки, которые удалось найти (сразу с ключами)
            List<Track> trackList = new List<Track>();

            foreach (string track in initTracks)
            {
                var searchTrack = spotify.Search.Item(new SearchRequest(SearchRequest.Types.Track, track.FixTrackName()));
                if (searchTrack.Result.Tracks.Items != null)
                {
                    foreach (var searchResultTrack in searchTrack.Result.Tracks.Items)
                    {
                        var analyzedTrack = spotify.Tracks.GetAudioFeatures(searchResultTrack.Id);
                        trackList.Add(new Track() { Name = track, Key = analyzedTrack.Result.Key.ToString() + (analyzedTrack.Result.Mode == 0 ? "A" : "B") });
                        break;
                    }
                }
            }

            foreach (string track in initTracks)
            {
                if (trackList.FirstOrDefault(t => t.Name == track) == null)
                {
                    notFoundTracks.Add(track);
                }
            }

            Console.WriteLine("Информация о тональности найдена для следующих треков:\n");
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            trackList.ShowTrackList();
            Console.ForegroundColor = color;
            Console.WriteLine(new string('-', 30));

            Console.WriteLine("Информация о тональности не найдена для следующих треков. Измени название и попробуй еще раз");
            Console.ForegroundColor = ConsoleColor.Red;
            foreach (var track in notFoundTracks)
            {
                Console.WriteLine(track);
            }
            Console.ForegroundColor = color;
            Console.WriteLine(new string('-', 30));

            #endregion

            #region выбор режима работы

            Console.WriteLine("Выбери режим работы.\nВведи 1, если нужно создать полный микс с указанием стартового трека. \nВведи 2, если нужно получить совет по сведению двух треков\n");
            int mode;
            bool b = Int32.TryParse(Console.ReadLine(), out mode);
            while (b == false || mode < 1 || mode > 2)
            {
                Console.WriteLine("Ошибка во вводе.\n");
                Console.WriteLine("Выбери режим работы.\nВведи 1, если нужно создать полный микс с указанием стартового трека.\nВведи 2, если нужно получить совет по сведению двух треков\n");
                b = Int32.TryParse(Console.ReadLine(), out mode);
            }

            if (mode == 1)
            {
                Console.WriteLine("Выбери начальный трек\n");
                trackList.ShowTrackList();
                int x;
                b = Int32.TryParse(Console.ReadLine(), out x);
                while (b == false || x < 1 || x > trackList.Count)
                {
                    Console.WriteLine("Ошибка во вводе. Выбери начальный трек.\n");
                    trackList.ShowTrackList();
                    b = Int32.TryParse(Console.ReadLine(), out x);
                }

                Console.WriteLine($"Начальный трек - {trackList[x - 1].Name}");
                Util.WriteSeparator();

                Console.WriteLine("Вариант микса:\n");
                List<Track> finalList = TrackExtensions.MixWithStartingTrack(trackList,
                    trackList[x - 1]);
                foreach (var myTrack in finalList)
                {
                    Console.WriteLine($"{myTrack.Name} - {myTrack.Key}");
                }
                Util.WriteSeparator();

                int savingType;
                Console.WriteLine("\nРезультаты можно сохранить.\n" +
                                  "Введи 1, если нужно сохранить порядок в txt файл (будет лежать в папке с треками). <-- рекомендуемый вариант\n" +
                                  "Введи 2, если нужно пронумеровать(в порядке, предложенном выше) файлы в папке.\n" +
                                  "Либо введи произвольный символ, текст (или просто нажми на enter) для того, что бы выйти");
                b = b = Int32.TryParse(Console.ReadLine(), out savingType);
                if (b && savingType == 1 || savingType == 2)
                {
                    Util.SaveResults(savingType, finalList, path);
                }

            }
            else
            {
                Console.WriteLine("Выбери трек, с которым будешь сводить\n");
                trackList.ShowTrackList();
                int x;
                b = Int32.TryParse(Console.ReadLine(), out x);
                while (b == false || x < 1 || x > trackList.Count)
                {
                    Console.WriteLine("Ошибка во вводе. Выбери трек, с которым будешь сводить\n");
                    trackList.ShowTrackList();
                    b = Int32.TryParse(Console.ReadLine(), out x);
                }
                Console.WriteLine("Варианты для сведения с выбранным треком:\n");
                List<Track> finalList = TrackExtensions.MixOneTrack(trackList,
                    trackList[x - 1]);
                foreach (var myTrack in finalList)
                {
                    Console.WriteLine($"{myTrack.Name} - {myTrack.Key}");
                }
                Console.WriteLine("\nНажмите любую кнопку для выхода");
                Console.ReadKey();

            }
            #endregion
        }
    }
}