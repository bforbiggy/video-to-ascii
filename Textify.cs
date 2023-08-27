using OpenCvSharp;

public class Textify
{
	public static String values = " .:-=+*#%@";

	public static char Convert(double percent)
	{
		int index = (int)(percent * values.Length);
		return values[index];
	}

	public static double AveragePixel(Vec3b color)
	{
		double total = 0 + color.Item0 + color.Item1 + color.Item2;
		return total / 3;
	}

	public static double AverageRange(Mat.Indexer<Vec3b> indexer, int yLower, int yUpper, int xLower, int xUpper)
	{
		double total = 0;
		int pixels = (yUpper - yLower) * (xUpper - xLower);
		for (int y = yLower; y < yUpper; y++)
		{
			for (int x = xLower; x < xUpper; x++)
			{
				total += AveragePixel(indexer[y, x]);
			}
		}
		return total / pixels;
	}
}