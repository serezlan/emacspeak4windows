TARGET=%HOME%\emacs\share\emacs\site-lisp\emacspeak-53.0\servers
# TARGET=%HOME%\emacs\share\emacs\site-lisp\emacspeak\servers

exe:
	dotnet build --nologo
	dotnet publish --nologo -c Release -o publish

cp:
	copy /y .\publish\* ${TARGET}
	copy /y NLog.config ${TARGET}

deletelog:
	del /q ${TARGET}\jasmine.log

all: deletelog exe  cp
