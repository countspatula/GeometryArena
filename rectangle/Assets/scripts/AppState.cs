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
		_UNCHOSEN,
		_2_PLAYERGAME,
		_3_PLAYERGAME,
		_4_PLAYERGAME,
		_GAMEOVER
	}
	public gameState g_gameState = gameState._UNCHOSEN;
	public appState g_appState = appState._MAIN_MENU_SELECT;

	void OnlevelWasLoaded(int level)
	{
		string debugMsg = "";
		switch (g_appState) {
				
		case appState._GAMESTATE:
			debugMsg = "_GAMESTATE";
			break;

		case appState._MAIN_MENU_SELECT:
			debugMsg = "_MAIN_MENU_SELECT";
			break;

		case appState._PLAYERS_SELECT:
			debugMsg = "_PLAYERS_SELECT";
			break;
		
	
		default:
			debugMsg = "something beyond horror has happened";
				break;
		}
		Debug.Log ("scene " + level + "loaded /n Game state: " + debugMsg );
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
