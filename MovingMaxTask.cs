using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace yield
{

	public static class MovingMaxTask
	{
		public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
		{
			int k = 0;
			LinkedList<double> list = new LinkedList<double>();
			foreach (var e in data)
			{
				k++;
				var OriginalY = e.OriginalY;
				for (int i = list.Count - 1; i >= 0 ; i--)
				{
					if (list.Last() < OriginalY)
						list.RemoveLast();
				}
				list.AddLast(OriginalY);
				e.MaxY = list.First();
				if (k == windowWidth)
				{
					k = 0;
					list.RemoveFirst();
					//list.Clear();
				}
				yield return e;
			}
		}
	}
}