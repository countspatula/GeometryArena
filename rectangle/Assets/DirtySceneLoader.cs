using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using System.IO;

public class DirtySceneLoader : MonoBehaviour
{

    //please only put scenes in this :(
    public Object Scene;
    public TextMesh DebugMSG;

    // Use this for initialization
    void Start()
    {
        //List<EditorBuilderSettingsScene> scenes = new List<EditorBuilderSettingsScene>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("startAll"))
        {
            string DebugMsg = "";
            if (AppState.Instance.g_players.PlayerCount() > 1)
            {

                if (AppState.Instance.g_players.PlayerCount() == 2)
                {
                    DebugMsg = "2Players";
                }
                if (AppState.Instance.g_players.PlayerCount() == 3)
                {
                    DebugMsg = "3Players";
                }
                if (AppState.Instance.g_players.PlayerCount() == 4)
                {
                    DebugMsg = "4Players";
                }
                Debug.Log("load " + Scene.name);
                Debug.Log(DebugMsg);
                AppState.Instance.g_gameState = AppState.gameState._PLAYING;
                Application.LoadLevel(Scene.name);
            }
        }

    }


    void OnMouseDown()
    {

    }

}
