using System;
using System.Diagnostics;
using AudioManager.Interfaces;
using AVFoundation;
using Foundation;
using Polcirkelleden.iOS;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(AudioPlayerService))]
[assembly: ExportRenderer(typeof(WebView), typeof(WebViewSourceiOSRenderer))]
namespace Polcirkelleden.iOS
{
    
    public class AudioPlayerService: IAudioPlayerService
    {
        private AVAudioPlayer _audioPlayer = null;
        public Action OnFinishedPlaying { get; set; }
        public AudioPlayerService()
        {
        }

        public void Play(string pathToAudioFile)
        {
            try
            {
                // Check if _audioPlayer is currently playing
                if (_audioPlayer != null)
                {
                    _audioPlayer.FinishedPlaying -= Player_FinishedPlaying;
                    _audioPlayer.Stop();
                }
                string localUrl = pathToAudioFile;
                _audioPlayer = AVAudioPlayer.FromUrl(NSUrl.FromFilename(localUrl));
                _audioPlayer.FinishedPlaying += Player_FinishedPlaying;
                //_audioPlayer.Volume = 0.5f;
                _audioPlayer.Play();
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
        }

        public void Player_FinishedPlaying(object sender, AVStatusEventArgs e)
        {
            OnFinishedPlaying?.Invoke();
        }

        public void Pause()
        {
            _audioPlayer?.Pause();
        }

        public void Play()
        {
            try
            {
                _audioPlayer?.Play();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public void Stop()
        {
            _audioPlayer?.Stop();
        }
    }
}
 
namespace Polcirkelleden.iOS
{
    public class WebViewSourceiOSRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            if (NativeView is UIWebView webView)
            {
                webView.MediaPlaybackRequiresUserAction = false;
            }

            base.OnElementChanged(e);
        }
    }
}