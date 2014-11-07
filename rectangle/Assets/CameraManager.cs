using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

    public GameObject Camera1;
    public GameObject Camera2;
    public GameObject Camera3;
    public GameObject Camera4;

    GameObject Player1;
    GameObject Player2;
    GameObject Player3;
    GameObject Player4;


	// Use this for initialization
	void Start () {
        SetPlayers(4);
        Player1 = GameObject.Find("Player1");
        Player2 = GameObject.Find("Player2");
        if (Player2 == null)
        {
            Player2 = Player1;
        }

        Player4 = GameObject.Find("Player4");
        if (Player4 == null)
        {
            Player4 = Player1;
            SetPlayers(3);
        }
        

        Player3 = GameObject.Find("Player3");
        if (Player3 == null)
        {
            Player3 = Player1;
            SetPlayers(2);
        }

        
    }
	
	// Update is called once per frame
	void LateUpdate () {

        if (Input.GetKeyDown("2"))
        {
            SetPlayers(2);
        }
        if (Input.GetKeyDown("3"))
        {
            SetPlayers(3);
        }
        if (Input.GetKeyDown("4"))
        {
            SetPlayers(4);
        }

        Camera1.transform.position = new Vector3(Player1.transform.position.x, Player1.transform.position.y, Camera1.transform.position.z);
        Camera2.transform.position = new Vector3(Player2.transform.position.x, Player2.transform.position.y, Camera2.transform.position.z);
        Camera3.transform.position = new Vector3(Player3.transform.position.x, Player3.transform.position.y, Camera3.transform.position.z);
        Camera4.transform.position = new Vector3(Player4.transform.position.x, Player4.transform.position.y, Camera4.transform.position.z);

	}

    void SetPlayers(int Players)
    {
        if (Players == 2)
        {
            Camera1.camera.rect = new Rect(0, 0.5f, 1, 0.5f);
            Camera2.camera.rect = new Rect(0, 0, 1, 0.5f);
            Camera4.camera.rect = new Rect(0, 0, 0, 0);
            Camera4.camera.rect = new Rect(0, 0, 0, 0);
        }
        if (Players == 3)
        {
            Camera1.camera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            Camera2.camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            Camera3.camera.rect = new Rect(0, 0, 1, 0.5f);
            Camera4.camera.rect = new Rect(0, 0, 0, 0);
        }
        if (Players == 4)
        {
            Camera1.camera.rect = new Rect(0, 0.5f, 0.5f, 0.5f);
            Camera2.camera.rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
            Camera3.camera.rect = new Rect(0, 0, 0.5f, 0.5f);
            Camera4.camera.rect = new Rect(0.5f, 0, 0.5f, 0.5f);
        }
    }
}
