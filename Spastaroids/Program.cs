using Azimuth;
using Raylib_cs;

namespace Spasteroids
{
	public static class Program
	{
		public const int WINDOW_WIDTH = 800;
		public const int WINDOW_HEIGHT = 800;
		public const string TITLE = "Spasteroids";
		public static readonly Color bacground = Color.BLACK;
		public static void Main()
		{
			Application.Run(WINDOW_WIDTH, WINDOW_HEIGHT, TITLE, bacground, new SpasteroidsGame());
		}
	}
}