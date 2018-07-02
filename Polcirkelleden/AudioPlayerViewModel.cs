using AudioManager.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Polcirkelleden
{
   public class AudioPlayerViewModel
    {
        IAudioPlayerService _audioPlayer;
        public bool _isStopped;
        public event PropertyChangedEventHandler PropertyChanged;
        public static AudioPlayerViewModel instance = null;

        public string _commandText;
        public string CommandText
        {
            get { return _commandText; }
            set
            {
                _commandText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CommandText"));
            }
        }

        public string _commandParameter;
        public string CommandParameter
        {
            get { return _commandParameter; }
            set
            {
                _commandParameter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("CommandParameter"));
            }
        }

        public AudioPlayerViewModel(IAudioPlayerService audioPlayer)
        {            
            _audioPlayer = audioPlayer;
            _audioPlayer.OnFinishedPlaying = () =>
            {
                _isStopped = true;
                CommandText = "Audio Information";
            };
            CommandText = "Audio Information";
            _isStopped = true;
        }

        public ICommand _playPauseCommand;
        public ICommand PlayPauseCommand
        {
            get
            {
                return _playPauseCommand ?? (_playPauseCommand = new Command<string>(
                  (obj) =>
                  {
                      if (CommandText == "Audio Information")
                      {
                          if (_isStopped)
                          {
                              if (Application.Current.Properties["Language"].ToString() == "English")
                              {
                                  _isStopped = false;
                                  switch (obj)
                                  {
                                      case "1":
                                          _audioPlayer.Play("Audio/ACT_Page__8_A_audio_EN.mp3");
                                          //_audioPlayer.Play("Audio/ACT_Page__8_A_audio_EN.mp3");
                                          break;
                                      case "2":
                                          _audioPlayer.Play("Audio/ACT_Page__8_B_audio_EN.mp3");
                                          break;
                                      case "3":
                                          _audioPlayer.Play("Audio/ACT_Page__8_C_audio_EN.mp3");
                                          break;
                                      case "4":
                                          _audioPlayer.Play("Audio/ACT_Page__8_D_audio_EN.mp3");
                                          break;
                                      case "5":
                                          _audioPlayer.Play("Audio/ACT_Page__8_E_audio_EN.mp3");
                                          break;
                                      case "6":
                                          _audioPlayer.Play("Audio/ACT_Page__8_F_audio_EN.mp3");
                                          break;
                                      case "7":
                                          _audioPlayer.Play("ACT_Page_3_audio_EN.mp3");
                                          break;
                                      default:
                                          break;
                                  }
                              }
                              else
                              {
                                  _isStopped = false;
                                  switch (obj)
                                  {
                                      case "1":
                                          _audioPlayer.Play("Audio/ACT_Page__8_A_audio_EN.mp3");
                                          break;
                                      case "2":
                                          _audioPlayer.Play("Audio/ACT_Page__8_B_audio_EN.mp3");
                                          break;
                                      case "3":
                                          _audioPlayer.Play("Audio/ACT_Page__8_C_audio_EN.mp3");
                                          break;
                                      case "4":
                                          _audioPlayer.Play("Audio/ACT_Page__8_D_audio_EN.mp3");
                                          break;
                                      case "5":
                                          _audioPlayer.Play("Audio/ACT_Page__8_E_audio_EN.mp3");
                                          break;
                                      case "6":
                                          _audioPlayer.Play("Audio/ACT_Page__8_F_audio_EN.mp3");
                                          break;
                                      case "7":
                                          _audioPlayer.Play("ACT_Page_3_audio_SV.mp3");
                                          break;
                                      default:
                                          break;
                                  }
                              }
                          }
                          else
                          {
                              _audioPlayer.Play();
                          }
                          CommandText = "Pause";
                      }
                      else
                      {
                          _audioPlayer.Pause();
                          CommandText = "Audio Information";
                      }
                  }));
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Stop Audio player
        /// </summary>
        public void stop()
        {
            _audioPlayer.Stop();
        }

    }
}
