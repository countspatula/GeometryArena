using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour {

    public float speed = 1.0f;
    
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        this.transform.position += this.transform.forward * speed;
	}
}
