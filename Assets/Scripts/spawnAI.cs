using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnAI : MonoBehaviour
{
    public GameObject ai;
    public Color[] colorOptions;

    public float minWait, maxWait;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (true)
        {
            GameObject newAI = Instantiate(ai, transform.position, Quaternion.identity);
            newAI.transform.GetChild(0).GetComponent<SpriteRenderer>().color = colorOptions[Random.Range(0, colorOptions.Length)];
            yield return new WaitForSeconds(Random.Range(minWait, maxWait));
        }
    }
}
