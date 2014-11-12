using UnityEngine;
using System.Collections;

public class MainMenuButton : MenuItem {

	// Use this for initialization
	void Start () {
		if (GetComponent<Tweener>() != null) {
			GetComponent<Tweener>().enabled = false;
		}
		else 
		{
			gameObject.AddComponent<Tweener>();
		}
		//when it has reached the target add the layer of buttons
		gameObject.GetComponent<Tweener> ().ReachedTarget += AddNextLayerOfButtons;
	}

	public void AddNextLayerOfButtons()
	{
		//addbuttons here
		Debug.Log ("add player option buttons");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public override void Entering()
	{

	}

	public override void Exiting()
	{
		GetComponent<Tweener> ().enabled = true;
	}

	public void OnMouseDown()
	{
		Exiting ();
	}
}
