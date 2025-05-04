using Plugin.Maui.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeyondHana.ViewModels
{
    public class BGAudioPlayerVM
    {
        private IAudioPlayer? audioPlayer;

        public async Task PlayAsync(string fileName, double volume)
        {
            audioPlayer?.Stop();
            await LoadNewPlayerAsync(fileName, volume);
            await Task.Delay(50);
            audioPlayer.Play();
        }

        public void Stop()
        {
            audioPlayer?.Stop();
        }

        public async void Preload(string fileName)
        {
            
            if (fileName != Preferences.Get("currentBGAudioFile", fileName))
            {
                await LoadNewPlayerAsync(fileName, 1.0);
            } 
        }
        private async Task LoadNewPlayerAsync(string fileName, double volume)
        {
            audioPlayer?.Stop();
            audioPlayer?.Dispose();

            var stream = await FileSystem.OpenAppPackageFileAsync(fileName);
            audioPlayer = AudioManager.Current.CreatePlayer(stream);
            audioPlayer.Volume = volume;
            Preferences.Set("currentBGAudioFile", fileName); 
        }

        public void SetVolume(double volume)
        {
            if (audioPlayer != null)
            {
                audioPlayer.Volume = volume;
            }
        }
    }
}
