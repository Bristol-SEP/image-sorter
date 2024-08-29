import cv2
from matplotlib import pyplot as plt
from PIL import Image


def detectEdge(image):
    # gray scaling
    img = cv2.imread(image)
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)

    # noise reduction
    bfilter = cv2.bilateralFilter(gray, 11, 17, 17)
    # edge detection
    edged = cv2.Canny(bfilter, 30, 30)

    imgplot = plt.imshow(edged)
    plt.show()


detectEdge("testImage.jpg")
