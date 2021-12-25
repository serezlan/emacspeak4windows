using System;
using NLog;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using NAudio.Extras;


namespace SpeechServer
{
    internal static class AudioManager
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        // private static readonly WindowsMediaPlayer player = new WindowsMediaPlayer();
        private static PlaybackEngine _player = new PlaybackEngine();

        public static void PlayAudio(string[] args)
        {
            if (args == null || args.Length < 1 || args[0].Length == 0)
            {
                return;
            }

            _player.PlaySound(args[0]);

            return;
            // var audioFile = string.Join(" ", args);
            // _log.Debug(audioFile);

	    // using (var audioDevice = new WaveOutEvent())
            // using (var player = new AudioFileReader(audioFile))
            // {
            //     audioDevice.Init(player);
            //     audioDevice.Play();

	    // 	while (audioDevice.PlaybackState == PlaybackState.Playing)
            //         Thread.Sleep(100);
            // }

        }
    }

    internal class PlaybackEngine : IDisposable
    {
        private readonly IWavePlayer player;
        private readonly MixingSampleProvider mixer;
	
	public PlaybackEngine(int sampleRate = 44100, int channel = 2)
	{
            player = new WaveOutEvent();
            mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, channel));
            mixer.ReadFully = true;
            player.Init(mixer);
            player.Play();
        }

	public void PlaySound (string filename)
	{
            var input = new AudioFileReader(filename);
            AddMixerInput(new AutoDisposeFileReader(input));
        }

	    private ISampleProvider ConvertToRightChannelCount(ISampleProvider input)
    {
        if (input.WaveFormat.Channels == mixer.WaveFormat.Channels)
        {
            return input;
        }
        if (input.WaveFormat.Channels == 1 && mixer.WaveFormat.Channels == 2)
        {
            return new MonoToStereoSampleProvider(input);
        }
        throw new NotImplementedException("Not yet implemented this channel count conversion");
    }

	        private void AddMixerInput(ISampleProvider input)
    {
        mixer.AddMixerInput(ConvertToRightChannelCount(input));
    }
		
        public void Dispose ()
	{
	    if (player != null)
                player.Dispose();
        }
    }
}
