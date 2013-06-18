echo OFF
SET MainFile=%1
	for  %%f in (%~n1) do SET NameWithoutExt=%%f
	set ThumbnailFile=memberfiles/videos/thumbnails/
	set OutputFile=memberfiles/videos/
	ffmpeg -y -i %OutputFile%%MainFile% -f mjpeg -ss 2 -vframes 1 -s 1024×768 -an %ThumbnailFile%%NameWithoutExt%.jpg
ENDLOCAL