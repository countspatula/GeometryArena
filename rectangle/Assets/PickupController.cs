﻿using UnityEngine;
using System.Collections;

public class PickupController : MonoBehaviour
{

    

    public enum Type {Cannon, SpeedBoost, Chase};

    public Type PickupType;

    public int PickupTime;

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
            p1c.State = Player1Controller.PlayerState.Cannon;
            p1c.PickupTimer = Time.time+ PickupTime;
            this.renderer.enabled = false;
            this.collider2D.enabled = false;

            if (PickupType == Type.Cannon)
            {
                cg.ShotCooldown = 0.05f;
                p1c.State = Player1Controller.PlayerState.Cannon;
            }
            if (PickupType == Type.SpeedBoost)
            {
                p1c.PlayerSpeed = (p1c.PlayerSpeed * 2);
                cg.ShotCooldown = (cg.ShotCooldown * 0.5f);
                p1c.State = Player1Controller.PlayerState.SpeedBoost;
            }
            if (PickupType == Type.Chase)
            {
                p1c.PlayerSpeed = (p1c.PlayerSpeed * 2.0f);
                cg.ShotCooldown = 1000;
                p1c.State = Player1Controller.PlayerState.Chase;
            }

        }

    }
}