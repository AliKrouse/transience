using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connector : MonoBehaviour
{
    private SpriteRenderer sr;

    public List<GameObject> objectsInRadius;
    public GameObject line;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        //continuously check (maybe not every frame) for similar color
        //check if r g and b are each within a certain distance of players values
        //spawn line renderer pointing at connected player
        //line needs a script on it to destroy itself if the colors change
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("AI"))
        {
            if (!objectsInRadius.Contains(collision.gameObject))
                objectsInRadius.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("AI"))
        {
            if (objectsInRadius.Contains(collision.gameObject))
                objectsInRadius.Remove(collision.gameObject);
        }
    }
}
