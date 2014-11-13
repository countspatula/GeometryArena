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
			GetComponent<TextMesh> ().text = "NOT ENOUGH PLAYERS \n press A to join";
			return;
		}
		GetComponent<TextMesh>().text =  AppState.Instance.g_players.PlayerCount() + " Players ready " + "\npress A for a " + AppState.Instance.g_players.PlayerCount() + " player game";
	}
}
