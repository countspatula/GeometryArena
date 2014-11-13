using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class DirtySceneLoader : MonoBehaviour {

	//please only put scenes in this :(
	public Object Scene;
	public TextMesh DebugMSG;
	
	// Use this for initialization
	void Start () {
		//List<EditorBuilderSettingsScene> scenes = new List<EditorBuilderSettingsScene>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		string DebugMsg = "";
		if (AppState.Instance.PlayerCount > 1) {

			if(AppState.Instance.PlayerCount == 2)
			{
				AppState.Instance.g_gameState = AppState.gameState._2_PLAYER;
				DebugMsg = "2Players";
			}
			if(AppState.Instance.PlayerCount == 3)
			{
				AppState.Instance.g_gameState = AppState.gameState._3_PLAYER;
				DebugMsg = "3Players";
			}
			if(AppState.Instance.PlayerCount == 4)
			{
				AppState.Instance.g_gameState = AppState.gameState._4_PLAYER;
				DebugMsg = "4Players";
			}
			Debug.Log ("load " + Scene.name);
			Debug.Log(DebugMsg);
			Application.LoadLevel (Scene.name);
			} 

	}
}
