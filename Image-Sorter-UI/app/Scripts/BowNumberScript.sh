#!/bin/bash

# Create the variables
affectedFolder=$1
numberOfBoats=$2
isIndividualFolder=$3

# Moves folders or images into the specified range folders
organise_boats(){
    if [[ ! $numberOfBoats = "0" ]]; then
        # Find the group which the directory should lay within
        startNum=$((((description - 1) / numberOfBoats) * numberOfBoats + 1))
        endNum=$((startNum - 1 + numberOfBoats))
        title=$startNum"-"$endNum
        # Move to directory
        if [ ! -d "$title" ]; then
            mkdir $title
        fi
        mv "$1" $title
    fi
}

# If isIndividualFolder is true this will be used to send the folder to
# organise_boats instead of individual images
group_boats(){
    for file in *; do
        # Enters is a direct folder is a file of type jpg
        if [ -d "$file" ]; then
            description=$file
            organise_boats "$description"
        fi
    done
}

# Used to move images into their individual folders
create_individual_folder(){
    # Create individual folders
    # if folder not already present create it
    if [ ! -d "$description" ]; then
        mkdir "$description"
    fi
    mv "$file" "$description"/
}

# Enter the folder
cd "$affectedFolder" || exit

# Read the metadata
for file in *; do
    # Enters is a direct folder is a file of type jpg
    if find "$file" -maxdepth 1 -type f -name '*.jpg' | grep -q .; then
        description=$(exiftool -s3 -Description "$file")
        # isIndividualFolder code
        if [ "$isIndividualFolder" = "True" ]; then
            create_individual_folder
        else
            organise_boats "$file"
        fi
    fi
done

# Move individual folders into range folder
if [[ $isIndividualFolder = "True" ]]; then
    group_boats
fi
