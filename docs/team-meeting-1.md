# Team Meeting 1

## Current Workflow
1. Create new folder in the camera for each race/division/category (4-50 boats)
2. Folders with the RAW images are then imported onto a laptop/exteranl SSD (usually import every couple of categories/races)
3. Folders imported into Adobe Lightroom. All images from all the folders appear at once, but remain sorted in their forlers
4. All images are edited and then exported back to their respective folders in JPG format (RAWs also remain in those folders)
5. Edited JPGs only are uploaded to pre-made corresponding folders on our cloud based photo sales platform Zenfolio


### What client wants
After step 4 run through our software which creates a new folder for each bow number / boatclub
## Ideas 
- Run natively on desktop app (less cost and less file replication)
- CR using python backend
- Frontend avalonia with dotnet

1. User selects sport and the relevant tags
2. Look through photos, tag metadata and read all that we can and mark as read
3. Extrapolate other photos data from those identified
4. Ask user about any photos that could not be identified or could be either or
5. User decides what new folder structure he wants based off these new metadata tags
6. Click confirm and folders will be reorganised on the desktop, and the metadata tags removed?

## Questions
- How are photos uploaded when there are multiple photographers (timeline)?
- Is there an easily accessible database from boat codes to clubs?
- Do you want to identify boats in side by side races or should people just look at their final?
- Could we potentially use race information such as the draw to help with the process?
- Add metadata to photos then they decide how to organise?
- Are there any similar programs you have found so far? If so what differences would you want?
- Can we have some test data (folder from a regatta without watermark)
- Assuming he wants it to run on laptops only?
- MVP Requirements?
- Deadline for MVP?

## Answers
- Photos are uploaded in separate folders when multiple photographers are present
e.g. bankside and start line folders
- There isn't a public database but Kit is happy to do it manually
- Yes but head race time trial style is more important as it occurs earlier in the year
- Use any information you want
- Metadata is fine doesn't affect size enough to care
- Similar program used for london marathon with facial recognition, however is
business to consumer rather than business to business
- General plan is to run mvp for a year on rowing so Kit can test it all then 
branch out to other sports as rowing is small market 

## MVP Requirements
- Bare minimum is metadata tagging, but ideally aim for:
- Import edited photos to our software
- User defines structure (by crew number, increments (i.e 1-25, 25-50 etc))
  - Time trails, regattas, headraces: Only ever be increments of crew no. 
  - For 2 photographers: Head of river, crews, bank, bridge.
  - For regattas, may be complex structure but look at as-and-when
  - Sometimes may sort by chunks of time or portions of a race
- Exports sorted images by rearranging original folders
- Only sort jpegs, keep same file name as RAW.

## Deadlines
- Good to test from October
- Test at a few head events before Christmas
- If good potentially develop something for Regatta season starting from late april, early may

