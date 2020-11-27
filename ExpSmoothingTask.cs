using System.Collections.Generic;

namespace yield
{
	public static class ExpSmoothingTask
	{
		public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
		{
			int k = 0;
			double prev = 0;
			foreach (var e in data)
			{
				if (k == 0)
				{
					prev = e.OriginalY;
					e.ExpSmoothedY = prev;
					yield return e;
				}
				else
				{
					e.ExpSmoothedY = alpha * e.OriginalY + (1 - alpha) * prev;
					yield return e;
					prev = e.ExpSmoothedY;
				}
				k++;
			}
		}
	}
}