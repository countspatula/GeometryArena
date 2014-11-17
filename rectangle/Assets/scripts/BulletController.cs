using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float speed = 1.0f/40.0f;
    public Transform owner;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.position += this.transform.forward * speed;
    }
    void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject == owner.gameObject) return;
        CustomGeometry g = c.gameObject.GetComponent<CustomGeometry>();
        Player1Controller p1c = c.gameObject.GetComponent<Player1Controller>();
        if (g != null)
        {
            if (p1c.State == Player1Controller.PlayerState.Invincible) return;
            if (g.NumVerts > 4)
            {
                g.NumVerts--;
                p1c.DeathCount += 1;
               
            }
            g.transform.position = g.spawners.transform.GetChild(Random.Range(0, g.spawners.transform.childCount)).position;
       
            CustomGeometry g2 = owner.GetComponent<CustomGeometry>();
            Player1Controller p1c2 = owner.GetComponent<Player1Controller>();

            p1c2.KillCount += 1;
            p1c2.scoreText.GetComponent<TextMesh>().text = "X " + p1c2.KillCount;
            
            g2.NumVerts++;

            p1c.State = Player1Controller.PlayerState.Invincible;
            p1c.SpawnTimer = Time.time + 3;
        }
        if (c.gameObject.GetComponent<BulletController>() == null) { 
        Destroy(gameObject);}
    }


}

