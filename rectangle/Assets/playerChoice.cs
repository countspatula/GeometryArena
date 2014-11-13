using UnityEngine;
using System.Collections;

public class playerChoice : MonoBehaviour {

	// Use this for initialization
	void Start () {
		AppState.Instance.g_appState = AppState.appState._PLAYERS_SELECT;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
