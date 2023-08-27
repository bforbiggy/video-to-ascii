using System.Net;
using OpenCvSharp;

Util.step = 8;
Util.font = 0.5;

VideoCapture capture = new VideoCapture(0);
Window window = new Window("Camera");

Mat<Vec3b> image = new Mat<Vec3b>();
while (capture.Read(image))
{
	Mat<Vec3b> frame = new Mat<Vec3b>(image);
	window.ShowImage(Util.ParseFrame(frame));
	Cv2.WaitKey(30); // Apparently waits for cam
}