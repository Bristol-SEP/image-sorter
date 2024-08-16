#!/bin/bash

# TODO look at the description and only extract the boat code section for file name
# Create the variables
affectedFolder=$1
targetFolder=$1

# Enter the folder
cd "$affectedFolder" || exit

# Search for files and read metadata
allImages=$(find . -type f -name "*.jpg")
for image in $allImages; do
    description=$(exiftool -s3 -Description "$image")
    boatNum=$(awk -F'Boat Code:' '{print $2}' <<< "$description" | cut -d "." -f1)
    # if folder not already present create it
    if [ ! -d "$boatNum" ]; then
        mkdir "$boatNum"
    fi
    cp "$image" "$boatNum/"
done

