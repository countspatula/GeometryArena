using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    CustomGeometry geom;
    public int player = 0;
    public float PlayerSpeed = 1.0f;
    public float Zrot = 0.0f;
    public int PickupTimer = 0;

    public enum PlayerState { Normal, SpeedBoost, Cannon, Chase };

    public PlayerState State = PlayerState.Normal;

	// Use this for initialization
	void Start () {
        geom = GetComponent<CustomGeometry>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        PickupCheck();


        if (Input.GetAxis("RightTrigger" + player) < -0.001f && (State == PlayerState.Normal))
        {
            geom.shoot();
        }
        this.transform.position += new Vector3(Input.GetAxis("LeftStick" + player + "X"), -Input.GetAxis("LeftStick" + player + "Y") / 20.0f) * PlayerSpeed;
       // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("RightStick" + player + "Y"), -Input.GetAxis("RightStick" + player + "X")) * Mathf.Rad2Deg));
        // shoot();
        // GenerateMesh(NumVerts);
	}



    void OnCollisionEnter2D(Collision2D c)
    {
        if (c.gameObject.tag == "P_SpeedBoost")
        {
            PlayerSpeed = 3.0f;
            geom.ShotCooldown = 0.25f;

            PickupTimer = 50;
            State = PlayerState.SpeedBoost;
        }
        if (c.gameObject.tag == "P_Chase")
        {
            PickupTimer = 50;
            State = PlayerState.Chase;
        }
        if (c.gameObject.tag == "P_Cannon")
        {
            PickupTimer = 50;
            State = PlayerState.Cannon;
        }

        GameObject.Destroy(c.gameObject);
    }

    void CannonMode()
    {
        geom.ShotCooldown = 0.0f;
        geom.shoot();
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 5.0f;
        CountDown();
    }

    void ChaseMode()
    {
        CountDown();
    }

    void SpeedMode()
    {
        CountDown();
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
        if (State == PlayerState.SpeedBoost)
        {
            SpeedMode();
        }
        if (State == PlayerState.Chase)
        {
            ChaseMode();
        }
    }
}
