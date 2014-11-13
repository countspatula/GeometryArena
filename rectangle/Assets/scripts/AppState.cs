using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AppState : Singleton<AppState> {
	//prevent Appstate being constructed anywhere
	protected AppState () {}

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

	public enum appState
		{
			_MAIN_MENU_SELECT,
			_PLAYERS_SELECT,
			_GAMESTATE
		}
	public enum gameState
	{
		//unchosen = first time played
		_UNSTARTED,
        _PLAYING,
		_GAMEOVER
	}

    public enum playerActivater
    {
        p1,
        p2,
        p3,
        p4
    }

    public enum PlayerState
    {
        _INACTIVE,
        _ACTIVE
    }

    [System.Serializable]
    public struct Players
    {

        public void Construct(bool p_State)
        {
            p1Active = p_State;
            p2Active = p_State;
            p3Active = p_State;
            p4Active = p_State;
        }
        //use at gameover!
        public void ClearActive()
        {
            p1Active = false;
            p2Active = false;
            p3Active = false;
            p4Active = false;
        }
        public int PlayerCount()
        {
            int playercount  = 0;
            if(p1Active == true)
            {
                playercount++;
            }
            if (p2Active == true)
            {
                playercount++;
            }
            if (p3Active == true)
            {
                playercount++;
            }
            if (p4Active == true)
            {
                playercount++;
            }
            return playercount;
        }
        public void SetActive(playerActivater p_PA)
        {
            switch (p_PA)
            {
                case playerActivater.p1:
                    p1Active = true;
                    break;
                case playerActivater.p2:
                    p2Active = true;
                    break;
                case playerActivater.p3:
                    p3Active = true;
                    break;
                case playerActivater.p4:
                    p4Active = true;
                    break;
                default:
                    break;
            }
        }
        public void SetUnactive(playerActivater p_PA)
        {
            switch (p_PA)
            {
                case playerActivater.p1:
                    p1Active = false;
                    break;
                case playerActivater.p2:
                    p2Active = false;
                    break;
                case playerActivater.p3:
                    p3Active = false;
                    break;
                case playerActivater.p4:
                    p4Active = false;
                    break;
                default:
                    break;
            }
        }
        public bool p1Active;
        public bool p2Active;
        public bool p3Active;
        public bool p4Active;
    }
    public Players g_players;
 
	//public int PlayerCount = 0;
	public gameState g_gameState = gameState._UNSTARTED;
	public appState g_appState = appState._MAIN_MENU_SELECT;

	// Use this for initialization
	void Start () {
		//PlayerCount = 0;
        g_players.Construct(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
