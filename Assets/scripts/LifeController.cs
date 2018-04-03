using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{

    public bool alive;
    public float deathDeep;
    public Transform respawningZone;


    void Start()
    {
        alive = true;
    }

    void Update()
    {
        checkStatus();
        checkFalling();
    }

    public void checkStatus()
    {
        if (!alive)
        {
            //trigger death event and animations
            revive();
            transform.position = respawningZone.position;
            alive = true;
        }
    }

    public void checkFalling()
    {
        if (transform.position.y < deathDeep)
        {
            kill();
        }
    }

    public void kill()
    {
        alive = false;
    }

    public void revive()
    {
        alive = true;
    }
}