using UnityEngine;
using System.Collections;

public class playerCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(AppState.Instance.g_players.PlayerCount() < 2)
		{
			GetComponent<TextMesh> ().text = "NOT ENOUGH PLAYERS SCRUB";
			return;
		}
        GetComponent<TextMesh>().text = "Player Count " + AppState.Instance.g_players.PlayerCount();
	}
}
