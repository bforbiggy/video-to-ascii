using OpenCvSharp;

public class Util
{
	public static int step = 1;
	public static double font = 0.5;

	public static IEnumerable<Mat<Vec3b>> GetFrames(VideoCapture video)
	{
		for (int i = 0; i < video.FrameCount; i++)
		{
			// Retrieve frame
			Mat<Vec3b> frame = new Mat<Vec3b>();
			if (!video.Read(frame))
				break;

			// Current Frame Logging
			Console.CursorLeft = 0;
			Console.Write("Frame: {0} / {1}", i, video.FrameCount);
			yield return frame;
		}
	}

	public static Mat ParseFrame(Mat<Vec3b> frame)
	{
		Mat modified = new Mat(frame.Height, frame.Width, frame.Type());
		Mat.Indexer<Vec3b> indexer = frame.GetGenericIndexer<Vec3b>();
		for (int y = 0; y < frame.Height; y += step)
		{
			for (int x = 0; x < frame.Width; x += step)
			{
				double average = Textify.AverageRange(indexer, y, Math.Min(y + step, frame.Height), x, Math.Min(x + step, frame.Width));
				string text = Textify.Convert(average / 256).ToString();
				Cv2.PutText(modified, text, new Point(x, y), HersheyFonts.HersheyPlain, font, Scalar.White, 1);
			}
		}

		return modified;
	}
}