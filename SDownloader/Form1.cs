using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Windows.Forms;

namespace SDownloader {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            //ApplyTheme();
        }

        private HttpClient httpClient = new HttpClient();

        private void Form1_Load(object sender, EventArgs e) {
            var text = Clipboard.GetText();
            targetBox.Text = Directory.Exists(text) ? text : "";
            //var episodes = ExtractEpisodes("tt2575988", 1);
            //Debug.WriteLine(episodes.Count); 
            //DownloadSubtitle("3222784");
            //https://v3.sg.media-imdb.com/suggestion/x/friendsaaa.json?includeVideos=1
            //https://www.opensubtitles.org/en/subtitleserve/sub/5617075
            //https://www.imdb.com/title/tt2575988/episodes?season=1
            //https://www.opensubtitles.org/en/search/sublanguageid-eng/imdbid-tt3222784/sort-6/asc-0
            //   find /en/subtitleserve/sub 
            //https://www.opensubtitles.org/en/search/sublanguageid-eng/searchonlytvseries-on/season-01/episode-1/moviename-silicon+valley
        }

        private List<Episode> ExtractEpisodes(string imdbID, int season) {
            if (!imdbID.StartsWith("tt")) imdbID = "tt" + imdbID;
            string url = string.Format("https://www.imdb.com/title/{0}/episodes?season={1}", imdbID, season);
            var content = Get(url);
            var episodes = new List<Episode>();
            var start = 0;
            while (start != -1) {
                start = content.IndexOf("list_item", start + 10);
                try {
                    var a = content.IndexOf("<a href=\"", start);
                    var b = content.IndexOf("\" itemprop", a);
                    var line = content.Substring(a, b - a).Split('"');
                    var id = line[1].Split('/')[2].Replace("tt", "");
                    var title = line[3];
                    episodes.Add(new Episode() {
                        id = id, title = title,
                        index = episodes.Count + 1
                    });
                } catch (Exception) { }
            }
            return episodes;
        }

        private void DownloadSubtitle(string imdbID, string saveTo) {
            var url = string.Format("https://www.opensubtitles.org/en/search/sublanguageid-eng/imdbid-tt{0}/sort-6/asc-0", imdbID);
            var content = Get(url);
            var a = content.IndexOf("<a href=\"/en/subtitleserve/sub/");
            var b = content.IndexOf("\" onclick=", a);
            var subtitleID = content.Substring(a, b - a).Split('/').AsQueryable().Last();
            var fileURL = string.Format("https://www.opensubtitles.org/en/subtitleserve/sub/{0}", subtitleID);
            Debug.WriteLine(subtitleID);
            //var saveTo = @"D:\downloads\new.srt";
            var response = httpClient.GetAsync(fileURL).Result;
            var stream = response.Content.ReadAsStreamAsync().Result;
            if (File.Exists(saveTo)) File.Delete(saveTo);
            Directory.CreateDirectory(Path.GetDirectoryName(saveTo));
            using (var zip = new ZipArchive(stream, ZipArchiveMode.Read)) {
                foreach (var entry in zip.Entries) {
                    if (entry.Name.EndsWith(".srt")) {
                        using (var newStreams = entry.Open()) {
                            using (var fs = new FileStream(saveTo, FileMode.CreateNew)) {
                                newStreams.CopyToAsync(fs).Wait();
                            }
                        }
                    }
                }
            }
        }

        private string Get(string url) {
            return httpClient.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        }

        private void SearchEpisodes(object sender, EventArgs e) {
            resultBox.Enabled = false;
            button1.Enabled = false;
            var id = imdbIDBox.Text;
            var epi = seasonBox.Text;
            var episodes = ExtractEpisodes(id, Int16.Parse(epi));
            resultBox.Items.Clear();
            foreach (var episode in episodes) {
                resultBox.Items.Add(episode);
            }
            resultBox.Enabled = true;
            button1.Enabled = true;
        }

        private void DownloadAll(object sender, EventArgs e) {
            AutoRename();
            var folder = targetBox.Text.Trim();
            var dirName = new DirectoryInfo(folder).Name;

            foreach (Episode episode in resultBox.Items) {
                var saveTo = string.Format("{0}/srt/{1}{2}.srt", folder, dirName, episode.Num);
                Debug.WriteLine(saveTo);
                DownloadSubtitle(episode.id, saveTo);
            }
        }

        private void AutoRename() {
            var folder = targetBox.Text.Trim();
            var dirName = new DirectoryInfo(folder).Name;
            string[] filePaths = Directory.GetFiles(folder, "*.*",
                                         SearchOption.TopDirectoryOnly);
            foreach (var path in filePaths) {
                try {
                    var filename = Path.GetFileName(path);
                    var ext = Path.GetExtension(path);
                    var match = Regex.Match(filename, @"E\d+\.");
                    if (match.Success) {
                        var episode = int.Parse(Regex.Match(match.Value, @"\d+").Value).ToString("D2");
                        var dir = Path.GetDirectoryName(path);
                        var renameTo = string.Format("{0}\\{1}E{2}{3}", dir, dirName, episode, ext);
                        File.Move(path, renameTo);
                    }
                } catch (Exception) { }
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e) {
            if (!Directory.Exists(targetBox.Text.Trim())) {
                button1.Enabled = false;
                button2.Enabled = false;
                return;
            }
            button1.Enabled = true;
            button2.Enabled = true;
            //auto guess imdbID  
            var folderName = new DirectoryInfo(targetBox.Text).Name;
            var query = HttpUtility.UrlEncode(Regex.Replace(folderName, @".S\d+$", ""));
            var url = string.Format("https://v3.sg.media-imdb.com/suggestion/x/{0}.json", query);
            var jsonStr = Get(url);
            //Debug.WriteLine(jsonStr);
            ImdbResult results = JsonConvert.DeserializeObject<ImdbResult>(jsonStr);
            var tvSeries = results.d.Where(d => d.q == "TV series").Select(item => item.ToInfo());
            //Debug.WriteLine(tvSeries.Count());
            if (tvSeries.Count() > 0) {
                var info = tvSeries.First();
                pictureBox1.Load(info.image);
                label1.Text = string.Format("{0} ({1})", info.name, info.release);
                imdbIDBox.Text = info.id;
                int season = 1;
                var match = Regex.Match(folderName, @".S\d+$");
                if (match.Success) {
                    season = short.Parse(match.Value.Replace(".S", ""));
                }
                seasonBox.Text = season + "";
                SearchEpisodes(null, null);
            }
        }

        private string[] Split(string str, string splitter) {
            return str.Split(new string[] { splitter }, StringSplitOptions.None);
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e) {

        }


    }

    class ImdbInfo {
        public string id;
        public string name;
        public string type;
        public string stars;
        public string year;
        public string release;
        public string image;
    }

    class ImdbResult {
        public ImdbResult_item[] d;
        public string q;
        public string v;
    }

    class ImdbResult_item {
        public ImdbResult_image i;
        public string id;
        public string l;
        public string s;
        public string q;
        public string y;
        public string yr;

        public ImdbInfo ToInfo() {
            var info = new ImdbInfo() {
                id = id,
                name = l,
                type = q,
                stars = s,
                year = y,
                release = yr
            };
            if (info.release == null) info.release = info.year;
            info.image = i.imageUrl;
            return info;
        }
    }
    class ImdbResult_image {
        public string imageUrl;
    }

    class Episode {
        public int index;
        public string id;
        public string title;

        public string Num {
            get {
                return "E" + index.ToString("D2");
            }
        }

        public override string ToString() {
            return string.Format("{0} - {1}", Num, title);
        }
    }
}
