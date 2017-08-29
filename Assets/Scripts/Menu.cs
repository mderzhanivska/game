using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public void StartGame()
	{
		Application.LoadLevel (1);
	}
	public void LoadGame()
	{

	}
	public void ExitGame()
	{
		Application.Quit();
	}
	public void MainMenu()
	{
		Application.LoadLevel (0);
	}
}
