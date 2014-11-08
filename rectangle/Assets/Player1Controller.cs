using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    CustomGeometry geom;
    Renderer mr;
    public int player = 0;

    float x;
    float y;

    public float PlayerSpeed = 1.0f;
    public float Zrot = 0.0f;
    public int PickupTimer = 0;

    public enum PlayerState { Normal, SpeedBoost, Cannon, Chase };

    public PlayerState State = PlayerState.Normal;

	// Use this for initialization
    void Start()
    {
        geom = GetComponent<CustomGeometry>();
        mr = this.renderer;

        switch (player)
        {
            case 1:
                this.renderer.material.color = Color.blue;
                x = 15;
                y = 0;
                break;
            case 2:
                this.renderer.material.color = Color.red;
                x = 1200+15;
                y = 0;
                break;
            case 3:
                this.renderer.material.color = Color.yellow;
                x = 15;
                y = 400;
                break;
            case 4:
                this.renderer.material.color = Color.green;
                x = 1200+15;
                y = 400;
                break;
        }
    
    }
   
	// Update is called once per frame
	void FixedUpdate () {

        PickupCheck();

        if (!(State == PlayerState.Normal))
        {
            CountDown();
        }

        if (Input.GetAxis("RightTrigger" + player) < -0.001f && (State == PlayerState.Normal))
        {
            geom.shoot();
        }
        this.transform.position += new Vector3(Input.GetAxis("LeftStick" + player + "X")/20.0f, -Input.GetAxis("LeftStick" + player + "Y") / 20.0f) * PlayerSpeed;
       // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("RightStick" + player + "Y"), -Input.GetAxis("RightStick" + player + "X")) * Mathf.Rad2Deg));
        // shoot();
        // GenerateMesh(NumVerts);
	}

    void OnGUI()
    {
        GUI.Box(new Rect(x, y, 200, 300), "Player " + player);
    }




    void OnCollisionEnter2D(Collision2D c)
    {     

      
    }

    void CannonMode()
    {
        geom.shoot();
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 5.0f;
    }

    void ChaseMode()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 5.0f;
    }

    private void CountDown()
    {
        if (PickupTimer < 1)
        {
            ResetStats();
        }
        PickupTimer--;
    }

    void ResetStats()
    {
        PlayerSpeed = 1.0f;
        geom.ShotCooldown = 0.5f;
        State = PlayerState.Normal;
    }

    private void PickupCheck()
    {
        if (State == PlayerState.Cannon)
        {
            CannonMode();
        }
        if (State == PlayerState.Chase)
        {
            ChaseMode();
        }
    }

}
