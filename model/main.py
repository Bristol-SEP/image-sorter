""" 
Main file that encapsulates the detection, recognition and labelling process
"""

import cv2
import math
import numpy as np
import argparse
from pathlib import Path
import fnmatch
import easyocr
import pytesseract


parser = argparse.ArgumentParser(
    description="Script for Image Sorting using EAST and pytesseract OCR"
)
parser.add_argument(
    "--input",
    help="Path to input image file.",   
)
parser.add_argument(
    "--model",
    "-m",
    required=True,
    help="Path to a binary .pb file contains trained detector network.",
)
parser.add_argument(
    "--ocr",
    default="crnn.onnx",
    help="Path to a binary .pb or .onnx file contains trained recognition network",
)
parser.add_argument(
    "--width",
    type=int,
    default=320,
    help="Preprocess input image by resizing to a specific width. It should be multiple by 32.",
)
parser.add_argument(
    "--height",
    type=int,
    default=320,
    help="Preprocess input image by resizing to a specific height. It should be multiple by 32.",
)
parser.add_argument("--thr", type=float, default=0.75, help="Confidence threshold.")
parser.add_argument(
    "--nms", type=float, default=0.4, help="Non-maximum suppression threshold."
)
args = parser.parse_args()

def decodeBoundingBoxes(scores, geometry, scoreThresh):
    detections = []
    confidences = []

    ############ CHECK DIMENSIONS AND SHAPES OF geometry AND scores ############
    assert len(scores.shape) == 4, "Incorrect dimensions of scores"
    assert len(geometry.shape) == 4, "Incorrect dimensions of geometry"
    assert scores.shape[0] == 1, "Invalid dimensions of scores"
    assert geometry.shape[0] == 1, "Invalid dimensions of geometry"
    assert scores.shape[1] == 1, "Invalid dimensions of scores"
    assert geometry.shape[1] == 5, "Invalid dimensions of geometry"
    assert (
        scores.shape[2] == geometry.shape[2]
    ), "Invalid dimensions of scores and geometry"
    assert (
        scores.shape[3] == geometry.shape[3]
    ), "Invalid dimensions of scores and geometry"
    height = scores.shape[2]
    width = scores.shape[3]
    for y in range(0, height):

        # Extract data from scores
        scoresData = scores[0][0][y]
        x0_data = geometry[0][0][y]
        x1_data = geometry[0][1][y]
        x2_data = geometry[0][2][y]
        x3_data = geometry[0][3][y]
        anglesData = geometry[0][4][y]
        for x in range(0, width):
            score = scoresData[x]

            # If score is lower than threshold score, move to next x
            if score < scoreThresh:
                continue

            # Calculate offset
            offsetX = x * 4.0
            offsetY = y * 4.0
            angle = anglesData[x]

            # Calculate cos and sin of angle
            cosA = math.cos(angle)
            sinA = math.sin(angle)
            h = x0_data[x] + x2_data[x]
            w = x1_data[x] + x3_data[x]

            # Calculate offset
            offset = [
                offsetX + cosA * x1_data[x] + sinA * x2_data[x],
                offsetY - sinA * x1_data[x] + cosA * x2_data[x],
            ]

            # Find points for rectangle
            p1 = (-sinA * h + offset[0], -cosA * h + offset[1])
            p3 = (-cosA * w + offset[0], sinA * w + offset[1])
            center = (0.5 * (p1[0] + p3[0]), 0.5 * (p1[1] + p3[1]))
            detections.append((center, (w, h), -1 * angle * 180.0 / math.pi))
            confidences.append(float(score))

    # Return detections and confidences
    return [detections, confidences]

def detect_text():
    confThreshold = args.thr
    nmsThreshold = args.nms
    inpWidth = args.width
    inpHeight = args.height
    modelDetector = args.model

    net = cv2.dnn.readNet(modelDetector)

    layerNames = [
        "feature_fusion/Conv_7/Sigmoid",
        "feature_fusion/concat_3",
    ]

    tickmeter = cv2.TickMeter()

    frame = cv2.imread(args.input)

    # Get frame height and width
    height_ = frame.shape[0]
    width_ = frame.shape[1]
    rW = width_ / float(inpWidth)
    rH = height_ / float(inpHeight)

    # Create a 4D blob from frame.
    blob = cv2.dnn.blobFromImage(
        frame, 1.0, (inpWidth, inpHeight), (123.68, 116.78, 103.94), True, False
    )

    net.setInput(blob)

    tickmeter.start()
    outs = net.forward(layerNames)
    tickmeter.stop()

    print(f"Found boxes in {tickmeter.getTimeSec()} seconds")

    # Get scores and geometry
    scores = outs[0]
    geometry = outs[1]
    [boxes, confidences] = decodeBoundingBoxes(scores, geometry, confThreshold)

    print(boxes)

def main():
    img = cv2.imread(args.input)

    if img is None:
        raise ValueError("Error loading the image. Please check the file path.")
    
    # Resize down to 1920 width
    resized = cv2.resize(img, (1920, (1920 * img.shape[0]) // img.shape[1]))

    # cv2.namedWindow("Cropped", cv2.WINDOW_NORMAL)
    # cv2.imshow("Cropped", cropped)
    # cv2.waitKey()

    print(pytesseract.image_to_data(resized, output_type=pytesseract.Output.DATAFRAME))



if __name__ == "__main__":
    main()
