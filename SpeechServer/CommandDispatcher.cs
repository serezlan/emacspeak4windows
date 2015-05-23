﻿namespace EmacspeakWindowsSpeechServer
{
    using System;
    using System.Collections.Generic;

    internal static class CommandDispatcher
    {
        private delegate void CommandHandler(string[] args);

        // Maps command names to methods.
        private static Dictionary<string, CommandHandler> commandTable = new Dictionary<string, CommandHandler>
        {
            { "version", SpeechManager.Version },
            { "tts_say", SpeechManager.Say },
            { "l", SpeechManager.SayCharacter },
            { "d", SpeechManager.Dispatch },
            { "tts_pause", SpeechManager.Pause },
            { "tts_resume", SpeechManager.Resume },
            { "s", SpeechManager.StopSpeaking },
            { "q", SpeechManager.QueueText },
            { "p", AudioManager.PlayAudio },
            { "t", NotImplemented },
            { "sh", SpeechManager.QueueSilence },
            { "tts_reset", SpeechManager.Reset },
            { "tts_set_punctuations", NotImplemented },
            { "tts_set_speech_rate", SpeechManager.SetRate },
            { "tts_set_character_scale", SpeechManager.SetCharacterScale },
            { "tts_split_caps", NotImplemented },
            { "tts_capitalize", SpeechManager.Capitalize },
            { "tts_allcaps_beep", NotImplemented }
                    };

        public static void Dispatch(Command command)
        {
            if (command != null && commandTable.ContainsKey(command.Name))
            {
                commandTable[command.Name](command.Arguments);
            }
        }

        private static void NotImplemented(IList<string> args)
        {
            // Do nothing.
        }
    }
}
