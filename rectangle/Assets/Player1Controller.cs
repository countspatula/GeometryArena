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
    public float PickupTimer = 0;

    public int SpeedCount;
    public int CannonCount;
    public int ChaseCount;

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
        else 
        {
            if (CannonCount > 0 && Input.GetButtonDown("A" + player))
            {
                UsePickup(0);
            }

            if (SpeedCount > 0 && Input.GetButtonDown("B"  + player))
            {
                UsePickup(1);
            }

            if (ChaseCount > 0 && Input.GetButtonDown("Y" + player))
            {
                UsePickup(2);
            }
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
        GUI.TextField(new Rect(x + 20, y + 100, 100, 20), "Sides" + geom.NumVerts);
    }




    void OnCollisionEnter2D(Collision2D c)
    {     

      
    }

    void CannonMode()
    {
        geom.shoot();
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 1.0f;
    }

    void ChaseMode()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 5.0f;
    }

    private void CountDown()
    {
        if (PickupTimer < Time.time)
        {
            ResetStats();
        }
       
    }

    void ResetStats()
    {
        PlayerSpeed = 1.0f;
        geom.ShotCooldown = 0.5f;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
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

    void UsePickup(int i)
    {
        CustomGeometry cg = geom;

        if (cg != null)
        {
            if (i == 0)
            {
                cg.ShotCooldown = 0.0f;
                PickupTimer = 50;
                State = Player1Controller.PlayerState.Cannon;
               
            }
            if (i == 1)
            {
                PlayerSpeed = (PlayerSpeed * 2);
                cg.ShotCooldown = (cg.ShotCooldown * 0.5f);
                PickupTimer = 50;
                State = Player1Controller.PlayerState.SpeedBoost;
            }
            if (i == 2)
            {
                PlayerSpeed = (PlayerSpeed * 1.5f);
                cg.ShotCooldown = 1000;
                PickupTimer = 50;
                State = Player1Controller.PlayerState.Chase;
            }

        }
    }

}
