"""
File to find the relevant region for OCR in the rowing images
"""

import os
import argparse
import cv2
import time
import pandas as pd

parser = argparse.ArgumentParser(
    description="Script for finding relevant regions in rowing images"
)
parser.add_argument(
    "--review",
    "-r",
    default="y",
    help="(y/n) Whether to review the results or to annotate images",
)
parser.add_argument(
    "--input",
    help="Relative path to directory containing images",
)
parser.add_argument(
    "--output",
    help="Text file to write the relevant regions to",
)
args = parser.parse_args()


WINDOW_NAME = "Image"

cv2.namedWindow(WINDOW_NAME, cv2.WINDOW_NORMAL)


def resize_with_aspect_ratio(image, width=None, height=None, inter=cv2.INTER_AREA):
    dim = None
    (h, w) = image.shape[:2]

    if width is None and height is None:
        return image
    if width is None:
        r = height / float(h)
        dim = (int(w * r), height)
    else:
        r = width / float(w)
        dim = (width, int(h * r))

    return cv2.resize(image, dim, interpolation=inter)


def process_image(image_path):
    bounds = []

    img = cv2.imread(image_path)

    def mouse_event(event, x, y, flags, param):
        if event == cv2.EVENT_LBUTTONDOWN:
            bounds.append(y)
            cv2.line(img, (0, y), (img.shape[1], y), (0, 255, 0), 5)
            cv2.imshow(WINDOW_NAME, img)

    cv2.resizeWindow(WINDOW_NAME, 1920, 1080)

    cv2.setMouseCallback(WINDOW_NAME, mouse_event)

    while len(bounds) < 2:
        cv2.imshow(WINDOW_NAME, img)
        key = cv2.waitKey(1)
        if key == ord("q"):
            exit()
        if key == ord("s"):
            # Skip image since no text visible
            return

    bounds.sort()

    time.sleep(0.1)

    with open(args.output, "a") as f:
        f.write(f"{image_path},{bounds[0]},{bounds[1]}\n")


def main():
    if args.review == "y":
        df = pd.read_csv(args.output, header=None)
        df.columns = ["image", "top", "bottom"]
        max_index = (df["bottom"] - df["top"]).idxmax()
        print(df.loc[max_index,:])
    else:
      for subdir, dirs, files in os.walk(args.input):
          image_list = []
          for file in files:
              if file.split(".")[-1] in ["jpg", "jpeg", "png"]:
                  image_list.append(os.path.join(subdir, file))

      for image in image_list:
          process_image(image)


if __name__ == "__main__":
    main()
