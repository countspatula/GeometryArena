using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class DirtySceneLoader : MonoBehaviour {

	//please only put scenes in this :(
	public Object Scene;

	
	// Use this for initialization
	void Start () {
		//List<EditorBuilderSettingsScene> scenes = new List<EditorBuilderSettingsScene>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnMouseDown()
	{
		Debug.Log ("load " + Scene.name);
		Application.LoadLevel(Scene.name);
	}
}
