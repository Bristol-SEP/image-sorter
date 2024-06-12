import cv2
import math
import numpy as np
import argparse
from pathlib import Path
import fnmatch

parser = argparse.ArgumentParser(
    description="Use this script to run TensorFlow implementation (https://github.com/argman/EAST) of "
    "EAST: An Efficient and Accurate Scene Text Detector (https://arxiv.org/abs/1704.03155v2)"
    "The OCR model can be obtained from converting the pretrained CRNN model to .onnx format from the github repository https://github.com/meijieru/crnn.pytorch"
    "Or you can download trained OCR model directly from https://drive.google.com/drive/folders/1cTbQ3nuZG-EKWak6emD_s8_hHXWz7lAr?usp=sharing"
)
parser.add_argument(
    "--input",
    help="Path to input image or video file. Skip this argument to capture frames from a camera.",
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
# Default threshold here is 0.9 as that seems to work best on test data so far
parser.add_argument("--thr", type=float, default=0.75, help="Confidence threshold.")
parser.add_argument(
    "--nms", type=float, default=0.4, help="Non-maximum suppression threshold."
)
args = parser.parse_args()


def fourPointsTransform(frame, vertices):
    vertices = np.asarray(vertices)
    outputSize = (100, 32)
    targetVertices = np.array(
        [
            [0, outputSize[1] - 1],
            [0, 0],
            [outputSize[0] - 1, 0],
            [outputSize[0] - 1, outputSize[1] - 1],
        ],
        dtype="float32",
    )

    rotationMatrix = cv2.getPerspectiveTransform(vertices, targetVertices)
    result = cv2.warpPerspective(frame, rotationMatrix, outputSize)
    return result


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


def read_image():
    # Read and store arguments
    confThreshold = args.thr
    nmsThreshold = args.nms
    inpWidth = args.width
    inpHeight = args.height
    modelDetector = args.model
    # modelRecognition = args.ocr

    # Load network
    detector = cv2.dnn.readNet(modelDetector)

    # Create a new named window
    # kWinName = "image-sorter"
    # cv2.namedWindow(kWinName, cv2.WINDOW_NORMAL)
    outNames = []
    outNames.append("feature_fusion/Conv_7/Sigmoid")
    outNames.append("feature_fusion/concat_3")

    tickmeter = cv2.TickMeter()

    # Open an image file
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

    # Run the detection model
    detector.setInput(blob)

    tickmeter.start()
    outs = detector.forward(outNames)
    tickmeter.stop()

    print(f"Found boxes in {tickmeter.getTimeSec()} seconds")

    # Get scores and geometry
    scores = outs[0]
    geometry = outs[1]
    [boxes, confidences] = decodeBoundingBoxes(scores, geometry, confThreshold)

    # Apply NMS
    indices = cv2.dnn.NMSBoxesRotated(boxes, confidences, confThreshold, nmsThreshold)

    out = frame.copy()

    for i in indices:
        # get 4 corners of the rotated rect
        vertices = cv2.boxPoints(boxes[i])

        # scale the bounding box coordinates based on the respective ratios
        for j in range(4):
            vertices[j][0] *= rW
            vertices[j][1] *= rH

        # Crop the detected text region
        cropped = fourPointsTransform(frame, vertices)

        ########## PREPROCESSING ##########

        gray = cv2.cvtColor(cropped, cv2.COLOR_BGR2GRAY)
        ret, thresh1 = cv2.threshold(gray, 0, 255, cv2.THRESH_OTSU | cv2.THRESH_BINARY_INV)

        for j in range(4):
            p1 = (int(vertices[j][0]), int(vertices[j][1]))
            p2 = (int(vertices[(j + 1) % 4][0]), int(vertices[(j + 1) % 4][1]))
            cv2.line(out, p1, p2, (0, 255, 0), 1)

        
    cv2.imshow(f"Processed image", out)
    cv2.waitKey()
    

def main():
    images_dir = Path("./images/test")
    files = list(images_dir.glob("*.jpg")) + list(images_dir.glob("*.JPG"))
    for file in files:
        print("Reading file: ", file)
        args.input = str(file)
        read_image()
        

if __name__ == "__main__":
    main()
