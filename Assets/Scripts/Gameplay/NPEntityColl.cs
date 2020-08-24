using Assets.Scripts.Gameplay;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPEntityColl : NPEntity
{

    const float addAltitude = 1;

    //Add points for surviving birds
    protected override void DestroyOutOfScreen()
    {
        Destroy(gameObject);
        pointsChanged.Invoke(PointsPerNPEntity);
    }

    //Lift up a bird
    protected override void OnMouseDown()
    {
        Vector3 position = transform.position;
        position += new Vector3(0, addAltitude, 0);
        transform.position = position;
    }

    //Explode colliding birds 
    protected void OnCollisionEnter2D(Collision2D collision)
    {
        Instantiate(deathAnimation, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject);
        Instantiate(deathAnimation, collision.gameObject.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        pointsChanged.Invoke(-PointsPerNPEntity);
    }
}
