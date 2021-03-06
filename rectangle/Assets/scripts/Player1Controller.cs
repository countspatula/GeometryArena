﻿using UnityEngine;
using System.Collections;

public class Player1Controller : MonoBehaviour {
    CustomGeometry geom;
    Renderer mr;
    public int player = 0;

    public float KillCount;
    public float DeathCount;
    public GameObject scoreText;
    public GameObject winText;

    float x;
    float y;

    public Texture t;

    public float PlayerSpeed = 1.0f;
    public float Zrot = 0.0f;
    public float PickupTimer = 0;
    public float SpawnTimer = 0;


    public int SpeedCount;
    public int CannonCount;
    public int ChaseCount;

    public enum PlayerState { Normal, SpeedBoost, Cannon, Chase, Invincible};

    public PlayerState State = PlayerState.Normal;

	// Use this for initialization
    void Start()
    {
        geom = GetComponent<CustomGeometry>();
        mr = this.renderer;
        this.renderer.material.SetTexture(0, t);

        switch (player)
        {
            case 1:
                
                x = 15;
                y = 0;
                break;
            case 2:
               
                x = 1200+15;
                y = 0;
                break;
            case 3:
                
                x = 15;
                y = 400;
                break;
            case 4:
                
                x = 1200+15;
                y = 400;
                break;
        }    
    }
   
	// Update is called once per frame
	void FixedUpdate ()
    {
        if (KillCount >= AppState.Instance.WinCondition)
        {
            if (AppState.Instance.g_gameState != AppState.gameState._GAMEOVER)
            {
                AppState.Instance.g_gameState = AppState.gameState._GAMEOVER;
                AppState.Instance.g_players.ClearActive();
                winText.GetComponent<TextMesh>().color = scoreText.GetComponent<TextMesh>().color;
                winText.GetComponent<TextMesh>().text = "Player " + player + " REKTS!";
                winText.transform.GetChild(0).gameObject.SetActive(true);
            }
            if (Input.GetButton("startAll") && AppState.Instance.g_gameState == AppState.gameState._GAMEOVER)
            {
                AppState.Instance.g_gameState = AppState.gameState._STARTING;
                Application.LoadLevel(0);
            }
    
        }

        PickupCheck();

        if (!(State == PlayerState.Normal) && State != PlayerState.Invincible)
        {
            CountDown();
        }

        if (State == PlayerState.Invincible)
        {
            SpawnCountDown();
        }
            if (CannonCount > 0 && Input.GetButtonDown("A" + player))
            {
                if (State == PlayerState.Invincible) return;
                CannonCount--;
                UsePickup(0);
            }

            if (SpeedCount > 0 && Input.GetButtonDown("B"  + player))
            {
                SpeedCount--;
                UsePickup(1);
            }

            if (ChaseCount > 0 && Input.GetButtonDown("Y" + player))
            {
                ChaseCount--;
                UsePickup(2);
            }
        

        if (Input.GetAxis("RightTrigger" + player) < -0.001f && !(State == PlayerState.Chase || State == PlayerState.Cannon || State == PlayerState.Invincible))
        {
            geom.shoot();
        }
        this.transform.position += new Vector3(Input.GetAxis("LeftStick" + player + "X")/20.0f, -Input.GetAxis("LeftStick" + player + "Y") / 20.0f) * PlayerSpeed;
       // this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(Input.GetAxis("RightStick" + player + "Y"), -Input.GetAxis("RightStick" + player + "X")) * Mathf.Rad2Deg));
        // shoot();
        // GenerateMesh(NumVerts);      
	}


    private void CannonMode()
    {
        geom.shoot();
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 1.0f;
    }

    private void ChaseMode()
    {
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Zrot));
        Zrot += 7.0f;
    }

    private void CountDown()
    {
        if (PickupTimer < Time.time)
        {
            ResetStats();
        }
       
    }

    private void SpawnCountDown()
    {
        if (SpawnTimer < Time.time)
        {
            gameObject.GetComponent<GhostFlash>().enabled = false;
            ResetStats();
        }
        else
        {
            gameObject.GetComponent<GhostFlash>().enabled = true;
        }
    }


    private void ResetStats()
    {
        PlayerSpeed = 1.0f;
        geom.ShotCooldown = 0.5f;
        this.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        this.State = PlayerState.Normal;
    }

    private void PickupCheck()
    {
        if (this.State == PlayerState.Cannon)
        {
            CannonMode();
        }
        if (this.State == PlayerState.Chase)
        {
            ChaseMode();
        }
    }

    private void UsePickup(int i)
    {

            if (i == 0)
            {
                geom.ShotCooldown = 0.075f;
                PickupTimer =  Time.time + 5;
                this.State = Player1Controller.PlayerState.Cannon;
               
            }
            if (i == 1)
            {
                PlayerSpeed = (PlayerSpeed * 1.5f);
                geom.ShotCooldown = 0.25f;
                PickupTimer = Time.time + 5;
                this.State = Player1Controller.PlayerState.SpeedBoost;
            }
            if (i == 2)
            {
                PlayerSpeed = (PlayerSpeed * 2.0f);
                PickupTimer = Time.time + 5;
                this.State = Player1Controller.PlayerState.Chase;
            }

        }
    }

