#!/bin/bash

# Create the variables
affectedFolder=$1
targetFolder=$1

# Enter the folder
cd "$affectedFolder" || exit

# Search for files and read metadata
allImages=$(find . -type f -name "*.jpg")
for image in $allImages; do
    description=$(exiftool -s3 -Description "$image")
    # if folder not already present create it
    if [ ! -d "$description" ]; then
        mkdir "$description"
    fi
    cp "$image" "$description/"
done

