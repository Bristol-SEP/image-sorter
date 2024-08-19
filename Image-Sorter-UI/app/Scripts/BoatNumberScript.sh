#!/bin/bash

# Create the variables
affectedFolder=$1
targetFolder=$2
folderName=$3

# Enter the folder to search through
cd "$targetFolder" || exit

# Search for files and read metadata
allImages=$(find . -type f -name "*.jpg")

# Enter the folder to write to
cd "$affectedFolder" || exit

if [ ! -d "$folderName" ]; then
    mkdir "$folderName"
fi

for image in $allImages; do
    description=$(exiftool -s3 -Description "$image")
    boatNum=$(awk -F'Boat Code:' '{print $2}' <<< "$description" | cut -d "." -f1)
    # if folder not already present create it
    if [ ! -d "$folderName/$boatNum" ]; then
        mkdir "$folderName/$boatNum"
    fi
    cp "$image" "$folderName/$boatNum/"
done

