using UnityEngine;
using System.Collections;

public class PlayerIn : MonoBehaviour {
	
	private bool pressed = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnMouseDown()
	{
		if(pressed == false)
		{
			AppState.Instance.PlayerCount ++;
			pressed = true;
			return;
		}

		if(pressed == true)
		{
			AppState.Instance.PlayerCount --;
			pressed = false;
			return;
		}
	}
}
