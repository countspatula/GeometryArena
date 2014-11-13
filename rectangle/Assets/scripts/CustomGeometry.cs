using UnityEngine;
using System.Collections;

public class CustomGeometry : MonoBehaviour {

    public GameObject spawners;
    public static float S_last_side;
    public static float S_next_side;
    public float ShotCooldown = 0.0f;
    public float SideSpawnCooldown = 3;
    float lastSideSpawn;
    public float lastshot;

    public float size = 0.15f;
    private int numVerts = 3;

    public int NumVerts
    {
        get { return numVerts; }
        set
        {
            numVerts = value;
            if (numVerts < 4)
            {
                numVerts = 3;
               //remove layer
            }
            if (numVerts > 8)
            {
                numVerts = 8;
                //add layer

            }
            GenerateMesh(numVerts, size);
        }
    }
    
    public GameObject bullet;
    public MeshCollider collider;
    public MeshFilter filter;
    public void shoot()
    {
        if (lastshot < Time.time)
        {
            lastshot = Time.time + ShotCooldown;
            for (int i = 1; i < filter.mesh.vertexCount; i++)
            {
                GameObject go = (GameObject)Instantiate(bullet, this.transform.position, Quaternion.identity);
                go.transform.forward = this.transform.rotation * filter.mesh.vertices[i];
                go.GetComponent<BulletController>().owner = transform;
                go.renderer.material = this.renderer.material;
            }
        }
        

    }

    public void GenerateMesh(int p_numVerts, float scale)
    {
        filter.mesh = null;
      
        Vector3[] verts = new Vector3[p_numVerts];
        Vector2[] uvs = new Vector2[p_numVerts];
        int[] tris = new int[(p_numVerts * 3)];
        verts[0] = Vector3.zero;
        uvs[0] = new Vector2(0.5f, 0.5f);
        float angle = 360.0f / (float)(p_numVerts - 1);
        for (int i = 1; i < p_numVerts; i++)
        {
            
            verts[i] = Quaternion.AngleAxis(angle * (float)(i - 1), Vector3.back) * Vector3.up * (scale);
            float normedHorizontal = (verts[i].x + 1.0f) * 0.5f;
            float normedVertical = (verts[i].y + 1.0f) * 0.5f;
            uvs[i] = new Vector2(normedHorizontal, normedVertical);

        }
        this.GetComponent<CircleCollider2D>().radius = scale;
        for (int i = 0; i + 2 < p_numVerts; i++)
        {
            int index = i * 3;
            tris[index] = 0;
            tris[index + 1] = i + 1;
            tris[index + 2] = i + 2;

        }
        int lastTri = tris.Length - 3;
        tris[lastTri] = 0;
        tris[lastTri + 1] = p_numVerts - 1;
        tris[lastTri + 2] = 1;

        filter.mesh.vertices = verts;
        filter.mesh.uv = uvs;
        filter.mesh.triangles = tris;
      
      
    }
    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.GetComponent<Player1Controller>() != null)
        {
            Player1Controller p1c = c.gameObject.GetComponent<Player1Controller>();
            if (p1c.State == Player1Controller.PlayerState.Chase)
            {
                
                CustomGeometry g = this.GetComponent<CustomGeometry>();
                Player1Controller p1c2 = g.gameObject.GetComponent<Player1Controller>();
                if (g != null)
                {
                    if (g.NumVerts > 4)
                    {
                        g.NumVerts--;
                        p1c2.DeathCount += 1;
                       
                    }
                    g.transform.position = g.spawners.transform.GetChild(Random.Range(0, g.spawners.transform.childCount)).position;

                    CustomGeometry g2 = c.gameObject.GetComponent<CustomGeometry>();
                    

                    g2.NumVerts++;
                    p1c.KillCount += 1;
                  
                }
            }
        }
        if (c.transform.GetComponent<BulletController>()== null) return;
        if (c.transform.GetComponent<BulletController>().owner != transform&&c.transform.GetComponent<BulletController>().owner != null)
        {

            NumVerts--;
          
            CustomGeometry cg = c.transform.GetComponent<BulletController>().owner.GetComponent<CustomGeometry>();
            cg.NumVerts++;
           
            Destroy(c.transform.gameObject);
            transform.position = spawners.transform.GetChild(Random.Range(0, spawners.transform.childCount)).position;
           // Debug.Log("FRE");
        }

    }
	// Use this for initialization
    	void Start () {
            lastshot = Time.time;
            lastSideSpawn = 0;
            filter = GetComponents<MeshFilter>()[0];
            collider = GetComponent<MeshCollider>();
            filter.mesh = new Mesh();
            GenerateMesh(NumVerts, size);
           // collider.sharedMesh = filter.mesh;
            
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (lastSideSpawn < Time.time)
        {
            S_last_side = lastSideSpawn;
            lastSideSpawn = Time.time+ SideSpawnCooldown;

            S_next_side = lastSideSpawn;
            NumVerts++;
           

        }
	}
}
