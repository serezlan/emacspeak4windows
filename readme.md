# Emacspeak 4 Windows

## Overview

[Emacspeak](http://emacspeak.sourceforge.net) is an auditory interface to [Emacs](http://gnu.org/software/emacs). It intercepts all Emacs commands, and produces feedback using text-to-speech (TTS) and audio cues (earcons).

While Emacspeak is itself cross-platform, being written in Emacs Lisp, it uses speech servers to communicate with hardware/software speech synthesizers. To get it working on Windows, I have written a speech server for Windows, using the platform's native TTS/audio APIs. The server is actually just a command line program which reads commands from standard input, as defined in [this spec](http://emacspeak.sourceforge.net/info/html/TTS-Servers.html#TTS-Servers).

For convenience I have also included a preassembled archive in this repository, including a compiled version of Emacspeak and the Windows speech server, and a batch file to make it easier to start Emacs with Emacspeak loaded.

## Current Status

This version is now has been updated to use dotnet framework version 4.7 and emacspeak version 53.

## Trying It Out

### Get Emacs

First, you must download Emacs for Windows. You can find details on the [Emacs homepage](http://gnu.org/software/emacs).

### Use the Preassembled Archive

A quick way to get up and running may be to use the preassembled archive. However, this is just what works on my machine, and I can't provide support for this - it should continue working with new versions of Emacs 27.2.x, and with all versions of Windows, but I haven't tried that. If it doesn't work for you, you could try building from source, as described below.

Simply grab the preassembled/v53.zip file and uncompress it into your emacs directory. As the name implies, this is a compiled version of Emacspeak 53, plus the Windows speech server, and a batch file to help launch Emacspeak.

To start Emacs with Emacspeak enabled, run emacs_dir\bin\emacspeak.cmd. Though not necessary, I'd recommend starting this from an elevated command prompt (or tick the run-as-administrator checkbox when creating a shortcut).

### Emacs Configuration

This is a purely optional step. While the emacspeak.cmd script is an easy way to get up and running, you may want to customize your Emacs configuration file, to load Emacspeak and set various settings.

For some reason, Emacs looks for your .emacs file in %home%, instead of %userprofile%. So, make sure you've defined that.

The start of my .emacs file is below (many more customizations can be made):

    (setenv "dtk_program" "windows")
    (load-file "c:/emacs/share/emacs/site-lisp/emacspeak/lisp/emacspeak-setup.el")
    (dtk-set-rate 5 t)
    (emacspeak-toggle-auditory-icons t)
    (emacspeak-sounds-select-theme "3d/")

## Feedback

If you try this out, and particularly if you find it useful, please do get in touch. You can email "Me" at "yusuf.ismail01157@gmail.com".
