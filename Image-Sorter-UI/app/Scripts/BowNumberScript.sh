#!/bin/bash

# Create the variables
affectedFolder=$1
numberOfBoats=$2
isIndividualFolder=$3

group_boats(){
    startNum=$(((($description - 1) / $numberOfBoats) * $numberOfBoats + 1))
    endNum=$(($startNum - 1 + $numberOfBoats))
    title=$startNum"-"$endNum
    if [ ! -d "$title" ]; then
        mkdir $title
    fi
    mv $1 $title
}

create_individual_folder(){
    # Create individual folders
    # if folder not already present create it
    if [ ! -d "$description" ]; then
        mkdir $description
    fi
    mv $file $description/
    # Move individual folders into range folder
    group_boats $description
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
        else 
            group_boats $file
        fi
    fi
done
