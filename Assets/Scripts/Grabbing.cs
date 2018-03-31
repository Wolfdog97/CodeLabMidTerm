using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grabbing : MonoBehaviour {
    

    GameObject grabbedObject;
    public bool grabbing;
    public float holdDistance;
    public float grabDistance = 3;
    public float smoothing;
    public float throwForce;

    public KeyCode grabButton = KeyCode.Return;



    void Start()
    {
    }

    void Update()
    {
        if (grabbing)
        {
            grab(grabbedObject);
            checkDrop();
        }
        else
        {
            pickup();
        }
    }

    void grab(GameObject obj)
    {
        if (obj != null)
        {
            obj.transform.position = Vector2.Lerp(obj.transform.position,
            transform.position + (Vector3.right * Mathf.Sign(transform.localScale.x) * holdDistance), Time.deltaTime * smoothing);
        }

    }

    void pickup()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(grabButton))
        {
            RaycastHit2D hit;

            Physics2D.queriesStartInColliders = false;

            hit = Physics2D.Raycast(transform.position, Vector2.right * Mathf.Sign(transform.localScale.x), grabDistance);
            if (hit.collider != null)
            {

                Grabbable grabbable = hit.collider.gameObject.GetComponent<Grabbable>();


                if (grabbable != null)
                {
                    grabbing = true;
                    grabbedObject = grabbable.gameObject;
                    grabbable.gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
                }
            }
        }
    }

    void checkDrop()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(grabButton))
        {
            throwObject();
        }
    }

    void throwObject()
    {
        if (grabbedObject != null)
        {
            grabbing = false;
            grabbedObject.gameObject.GetComponent<Rigidbody2D>().isKinematic = false;
            grabbedObject.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector3.right * Mathf.Sign(transform.localScale.x) * throwForce, ForceMode2D.Force);
            grabbedObject = null;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * Mathf.Sign(transform.localScale.x) * grabDistance);
    }
}
