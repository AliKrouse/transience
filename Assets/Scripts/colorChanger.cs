using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChanger : MonoBehaviour
{
    private SpriteRenderer sr;
    public Color[] colors;
    private int goingToColor;
    private float lerpSpeed, waitTime;
    public float minLerp, maxLerp, minWait, maxWait;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        SwitchColor();
    }
    
    void Update()
    {
        sr.color = Color.Lerp(sr.color, colors[goingToColor], Time.deltaTime * lerpSpeed);

        waitTime -= Time.deltaTime;
        if (waitTime <= 0)
            SwitchColor();
    }

    void SwitchColor()
    {
        goingToColor = Random.Range(0, colors.Length);
        lerpSpeed = Random.Range(minLerp, maxLerp);
        waitTime = Random.Range(minWait, maxWait);
    }
}
