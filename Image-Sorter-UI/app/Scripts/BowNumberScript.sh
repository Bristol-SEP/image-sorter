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
        description=`exiftool -s3 -Description $file `
        # isIndividualFolder code
        # if folder not already present create it
        if [ ! -d "$description" ]; then
            mkdir $description
        fi
        mv $file $description/
    fi
done
