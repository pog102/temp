#!/bin/bash

pngs=~/Nuotraukos/png
jpgs=~/Nuotraukos/jpg
text=~/Tekstai/
mp4=~/Filmai/
mp3=~/Muzika/
pdf=~/Dokumentai
zip=~/Archivas
mkdir -p $pngs $jpgs $text $mp4 $mp3 $pdf

find . -type f | while IFS= read -r file; do
	case "$file" in
		*.png) 
			echo "$file -> $pngs"
			mv $file $pngs;;
		*.jpg) 

			echo "$file -> $jpgs"
			mv $file $jpgs;;
		*.txt) 

			echo "$file -> $text"
			mv $file $text;;
		*.mp4) 

			echo "$file -> $mp4"
			mv $file $mp4;;
		*.mp3) 

			echo "$file -> $mp3"
			mv $file $mp3;;
		*.pdf) 

			echo "$file -> $pdf"
			mv $file $pdf;;
		*.zip)

			echo "$file -> $zip"
			mv $file $zip;;
		*) echo "nezinomas failas: $file";;
	esac
done

