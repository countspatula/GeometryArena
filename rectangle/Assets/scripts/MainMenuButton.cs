using UnityEngine;
using System.Collections;

public class MainMenuButton:MonoBehaviour{
	public GameObject cam;
	public GameObject Target;


	// Use this for initialization
	void Start () {
		AppState.Instance.g_appState = AppState.appState._PLAYERS_SELECT;
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void OnMouseDown()
	{
		cam.GetComponent<Tweener>().target = Target;
		cam.GetComponent<Tweener>().reached = false;
	}
}
