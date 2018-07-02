using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AudioManager.Interfaces
{
    public interface IAudioPlayerService
    {
        void Play(string pathToAudioFile);
        void Play();
        void Pause();
        void Stop();
        Action OnFinishedPlaying { get; set; }
    }

}
