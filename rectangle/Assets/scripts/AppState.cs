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

	public appState m_appState = appState._MAIN_MENU_SELECT;

	void OnlevelWasLoaded(int level)
	{
		string debugMsg = "";
		switch (m_appState) {
				
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
