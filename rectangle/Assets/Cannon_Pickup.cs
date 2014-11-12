using UnityEngine;
using System.Collections;

public class Cannon_Pickup : MonoBehaviour {

    float SpawnTime = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > SpawnTime)
        {
            this.renderer.enabled = true;
            this.collider2D.enabled = true;
        }
	}
    void OnCollisionEnter2D(Collision2D c)
    {
     
        CustomGeometry cg = c.gameObject.GetComponent<CustomGeometry>();
        if (cg != null)
        {
            
            SpawnTime = Time.time + 5;
            //c.gameObject.GetComponent<Player1Controller>().State = Player1Controller.PlayerState.Cannon;
            c.gameObject.GetComponent<Player1Controller>().PickupTimer = 50;
            this.renderer.enabled = false;
            this.collider2D.enabled = false;

        }
       
    }
}
