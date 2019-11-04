using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class transportCollider : MonoBehaviour
{
    public GameObject partneredCollider;

    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameObject player = collision.gameObject;
            Vector2 difference = new Vector2(transform.position.x - player.transform.position.x, transform.position.y - player.transform.position.y);
            player.transform.position = (Vector2)partneredCollider.transform.position + difference;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<playerMovement>().canTransport = true;
        }
    }
}
