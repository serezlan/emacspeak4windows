using System.Collections.Generic;
using NLog;

namespace SpeechServer
{
    internal static class Punctuation
    {
        private static Logger _log = LogManager.GetCurrentClassLogger();
        public static bool ModeAll { get; set; } = true;
        public static readonly Dictionary<string, string> CharReplacement = new Dictionary<string, string>()
    {
    {"(", " left parent " },
    {")", " right parent "},
    {"!", " exclamation "},
    {"#", " pount "},
    {".", " dot "},
    {",", " comma "},
    {";", " semi "},
    {"/", " slash "}
    };
        public static readonly Dictionary<char, string> Replacements = new Dictionary<char, string>
        {
            { '<', "less" },
{ '>', "greater" },
{ '#', "number" },
{ '?', "question" },
{ '!', "exclaim" },
{ '"', "quote" },
{ '\'', "apostrophe" },
{ '*', "star" },
{ '&', "and" },
{ '£', "pounds" },
{ '$', "dollar" },
{ '%', "percent" },
{ '^', "caret" },
{ '=', "equals" },
{ '-', "dash" },
{ '+', "plus" },
{ '(', "left paren" },
{ ')', "right paren" },
{ '{', "left brace" },
{ '}', "right brace" },
{ '[', "left bracket" },
{ ']', "right bracket" }
        };

	public static void SetPunctuationMode(string [] args)
	{
	    if (args == null || args.Length == 0)
                return;

            var mode = args[0].ToLower();
            switch (mode)
            {
		case "all":
                    _log.Info("set punctuation mode to all");
                    ModeAll = true;
                    break;
		case "some":
                    _log.Info("set punctuation to some");
                    ModeAll = false;
                    break;
		default:
                    _log.Warn("Unknown punctuation mode: " + mode);
                    break;

            }

        }
    }
}
