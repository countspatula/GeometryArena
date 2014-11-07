using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float speed = 1.0f;
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
        if (g != null)
        {
            g.NumVerts--;
            g.GenerateMesh(g.NumVerts);
            CustomGeometry g2 = owner.GetComponent<CustomGeometry>();
            g2.NumVerts++;
            g2.GenerateMesh(g2.NumVerts);
        }
        Destroy(gameObject);
    }


}

