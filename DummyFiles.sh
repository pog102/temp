#!/bin/bash

# Base directory for dummy structure
BASE_DIR="./dummy_test_dir"

declare -A file_structure=(
  ["images"]="photo1.jpg image2.png"
  ["videos"]="clip1.mp4"
  ["documents"]="report.pdf notes.txt"
  ["audio"]="song.mp3"
  ["archives"]="backup.zip"
)

mkdir -p "$BASE_DIR"

for folder in "${!file_structure[@]}"; do
    subdir="$BASE_DIR/$folder"
    mkdir -p "$subdir"
    
    for file in ${file_structure[$folder]}; do
        touch "$subdir/$file"
    done
done


