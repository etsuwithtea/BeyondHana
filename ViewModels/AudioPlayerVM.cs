using Plugin.Maui.Audio;
namespace BeyondHana.ViewModels
{
    public class AudioPlayerVM
    {
        private IAudioPlayer? audioPlayer;
        public async Task PlayAudioAsync(string fileName, double volume)
        {
            // stopping and disposing the previous player
            audioPlayer?.Stop();
            audioPlayer?.Dispose();

            // create a new player
            var fileStream = await FileSystem.OpenAppPackageFileAsync(fileName);
            audioPlayer = AudioManager.Current.CreatePlayer(fileStream);

            // set the volume and play
            if (audioPlayer != null)
            {
                audioPlayer.Volume = volume;
                audioPlayer.Play();
            }
        }
    }
}