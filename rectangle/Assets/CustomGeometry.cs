using UnityEngine;
using System.Collections;

public class CustomGeometry : MonoBehaviour {


    public float ShotCooldown = 0.0f;
    public float lastshot;
    public int NumVerts = 0;
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

            }
        }
        else
        {

            Debug.Log(lastshot - Time.time);
        }

    }

    public void GenerateMesh(int p_numVerts)
    {
        
        Vector3[] verts = new Vector3[p_numVerts];
        Vector2[] uvs = new Vector2[p_numVerts];
        int[] tris = new int[(p_numVerts * 3)];
        verts[0] = Vector3.zero;
        uvs[0] = new Vector2(0.5f, 0.5f);
        float angle = 360.0f / (float)(p_numVerts - 1);

        for (int i = 1; i < p_numVerts; i++)
        {
            verts[i] = Quaternion.AngleAxis(angle * (float)(i - 1), Vector3.back) * Vector3.up;
            float normedHorizontal = (verts[i].x + 1.0f) * 0.5f;
            float normedVertical = (verts[i].y + 1.0f) * 0.5f;
            uvs[i] = new Vector2(normedHorizontal, normedVertical);

        }
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
        collider.mesh = filter.mesh;
      
    }
    void OnCollisionEnter(Collision c)
    {
        NumVerts++;
        GenerateMesh(NumVerts);

    }
	// Use this for initialization
    	void Start () {
            lastshot = Time.time;
            filter = GetComponents<MeshFilter>()[0];
            collider = GetComponent<MeshCollider>();
            filter.mesh = new Mesh();
            GenerateMesh(NumVerts);
            
	}
	
	// Update is called once per frame
	void FixedUpdate () {
    
	}
}
