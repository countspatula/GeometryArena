using UnityEngine;
using System.Collections;

public class ShapeRenderer : MonoBehaviour {

    public int noOfVerticies = 4;
    public float lengthOfSides = 10.0f;
    LineRenderer lr;
	// Use this for initialization
	void Start () {
        lr = GetComponent<LineRenderer>();
        lr.SetVertexCount(5);
        lr.SetPosition(0, new Vector3(0, 1, 0));
        lr.SetPosition(1, new Vector3(1, 1, 0));
        lr.SetPosition(2, new Vector3(1, 0, 0));
        lr.SetPosition(3, new Vector3(0, 0, 0));
        lr.SetPosition(4, new Vector3(0, 1, 0));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
