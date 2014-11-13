using UnityEngine;
using System.Collections;

public class GhostFlash : MonoBehaviour
{

    Renderer s;
    float alpha = 1.0f;
    float change = -1;
    public float timer = 0;



    // Use this for initialization
    void Start()
    {
        s = GetComponent<Renderer>();
        enabled = false;
    }

    void OnEnable()
    {
        alpha = 1.0f;
        timer = 0;
    }

    void OnDisable()
    {
        s.material.color = new Color(s.material.color.r, s.material.color.g, s.material.color.b, 1);
    }

    // Update is called once per frame
    void Update()
    {        
        timer += Time.deltaTime;

        alpha += Time.deltaTime * change;
        Color col = s.material.color;
        col.a = alpha;
        s.material.color = col;

        if (alpha < 0)
        {
            change = 2;
        }

        if (alpha > 1)
        {
            change = -2;
        }

        if (timer >= 5)
        {
            enabled = false;
        }
    }
}
