using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class connector : MonoBehaviour
{
    private SpriteRenderer sr;

    public List<GameObject> objectsInRadius;
    public List<GameObject> connectedObjects;
    public GameObject line;

    public int connectionScore;

    public float maxColorDifference;

    void Start()
    {
        sr = transform.parent.GetChild(0).GetComponent<SpriteRenderer>();
    }
    
    void Update()
    {
        foreach (GameObject g in objectsInRadius)
            CheckColorSimilarity(g.GetComponent<SpriteRenderer>());
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("AI"))
        {
            if (!objectsInRadius.Contains(collision.gameObject))
                objectsInRadius.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("AI"))
        {
            if (objectsInRadius.Contains(collision.gameObject))
                objectsInRadius.Remove(collision.gameObject);
        }
    }

    private void CheckColorSimilarity(SpriteRenderer other)
    {
        bool red = false;
        bool green = false;
        bool blue = false;

        if (Mathf.Abs(sr.color.r - other.color.r) < maxColorDifference)
            red = true;
        else
            red = false;

        if (Mathf.Abs(sr.color.g - other.color.g) < maxColorDifference)
            green = true;
        else
            green = false;

        if (Mathf.Abs(sr.color.b - other.color.b) < maxColorDifference)
            blue = true;
        else
            blue = false;

        if (!connectedObjects.Contains(other.gameObject))
        {
            if (red && green && blue)
                Connect(other.gameObject);
        }

        if (connectedObjects.Contains(other.gameObject))
        {
            if (!red || !green || !blue)
                Disconnect(other.gameObject);
        }
    }

    private void Connect(GameObject other)
    {
        connectedObjects.Add(other);

        GameObject lr = Instantiate(line, transform);
        lr.GetComponent<lineScript>().connectedObject = other.transform;

        TallyScore();
    }

    public void Disconnect(GameObject other)
    {
        connectedObjects.Remove(other);

        TallyScore();
    }

    private void TallyScore()
    {
        int score = 0;

        foreach (GameObject g in connectedObjects)
        {
            if (g.CompareTag("AI"))
                score += 1;
            if (g.CompareTag("Player"))
                score += 2;
        }

        connectionScore = score;
    }
}
