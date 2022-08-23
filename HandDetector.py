import cv2 as cv
import mediapipe as mp
import math
import numpy

class HandDetector:
    def __init__(self, mode=False, maxHands=2, detectionCon=0.7, minTrackCon=0.7):
        #Implmentation of MediaPipe hand detection
        #Globals for method ease
        #Mode true=static MUCH SLOWER
        #Max hands to detect
        #Detection confidence level
        #Minimum tracking confidence level
        self.mode = mode
        self.maxHands = maxHands
        self.detectionCon = detectionCon
        self.minTrackCon = minTrackCon
        self.mpHands = mp.solutions.hands
        self.hands = self.mpHands.Hands(static_image_mode=self.mode, max_num_hands=self.maxHands, min_detection_confidence=self.detectionCon,min_tracking_confidence=self.minTrackCon)
        self.mpDraw = mp.solutions.drawing_utils



        #Globals for fingertip detection, the program gets very sad if you don't have these
        self.fingertipIds = [4, 8, 12, 16, 20]
        self.fingers = []
        self.landmarkList = []


    #Processes images using MediaPipe
    #Constructs List of Dictionaries for each detected hand
    #Provides Landmarks, BoundingBox and Center points
    #flipType is set to True as default
    #Variable names are from flipType = False
    def findHands(self, img, draw=True, flipType=True):
        #Converts cv's BRG image to RGB DO NOT TOUCH
        imgRGB = cv.cvtColor(img, cv.COLOR_BGR2RGB)
        #MediaPipe call to find hands
        self.results = self.hands.process(imgRGB)
        allHands = []

        #From MediaPipe bootstrap
        h, w, c = img.shape
        if self.results.multi_hand_landmarks:
            for handType, handLms in zip(self.results.multi_handedness, self.results.multi_hand_landmarks):
                thisHand = {}
                thislandmarkList = []
                xList = []
                yList = []

                for id, lm in enumerate(handLms.landmark):
                    px, py, pz = int(lm.x * w), int(lm.y * h), int(lm.z * w)
                    thislandmarkList.append([px, py, pz])
                    xList.append(px)
                    yList.append(py)

                # boundingBox
                xmin, xmax = min(xList), max(xList)
                ymin, ymax = min(yList), max(yList)
                boxW, boxH = xmax - xmin, ymax - ymin
                boundingBox = xmin, ymin, boxW, boxH
                #Centering Variables
                cx, cy = boundingBox[0] + (boundingBox[2] // 2), boundingBox[1] + (boundingBox[3] // 2)
                thisHand["landmarkList"] = thislandmarkList
                thisHand["boundingBox"] = boundingBox
                thisHand["center"] = (cx, cy)
                count = 0


                #Determines whether to mirror the webcam
                #Can be useful for debugging
                if flipType:
                    if handType.classification[0].label == "Right":
                        thisHand["type"] = "Left"
                    else:
                        thisHand["type"] = "Right"
                else:
                    thisHand["type"] = handType.classification[0].label
                allHands.append(thisHand)

                # Determines whether landmark overlay is displayed on the image
                if draw:
                    self.mpDraw.draw_landmarks(img, handLms, self.mpHands.HAND_CONNECTIONS)
                    cv.rectangle(img, (boundingBox[0] - 20, boundingBox[1] - 20), (boundingBox[0] + boundingBox[2] + 20, boundingBox[1] + boundingBox[3] + 20),(0, 0, 0), 2)
                    cv.putText(img, thisHand["type"], (boundingBox[0] - 30, boundingBox[1] - 30), cv.FONT_HERSHEY_PLAIN,2, (255, 255, 255), 2)
        if draw:
            return allHands, img
        else:
            return allHands

    def fingerCounterUP(self, thisHand):
    # finds the tip land marks of hands, outputs binary list of which fingers are raised
    # TipIDs are stored in the initialization
    # Compares coordinates
        HandType = thisHand["type"]
        LandmarkList = thisHand["landmarkList"]
        if self.results.multi_hand_landmarks:
            fingers = []
            # Finds and determines thumb (id = 4) and appending the previous knuckle's landmark to fingers array
            if HandType == "Right":
                if LandmarkList[self.fingertipIds[0]][0] > LandmarkList[self.fingertipIds[0] - 1][0]:
                    fingers.append(1)
                else:
                    fingers.append(0)
            else:
                if LandmarkList[self.fingertipIds[0]][0] < LandmarkList[self.fingertipIds[0] - 1][0]:
                    fingers.append(1)
                else:
                    fingers.append(0)
            # Cycles through remaining finger ids and appends list based on tip and first knuckle absolute position
            for x in range(1, 5):
                if LandmarkList[self.fingertipIds[x]][1] < LandmarkList[self.fingertipIds[x] - 2][1]:
                    fingers.append(1)
                else:
                    fingers.append(0)
        #Returns length 5 binary array
        return fingers

    def fingerCounterDOWN(self, thisHand):
    # finds the tip land marks of hands, outputs binary list of which fingers are raised
    # reverses greater than/less than from previous method
        HandType = thisHand["type"]
        LandmarkList = thisHand["landmarkList"]
        if self.results.multi_hand_landmarks:
            fingers = []
            # Finds and determines thumb (id = 4) and appending the previous knuckle's landmark to fingers array
            if HandType == "Right":
                if LandmarkList[self.fingertipIds[0]][0] < LandmarkList[self.fingertipIds[0] - 1][0]:
                    fingers.append(1)
                else:
                    fingers.append(0)
            else:
                if LandmarkList[self.fingertipIds[0]][0] > LandmarkList[self.fingertipIds[0] - 1][0]:
                    fingers.append(1)
                else:
                    fingers.append(0)
            # Cycles through remaining finger ids and appends list based on tip and first knuckle absolute position
            for x in range(1, 5):
                if LandmarkList[self.fingertipIds[x]][1] > LandmarkList[self.fingertipIds[x] - 2][1]:
                    fingers.append(1)
                else:
                    fingers.append(0)
        # Returns length 5 binary array
        return fingers



#Begin script
capture = cv.VideoCapture(0)
handDetector = HandDetector(detectionCon=0.7, maxHands=4)

while True:
    #reads the capture returns and imgage as img and a Boolean if an image is actually there
    ret, img = capture.read()
    #sends image to HandDectector class and returns identified hands
    hands, img = handDetector.findHands(img)

    #hands is a list that contais dictionary of landmarks, bounding box, center and type
    #hands["landmarkList", "bbox", "center", "type"]
    #hands[x] is each detected hand

    if hands:
        #gets first hand detected
        hand1 = hands[0]
        landmarks = hand1["landmarkList"]
        boundingBox = hand1["boundingBox"]
        centerPoint = hand1["center"]
        handType = hand1["type"]

        #Counts how many fingers are up on hand one
        count1 = 0
        # Counts how many fingers are up on hand two
        count2 = 0
        # Counts how many fingers are down on hand one
        downCount1 = 0
        # Counts how many fingers are down on hand two
        downCount2 = 0
        #Gets arrays for hand1 both up and down
        FingerCountLup = handDetector.fingerCounterUP(hand1)
        FingerCountLdown = handDetector.fingerCounterDOWN(hand1)
        #Must declare empty arrays outside of if statement to avoid null reference
        FingerCountRdown = [0,0,0,0]
        FingerCountRup = [0,0,0,0,0]

        #Handles the second hand if it is there
        if len(hands) == 2:
            hand2 = hands[1]
            landmarks2 = hand2["landmarkList"]
            boundingBox2 = hand2["boundingBox"]
            centerPoint2 = hand2["center"]
            handType2 = hand2["type"]
            #Populates previously empty arrays, provided there's a second hand
            FingerCountRup = handDetector.fingerCounterUP(hand2)
            FingerCountRdown = handDetector.fingerCounterDOWN(hand2)
            #Counts how many 1s were returned in the array from Up counter
            for y in FingerCountRup:
                if y == 1:
                    count2 += 1
            # Counts how many 1s were returned in the array from Down counter
            for x in FingerCountRdown:
                if x == 1:
                    downCount1 += 1

        # Counts how many 1s were returned in the array from Up counter
        for x in FingerCountLup:
            if x == 1:
                count1 += 1
        # Counts how many 1s were returned in the array from Down counter
        for y in FingerCountLdown:
            if y == 1:
                downCount2 += 1

        #Debugging block

        #Shows how many finger are detected up or down
        #print("downCount2 = " + str(downCount2))
        #print("downCoun1t = " + str(downCount1))
        #print("upCount1 = " + str(count1))
        #print("upCount2 = " + str(count2))

        #Example of how to use the returned arrays to recognize gestures
        #Order of fingers is [Thumb, Pointer, Middle, Ring, Pinky]
        #L is the "left" hand on the display which is typically your right hand
        #R is the "right" hand on the display which is typically your left hand


        #elif FingerCountLup == [1, 0, 0, 0, 0]:
            #print("T")
        if FingerCountLup == [0, 1, 0, 0, 0]:
            print("D")
        elif FingerCountLup == [0, 0, 0, 0, 1]:
            print("I")
        elif FingerCountLdown == [1, 1, 0, 0, 0]:
            print("P")
        elif FingerCountLdown == [1, 1, 1, 0, 0]:
            print("Q")
        elif FingerCountLup == [0, 1, 1, 1, 0]:
            print("W")


        #print("Count1 = " + str(count1) + " Count2 =" + str(count2))


    #Calls OpenCV to display the window with (Title, Image)
    cv.imshow('Webcam', img)
    #Framerate limiter 1 = 30, if nothing is contained, framerate is uncapped
    cv.waitKey(1)


