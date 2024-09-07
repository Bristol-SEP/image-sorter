import cv2
import numpy as np
import matplotlib.pyplot as plt
import imutils
import re

# have a minimum and maximum aspect ratio to help search for the rectangle

# Read input image
img = cv2.imread("testImage.jpg")

# convert input image to grayscale
gray = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)

# blackhat morphological transformation
rectKern = cv2.getStructuringElement(cv2.MORPH_RECT, (15, 13))
blackhat = cv2.morphologyEx(gray, cv2.MORPH_BLACKHAT, rectKern)

# next, find regions in the image that are light
squareKern = cv2.getStructuringElement(cv2.MORPH_RECT, (3, 3))
light = cv2.morphologyEx(gray, cv2.MORPH_CLOSE, squareKern)
light = cv2.threshold(light, 225, 255,
                      cv2.THRESH_BINARY)[1]

#edge detection
bfilter = cv2.bilateralFilter(light, 11, 17, 17) #noise reduction
edged = cv2.Canny(bfilter, 30, 30) #edge detection

# compute the Scharr gradient representation of the blackhat
# image in the x-direction and then scale the result back to
# the range [0, 255]
gradX = cv2.Sobel(blackhat, ddepth=cv2.CV_32F,
                  dx=1, dy=0, ksize=-1)
gradX = np.absolute(gradX)
(minVal, maxVal) = (np.min(gradX), np.max(gradX))
gradX = 255 * ((gradX - minVal) / (maxVal - minVal))
gradX = gradX.astype("uint8")


# Preprocessing the image starts

# Convert the image to gray scale
gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

# Performing OTSU threshold
ret, thresh1 = cv2.threshold(
    gray, 0, 255, cv2.THRESH_OTSU | cv2.THRESH_BINARY_INV)

# Specify structure shape and kernel size.
# Kernel size increases or decreases the area
# of the rectangle to be detected.
# A smaller value like (10, 10) will detect
# each word instead of a sentence.
rect_kernel = cv2.getStructuringElement(cv2.MORPH_RECT, (12, 8))

# Applying dilation on the threshold image
dilation = cv2.dilate(thresh1, rect_kernel, iterations=1)

# Finding contours
contours, hierarchy = cv2.findContours(dilation, cv2.RETR_EXTERNAL,
                                       cv2.CHAIN_APPROX_NONE)

# Creating a copy of image
im2 = img.copy()

# Looping through the identified contours
# Then rectangular part is cropped and passed on
# to pytesseract for extracting text from it
# Extracted text is then written into the text file
for cnt in contours:
        x, y, w, h = cv2.boundingRect(cnt)

        if w >= 50 and h >= 50:
            # Drawing a rectangle on copied image
            rect = cv2.rectangle(im2, (x, y), (x + w, y + h), (0, 255, 0), 2)

            # Cropping the text block for giving input to OCR
            cropped = im2[y:y + h, x:x + w]
            plt.imshow(cropped)
            plt.show()
cv2.drawContours(im2, contours, -1, (0, 255, 0), 3)

plt.imshow(im2)
plt.show()
