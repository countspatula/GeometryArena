using UnityEngine;
using System.Collections;

public class AppState : Singleton<AppState> {
	//prevent Appstate being constructed anywhere
	protected AppState () {}

	public enum appState
		{
			_MAIN_MENU_SELECT,
			_PLAYERS_SELECT,
			_GAMESTATE
		}

	public enum gameState
	{
		//unchosen = first time played
		_2_PLAYER,
		_3_PLAYER,
		_4_PLAYER,
		_UNCHOSEN,
		_GAMEOVER
	}

	public int PlayerCount = 0;
	public gameState g_gameState = gameState._UNCHOSEN;
	public appState g_appState = appState._MAIN_MENU_SELECT;

	// Use this for initialization
	void Start () {
		PlayerCount = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
