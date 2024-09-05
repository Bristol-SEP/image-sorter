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

# find contours in the thresholded image and sort them by
# their size in descending order, keeping only the largest
# ones
keypoints = cv2.findContours(edged.copy(), cv2.RETR_TREE, cv2.CHAIN_APPROX_SIMPLE)
contours = imutils.grab_contours(keypoints)
contours = sorted(contours, key=cv2.contourArea, reverse=True)[:5]

# initialize the license plate contour and ROI
lpCnt = None
roi = None
# loop over the license plate candidate contours
for c in contours:
    # compute the bounding box of the contour and then use
    # the bounding box to derive the aspect ratio
    (x, y, w, h) = cv2.boundingRect(c)
    ar = w / float(h)

    # check to see if the aspect ratio is rectangular
    if ar >= 1 and ar <= 2:
        # store the license plate contour and extract the
        # license plate from the grayscale image and then
        # threshold it
        lpCnt = c
        licensePlate = gray[y:y + h, x:x + w]
        roi = cv2.threshold(licensePlate, 0, 255,
                            cv2.THRESH_BINARY_INV)[1]

plt.imshow(light)
plt.show()
