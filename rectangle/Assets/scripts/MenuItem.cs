using UnityEngine;
using System.Collections;

public class MenuItem : MonoBehaviour {

//	// Use this for initialization
//	void Start () {
//	
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//	}

	public MenuItem()
	{
		m_buttonState = ButtonState._ENTERING;
	}

	public enum ButtonState
		{
			_ENTERING,
			_IDLE,
			_EXITING
		}
	public ButtonState m_buttonState;

	//turn into events?
	public virtual void Entering()
	{
		//animations logic ETC
		//make sure to turn to idle after
	}

	public virtual void Exiting()
	{
		//exit put in logic etc
	}
}
