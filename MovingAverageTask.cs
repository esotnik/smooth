using System.Collections.Generic;

namespace yield
{
	public static class MovingAverageTask
	{
		public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
		{
            double sum = 0;
            int k = 0;
            Queue<double> queue = new Queue<double>();
            foreach (var e in data)
            {
                queue.Enqueue(e.OriginalY);
                sum += e.OriginalY;
                if (k == 0)
                    e.AvgSmoothedY = e.OriginalY;
                else
                {
                    if (queue.Count > windowWidth)
                    {
                        sum -= queue.Dequeue();
                    }
                    e.AvgSmoothedY = sum / queue.Count;
                }
                yield return e;
                k++;
            }
        }
	}
}