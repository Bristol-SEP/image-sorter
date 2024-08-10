#!/bin/bash

# Create the variables
affectedFolder=$1
numberOfBoats=$2
isIndividualFolder=$3

organise_boats(){
    # Find the group which the directory should lay within
    startNum=$(((($description - 1) / $numberOfBoats) * $numberOfBoats + 1))
    endNum=$(($startNum - 1 + $numberOfBoats))
    title=$startNum"-"$endNum
    # Move to directory
    if [ ! -d "$title" ]; then
        mkdir $title
    fi
    mv $1 $title
}

group_boats(){
    for file in *; do
        # Enters is a direct folder is a file of type jpg
        if find "$file" -maxdepth 1 -type f -name '*.jpg' | grep -q .; then
            description=`exiftool -s3 -Description $file `
            organise_boats $description
        elif [ -d "$file" ]; then
            organise_boats $file
        fi
    done
}

create_individual_folder(){
    # Create individual folders
    # if folder not already present create it
    if [ ! -d "$description" ]; then
        mkdir $description
    fi
    mv $file $description/
}

# Enter the folder
cd "$affectedFolder"

# Read the metadata
for file in *; do
    # Enters is a direct folder is a file of type jpg
    if find "$file" -maxdepth 1 -type f -name '*.jpg' | grep -q .; then
        description=`exiftool -s3 -Description $file `
        # isIndividualFolder code
        if [ $isIndividualFolder = "True" ]; then
            create_individual_folder
        fi
    fi
done
# Move individual folders into range folder
group_boats
