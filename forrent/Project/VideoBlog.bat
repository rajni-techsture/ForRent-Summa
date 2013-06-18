echo On
SET MainFile=%1
for  %%f in (%~n1) do SET NameWithoutExt=%%f
        SET EXT=.flv
        SET FINAL=%NameWithoutExt%%EXT%
        SET C=memberfiles\videos\temp\
        SET R=%~p1
	set InputFile=memberfiles/videos/temp/
	set OutputFile=memberfiles/videos/
	set ThumbnailFile=memberfiles/videos/thumbnails/
        ffmpeg -i %InputFile%%MainFile% -ab 56 -ar 44100 -b 200 -r 25  -s 704x576  %OutputFile%%FINAL%
	ffmpeg -y -i %InputFile%%MainFile% -f mjpeg -ss 2 -vframes 1 -s 360×254 -an %ThumbnailFile%%NameWithoutExt%.jpg
	Del "%R%%C%%MainFile%"
ENDLOCAL