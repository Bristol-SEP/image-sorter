#!/bin/bash

# TODO look at the description and only extract the boat code section for file name
# Create the variables
affectedFolder=$1
targetFolder=$1

# Enter the folder to search through
cd "$targetFolder" || exit

# Search for files and read metadata
allImages=$(find . -type f -name "*.jpg")

# Enter the folder to write to
cd "$affectedFolder" || exit

if [ ! -d "Boat Clubs" ]; then
    mkdir "Boat Clubs"
fi

for image in $allImages; do
    description=$(exiftool -s3 -Description "$image")
    boatNum=$(awk -F'Boat Code:' '{print $2}' <<< "$description" | cut -d "." -f1)
    # if folder not already present create it
    if [ ! -d "Boat Clubs/$boatNum" ]; then
        mkdir "Boat Clubs/$boatNum"
    fi
    cp "$image" "Boat Clubs/$boatNum/"
done

