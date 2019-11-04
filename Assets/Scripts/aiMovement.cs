using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aiMovement : MonoBehaviour
{
    public float speed;
    public float maxWait;
    private Vector2 targetPoint;
    public float maxDistance;

    void Start()
    {
        DefineNewTargetPoint();
    }
    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPoint, Time.deltaTime * speed);

        if (Vector2.Distance(transform.position, targetPoint) < float.Epsilon)
            StartCoroutine(Wait());
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(Random.Range(0, maxWait));
        DefineNewTargetPoint();
    }

    private void DefineNewTargetPoint()
    {
        float newX = Random.Range(transform.position.x - maxDistance, transform.position.x + maxDistance);
        float newY = Random.Range(transform.position.y - maxDistance, transform.position.y + maxDistance);

        targetPoint = new Vector3(newX, 0, newY);
    }
}
