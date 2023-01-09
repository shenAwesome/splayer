using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;

//https://github.com/justcoding121/windows-user-action-hook

namespace SPlayer {


    public class SPlayer {

        public List<Line> Subtitles = new List<Line>();
        public long Duration = 0;

        readonly LibVLC LibVLC = new LibVLC();
        public readonly MediaPlayer player;


        private long lastPlayTime = 0;
        private long lastPlayTimeGlobal = 0;

        public SPlayer() {
            player = new MediaPlayer(LibVLC);
            player.Playing += Player_Playing;
            player.EndReached += Player_EndReached;
        }

        public void Reload() {
            _runningMedia = "";
            Run(() => Open(MediaPath));
        }

        /** isplaying with 1.5 sec delay**/
        public bool IsPlaying {
            get {
                return player.IsPlaying && (now - _playingStart) > 1500;
            }
        }


        private VideoView view;
        public void Install(VideoView view) {
            view.MediaPlayer = player;
            this.view = view;
        }

        public int VideoWidth = 0;
        public int VideoHeight = 0;

        private string _runningMedia = null;

        //only trigger by open (when media changes)
        long _playingStart = 0;
        private void Player_Playing(object sender, EventArgs e) {
            player.SetSpu(-1);
            if (_runningMedia != MediaPath) {
                OnOpened?.Invoke(this, null);
                player.Volume = 100;
                Duration = player.Media.Duration / 1000;

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
                            VideoWidth = Convert.ToInt32(track.Data.Video.Width);
                            VideoHeight = Convert.ToInt32(track.Data.Video.Height);
                            break;
                        case TrackType.Text:
                            //Debug.WriteLine("Subtitle");
                            //Debug.WriteLine(track.Data.Subtitle.Encoding);
                            break;
                    }
                }

            }
            _runningMedia = MediaPath;
            _playingStart = now;
        }

        private void Player_EndReached(object sender, EventArgs e) {
            Run(() => {
                player.Stop();
                player.Play();
            });
        }

        public long Progress {
            get {
                return Convert.ToInt64(GetCurrentTime());
            }

            set {
                var isPlaying = player.IsPlaying;
                if (isPlaying) player.SetPause(true);
                player.Time = value * 1000;
                if (isPlaying) player.SetPause(false);
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
                if (MediaPath == null) return null;
                return Path.GetFileNameWithoutExtension(MediaPath);
            }
        }

        public bool IsLoaded {
            get {
                return MediaPath != null;
            }
        }

        public string MediaPath;
        public bool HasSubtitles {
            get {
                return Subtitles.Count > 0;
            }
        }


        public event EventHandler<EventArgs> OnOpened;

        public void Open(string path) {
            Open(path, -1);
        }

        public void Open(string path, long progress) {
            if (!File.Exists(path)) return;

            Duration = 0;
            _runningMedia = "";
            var media = new Media(LibVLC, new Uri(path));
            player.Play(media);
            media.Dispose();
            var dir = Path.GetDirectoryName(path);
            var name = Path.GetFileNameWithoutExtension(path) + ".srt";
            var srtFile = new List<string> {
                Path.Combine(dir,name),
                Path.Combine(dir,"srt",name),
            }.Find(p => {
                return File.Exists(p);
            });
            Subtitles = Line.ParseSrt(srtFile);
            MediaPath = path;

            if (progress > 0) {
                Run(() => {
                    Progress = progress;
                });
            }
        }

        public void Run(Action action) {
            new Thread(new ThreadStart(action)).Start();
        }

        public void SetStretch(bool stretch) {
            if (stretch && view != null) {
                player.AspectRatio = string.Format("{0}:{1}", view.Size.Width, view.Size.Height);
            } else {
                player.AspectRatio = null;
            }
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

        private long now {
            get {
                return DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
            }
        }
    }


    public class Line {
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
