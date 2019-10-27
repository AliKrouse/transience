using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enforceGravity : MonoBehaviour
{
    public planetScript attractorPlanet;
    private Transform player;

    void Start()
    {
        player = transform;
    }
    
    void FixedUpdate()
    {
        if (attractorPlanet)
        {
            attractorPlanet.Attract(player);
        }
    }
}
