using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;

namespace ContourDetection

{
    class Program
    {
        static void Main(string[] args)
        {

            Mat image = Cv2.ImRead(@"C:\Users\Laptop\Desktop\8.png");


            Point[][] contours = GetAllContours(image);
            Mat imageClone = image.Clone();
            Cv2.DrawContours(imageClone, contours, -1, new Scalar(250, 0, 0), thickness: 1);
            Cv2.ImShow("Contours", imageClone);
            Cv2.ImShow("Original", image);
            string outputImagePath = @"C:\Users\Laptop\Desktop\krawedzie\12.png";
            Cv2.ImWrite(outputImagePath, imageClone);
            Cv2.WaitKey();


        }
        static Point[][] GetAllContours(Mat img)
        {
            Mat refGray = new Mat();
            Cv2.CvtColor(img, refGray, ColorConversionCodes.BGR2GRAY);
            Mat thresh = new Mat();
            Cv2.Threshold(refGray, thresh, 127, 255, ThresholdTypes.Binary);
            Point[][] contours;
            HierarchyIndex[] hIndx;
            Cv2.FindContours(thresh, out contours, out hIndx, RetrievalModes.List, ContourApproximationModes.ApproxSimple);

            return contours;


        }
    }

}