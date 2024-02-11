using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private float rotatorSpeed = 45f;
    private float currRotator = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float rotatorAmount = rotatorSpeed * Time.deltaTime;

        currRotator += rotatorAmount;

        transform.Rotate(rotatorAmount, 0, 0);
    }
}
