using System;
using System.Globalization;
using OpenCvSharp;
using OpenCvSharp.Extensions; 
using OpenCvSharp.Dnn;
using OpenCvSharp.Tracking
using OpenCvSharp.Internal
using OpenCvSharp.Face
using OpenCvSharp.Aruco

namespace API_Docs
{
    public class MainCamera
    {
        static void Main(string[] args)
        {
            using (VideoCapture capture = new VideoCapture(0))
            {
                if (!capture.IsOpened())
                {
                    Console.WriteLine("Could not open camera.");
                    return;
                }

                //set resolution
                capture.Set(VideoCaptureProperties.FrameWidth, 640);
                capture.Set(VideoCaptureProperties.FrameHeight, 480);

                using (Mat frame = new Mat())
                using (Window windowOriginal = new Window("Camera Feed"))
                using (Window windowEdges = new Window("Edges"))
                {
                    Console.WriteLine("Press ESC to exit.");

                    while (true)
                    {
                        capture.Read(frame);

                        if (frame.Empty())
                        {
                            Console.WriteLine("Blank frame grabbed, skipping.");
                            continue;
                        }

                        //grayscale
                        using (Mat gray = new Mat())
                        using (Mat blurred = new Mat())
                        using (Mat edges = new Mat())
                        {
                            Cv2.CvtColor(frame, gray, ColorConversionCodes.BGR2GRAY);
                            Cv2.GaussianBlur(gray, blurred, new Size(5, 5), 0);
                            Cv2.Canny(blurred, edges, 50, 150);

                            windowOriginal.ShowImage(frame);
                            windowEdges.ShowImage(edges);
                        }

                        //Exit on ESC k
                        int key = Cv2.WaitKey(1);
                        if (key == 27) break;
                    }
                }
            }

            Console.WriteLine("Done.");
        }
    }
}
