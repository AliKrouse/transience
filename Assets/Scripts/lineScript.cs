using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lineScript : MonoBehaviour
{
    private LineRenderer lr;

    public Transform connectedObject;
    private float maxDistance;

    void Start()
    {
        lr = GetComponent<LineRenderer>();

        maxDistance = GetComponentInParent<CircleCollider2D>().radius;
    }
    
    void Update()
    {
        lr.SetPosition(0, transform.parent.position);
        lr.SetPosition(1, connectedObject.position);

        if (Vector2.Distance(transform.position, connectedObject.position) > maxDistance)
        {
            GetComponentInParent<connector>().Disconnect(connectedObject.gameObject);
            Destroy(gameObject);
        }
        
        lr.startColor = transform.parent.parent.GetComponent<SpriteRenderer>().color;
        lr.endColor = connectedObject.GetComponent<SpriteRenderer>().color;

        if (!GetComponentInParent<connector>().connectedObjects.Contains(connectedObject.gameObject))
            Destroy(gameObject);
    }
}
