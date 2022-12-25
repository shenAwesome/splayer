using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;

namespace SPlayer {

    internal class SPlayer {

        public List<Line> Subtitles;
        public long Duration = 0;

        readonly LibVLC LibVLC = new LibVLC();
        public readonly MediaPlayer player;


        private long lastPlayTime = 0;
        private long lastPlayTimeGlobal = 0;

        public SPlayer() {
            player = new MediaPlayer(LibVLC);
            player.Playing += Player_Playing;
        }

        public void Reload() {
            this.Open(lastMedia);
        }

        public void Install(VideoView view) {
            view.MediaPlayer = player;
        }

        private void Player_Playing(object sender, EventArgs e) {
            var media = player.Media;
            foreach (var track in media.Tracks) {
                switch (track.TrackType) {
                    case TrackType.Audio:
                        Debug.WriteLine("Audio track");
                        Debug.WriteLine($"{nameof(track.Data.Audio.Channels)}: {track.Data.Audio.Channels}");
                        Debug.WriteLine($"{nameof(track.Data.Audio.Rate)}: {track.Data.Audio.Rate}");
                        break;
                    case TrackType.Video:
                        Debug.WriteLine("Video track");
                        Debug.WriteLine($"{nameof(track.Data.Video.FrameRateNum)}: {track.Data.Video.FrameRateNum}");
                        Debug.WriteLine($"{nameof(track.Data.Video.FrameRateDen)}: {track.Data.Video.FrameRateDen}");
                        Debug.WriteLine($"{nameof(track.Data.Video.Height)}: {track.Data.Video.Height}");
                        Debug.WriteLine($"{nameof(track.Data.Video.Width)}: {track.Data.Video.Width}");
                        break;
                    case TrackType.Text:
                        //Debug.WriteLine("Subtitle");
                        //Debug.WriteLine(track.Data.Subtitle.Encoding);
                        break;
                }
            }
            player.SetSpu(-1);
            player.Volume = 100;
            Duration = media.Duration / 1000;
        }

        public long Progress {
            get {
                return Convert.ToInt64(GetCurrentTime());
            }

            set {
                Debug.WriteLine(value);
                player.Time = value * 1000;
            }
        }

        private float GetCurrentTime() {
            long currentTime = player.Time;
            long systemTime = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

            if (lastPlayTime == currentTime && lastPlayTime != 0) {
                currentTime += (systemTime - lastPlayTimeGlobal);
            } else {
                lastPlayTime = currentTime;
                lastPlayTimeGlobal = systemTime;
            }
            return currentTime * 0.001f;    //to float
        }

        public string Name {
            get {
                if (lastMedia == null) return null;
                return Path.GetFileNameWithoutExtension(lastMedia);
            }
        }

        public bool IsLoaded {
            get {
                return lastMedia != null;
            }
        }

        private string lastMedia;

        public void Open(string path) {
            var media = new Media(LibVLC, new Uri(path));
            player.Play(media);
            media.Dispose();
            var srtFile = Path.GetDirectoryName(path) + "\\"
                + Path.GetFileNameWithoutExtension(path) + ".srt";
            Subtitles = Line.ParseSrt(srtFile);
            this.lastMedia = path;
        }

        public Line Subtitle {
            get {
                var time = GetCurrentTime();
                return Subtitles.Find(s => s.IsActive(time));
            }
        }

        public string SubtitleText {
            get {
                return Subtitle?.Text;
            }
        }
    }


    class Line {
        public int Index;
        public TimeSpan Start;
        public TimeSpan End;
        public string Text;

        override
        public string ToString() {
            return Text;
        }

        public bool IsActive(float sec) {
            return (sec > Start.TotalSeconds) && (sec < End.TotalSeconds);
        }

        private static TimeSpan ParseTime(string time) {
            return TimeSpan.ParseExact(time.Trim(), @"hh\:mm\:ss\,fff",
                CultureInfo.InvariantCulture);
        }

        public static List<Line> ParseSrt(string srtFile) {
            var ret = new List<Line>();
            if (File.Exists(srtFile)) {
                var data = File.ReadAllLines(srtFile);
                var stack = new List<string>();
                foreach (var line in data) {
                    if (line.Trim().Length == 0) {
                        try {
                            if (int.TryParse(stack[0], out int n)) {
                                var timeStr = stack[1].Split(new string[] { "-->" },
                                    StringSplitOptions.None);
                                ret.Add(new Line {
                                    Index = ret.Count,
                                    Start = ParseTime(timeStr[0]),
                                    End = ParseTime(timeStr[1]),
                                    Text = string.Join(" ", stack.GetRange(2, stack.Count - 2)).Trim()
                                });
                            }
                        } catch (Exception) { }
                        stack.Clear();
                    } else {
                        stack.Add(line);
                    }
                }
            }
            return ret;
        }
    }
}
