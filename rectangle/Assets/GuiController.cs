using UnityEngine;
using System.Collections;

public class GuiController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnGUI()
    {
     
        GUI.HorizontalSlider(new Rect(10, 10, 100, 10), Time.time, CustomGeometry.S_last_side, CustomGeometry.S_next_side);
        Debug.Log("GUi");
    }
}
