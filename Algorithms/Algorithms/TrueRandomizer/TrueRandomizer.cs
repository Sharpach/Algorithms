using System;
using System.Net;

namespace Algorithms.TrueRandomizer
{
    public class Program
    {
		public int RandomNumber;

		protected static int GetRandomNumber(int min, int max) {
			string uri = $"https://www.random.org/integers/?num=1&min={min}&max={max}&col=1&base=10&format=plain&rnd=new";         
			WebClient client = new WebClient();
			var content = client.DownloadString(uri);
			int randomNumber = Int32.Parse(content);
			return randomNumber;

		}

		public Program(int min, int max) {
			RandomNumber = GetRandomNumber(min, max);
		}
    }
}
