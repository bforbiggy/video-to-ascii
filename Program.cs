using System.Net;
using OpenCvSharp;

Util.step = 8;

// Parse input
VideoCapture video = new VideoCapture("quaso.mp4");
double width = video.Get(3);
double height = video.Get(4);

// Prepare output
VideoWriter output = new VideoWriter("output.avi", FourCC.DIVX, video.Fps, new Size(width, height));
foreach (Mat<Vec3b> frame in Util.GetFrames(video))
{
	// Convert frame and write to output
	Mat modified = Util.ParseFrame(frame);
	output.Write(modified);
}

// Cleanup program
video.Release();
output.Release();