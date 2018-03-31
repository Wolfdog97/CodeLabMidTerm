using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotators : MonoBehaviour
{
    public bool isRotating;
    public float x;
    public float y;
    public float z;

    // Update is called once per frame
    void Update()
    {
        if (isRotating == true)
        {
            transform.Rotate(new Vector3(x, y, z) * Time.deltaTime);
        }
    }
}
