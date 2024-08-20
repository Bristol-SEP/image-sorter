from PIL import Image
import cv2
import numpy as np

import pytesseract
from pytesseract import Output

# If you don't have tesseract executable in your PATH, include the following:
pytesseract.pytesseract.tesseract_cmd = r'/bin/tesseract'
# Example tesseract_cmd = r'C:\Program Files (x86)\Tesseract-OCR\tesseract'

original = Image.open('/home/will/repos/image-sorter/model/images/tt_01/BUA04652.jpg')
imgL = original.convert('L')
ret,img = cv2.threshold(np.array(imgL), 125, 255, cv2.THRESH_BINARY)

# Simple image to string
d = pytesseract.image_to_data(img, output_type=Output.DICT)

print(d["text"])

# THOUGHTS WERE: USE EAST TO GET BOUNDING BOXES OF TEXT, 
# THEN USE PYTESSERACT TO READ THAT TEXT
# THEN USE REGEX TO FIND RELEVANT INFORMATION