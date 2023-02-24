using Azimuth;
using Azimuth.GameStates;
using Raylib_cs;
using Spasteroids.GameStates;
using Spasteroids.UI;

namespace Spasteroids
{
	public class SpasteroidsGame : Game
	{
		public override void Load()
		{
			Raylib.InitAudioDevice();
			GameStateManager.AddState(new MainMenuState());
			GameStateManager.AddState(new PlayState());
			
			GameStateManager.ActivateStates("Main Menu");
		}

		public override void Unload()
		{
			Raylib.CloseAudioDevice();
		}
	}
}