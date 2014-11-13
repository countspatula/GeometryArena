using UnityEngine;
using System.Collections;

public class PlayerIn : MonoBehaviour {
	
	private bool pressed = false;
    public AppState.playerActivater ChosePlayer = AppState.playerActivater.p1;
    public string inPutKey;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

//        if (Input.GetButtonDown(inPutKey))
//        {
//            if (pressed == false)
//            {
//                //AppState.Instance.g_players ++;
//                AppState.Instance.g_players.SetActive(ChosePlayer);
//                renderer.material.color = Color.blue;
//                pressed = true;
//
//                //DebugActive();
//                return;
//            }
//
//            if (pressed == true)
//            {
//                //AppState.Instance.PlayerCount --;
//                AppState.Instance.g_players.SetUnactive(ChosePlayer);
//                renderer.material.color = Color.white;
//                pressed = false;
//
//                //DebugInactive();
//                return;
//            }
//        }
	}

	public void OnMouseDown()
	{
		if (pressed == false)
		{
			//AppState.Instance.g_players ++;
			AppState.Instance.g_players.SetActive(ChosePlayer);
			renderer.material.color = Color.blue;
			pressed = true;
			
			//DebugActive();
			return;
		}
		
		if (pressed == true)
		{
			//AppState.Instance.PlayerCount --;
			AppState.Instance.g_players.SetUnactive(ChosePlayer);
			renderer.material.color = Color.white;
			pressed = false;
			
			//DebugInactive();
			return;
		}
      
       // AppState.Instance.g_players.DebugMsg();
	}

    private void DebugActive()
    {
        if (AppState.Instance.g_players.p1Active == true)
        {
            Debug.Log("p1Active");
        }
        if (AppState.Instance.g_players.p2Active == true)
        {
            Debug.Log("p2Active");
        }
        if (AppState.Instance.g_players.p3Active == true)
        {
            Debug.Log("p3Active");
        }
        if (AppState.Instance.g_players.p4Active == true)
        {
            Debug.Log("p4Active");
        }
    }

    private void DebugInactive()
    {
        if (AppState.Instance.g_players.p1Active == false)
        {
            Debug.Log("p1INActive");
        }
        if (AppState.Instance.g_players.p2Active == false)
        {
            Debug.Log("p2INActive");
        }
        if (AppState.Instance.g_players.p3Active == false)
        {
            Debug.Log("p3INActive");
        }
        if (AppState.Instance.g_players.p4Active == false)
        {
            Debug.Log("p4INActive");
        }
    }
}
