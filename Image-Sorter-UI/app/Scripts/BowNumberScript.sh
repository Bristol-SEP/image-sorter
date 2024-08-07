#!/bin/bash

# Create the variables
affectedFolder=$1
numberOfBoats=$2
isIndividualFolder=$3

# Enter the folder
cd "$affectedFolder"

# Read the metadata
for file in *; do
    # Enters is a direct folder is a file of type jpg
    if find "$file" -maxdepth 1 -type f -name '*.jpg' | grep -q .; then
        exiftool -Description $file
    fi
done
