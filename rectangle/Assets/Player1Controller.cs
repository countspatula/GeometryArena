using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    CustomGeometry geom;
    public int player = 0;
	// Use this for initialization
	void Start () {
        geom = GetComponent<CustomGeometry>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetAxis("RightTrigger" + player) < -0.001f)
        {
            geom.shoot();
        }
        this.transform.position += new Vector3(Input.GetAxis("LeftStick" + player + "X"), -Input.GetAxis("LeftStick" + player + "Y")) / 20.0f;
       // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("RightStick" + player + "Y"), -Input.GetAxis("RightStick" + player + "X")) * Mathf.Rad2Deg));
        // shoot();
        // GenerateMesh(NumVerts);
	}
}
