import cv2
from matplotlib import pyplot as plt
import imutils
import numpy as np
from PIL import Image
import pytesseract


def detectEdge(image):
    # load image
    img = cv2.imread(image)
    # gray scaling
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # noise reduction
    bfilter = cv2.bilateralFilter(gray, 11, 17, 17)

    # Threshold
    ret, th = cv2.threshold(bfilter, 0, 255, cv2.THRESH_BINARY+cv2.THRESH_OTSU)

    crop_image = img[2300:2440, 440:560]
    boat_code = img[2500:2580, 1780:2050]

    # plt.imshow(boat_code)
    # plt.show()
    readText(crop_image)
    readText(boat_code)


def readText(img):
    # reads number plate
    text = pytesseract.image_to_string(img, config='--psm 11')
    print(text)


detectEdge("testImage.jpg")
