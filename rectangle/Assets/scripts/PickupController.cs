using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{
    public enum Type {Cannon, SpeedBoost, Chase};
    public Type PickupType;
   // public int PickupTime;

    public float SpawnTime;

    float Timer = 0;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > Timer)
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

            Timer = Time.time + SpawnTime;
            Player1Controller p1c = c.gameObject.GetComponent<Player1Controller>();
 
            this.renderer.enabled = false;
            this.collider2D.enabled = false;

            if (PickupType == Type.Cannon)
            {
                p1c.CannonCount++;

            }
            if (PickupType == Type.SpeedBoost)
            {
                p1c.SpeedCount++;

            }
            if (PickupType == Type.Chase)
            {
                p1c.ChaseCount++;
            }

        }

    }
}