using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public KeyCode upKey = KeyCode.W;
    public KeyCode rightKey = KeyCode.D;
    public KeyCode downKey = KeyCode.S;
    public KeyCode leftKey = KeyCode.A;
    public KeyCode eatKey = KeyCode.Return;

    public float moveSpeed = 10f;
    public bool isHungery = true;

    private GameObject darkness;
    
    Rigidbody2D _body;

    // Use this for initialization
    void Start () {
        _body = GetComponent<Rigidbody2D>();

        darkness = GameObject.FindGameObjectWithTag("Darkness");
    }
	
	// Update is called once per frame
	void Update () {

        Vector2 newVelocity = new Vector2(0, 0);

        if (Input.GetKey(upKey))
        {
            newVelocity.y += moveSpeed;
            Debug.Log("Going up");
        }
        if (Input.GetKey(rightKey))
        {
            newVelocity.x += moveSpeed;
            Debug.Log("Going right");
        }
        if (Input.GetKey(downKey))
        {
            newVelocity.y -= moveSpeed;
            Debug.Log("Going down");
        }
        if (Input.GetKey(leftKey))
        {
            newVelocity.x -= moveSpeed;
            Debug.Log("Going left");
        }

        // Make sure the velocity always has the same magnitude
        newVelocity = newVelocity.normalized * moveSpeed;

        _body.velocity = newVelocity;

        //Debug.Log(darkness.transform.position);

    }

    void hunger()
    {
        if(isHungery == true)
        {

        }
    }

    void eating()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Overlapping");

        if((collision.gameObject == darkness))
        {
            Debug.Log("overlapping darkness");

            if (Input.GetKey(eatKey))
            {
                Destroy(collision.gameObject);
            }

        }
        
    }
}
