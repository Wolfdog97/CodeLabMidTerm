using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbingScript : MonoBehaviour {


    public bool grabbed;

    RaycastHit2D hit;

    public float distance = 2f;
    public float grabDistance = 2f;
    public Transform holdPoint;
    public float throwForce;
    public LayerMask notGrabbed;

    public KeyCode grabButton = KeyCode.Return;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(grabButton))
        {
            Debug.Log("pressing: " + grabButton);

            if (!grabbed)
            {
                Physics2D.queriesStartInColliders = false;

                hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

                Grabbable grabbable = hit.collider.gameObject.GetComponent<Grabbable>();

                if (grabbable != null && Vector2.Distance(grabbable.gameObject.transform.position, transform.position) < grabDistance)
                {
                    grabbed = true;
                }


                //grab
            }
            else if (!Physics2D.OverlapPoint(holdPoint.position, notGrabbed))
            {
                if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
                {
                    hit.collider.gameObject.GetComponent<Rigidbody2D>().AddForce(hit.collider.gameObject.transform.right * throwForce, ForceMode2D.Force);

                    grabbed = false;
                }
            }
        }

        if (grabbed != false)
        {
            hit.collider.gameObject.transform.position = holdPoint.position;
        }
    }


    //public void grab()
    //{
    //    if (Input.GetKeyDown(grabButton))
    //    {
    //        Debug.Log("pressing: " + grabButton);

    //        if (!grabbed)
    //        {
    //            Physics2D.queriesStartInColliders = false;

    //            hit = Physics2D.Raycast(transform.position, Vector2.right * transform.localScale.x, distance);

    //            if (hit.collider != null && hit.collider.gameObject.GetComponent<Grabbable>())
    //            {
    //                grabbed = true;
    //            }

         
    //            //grab
    //        }
    //        else if (!Physics2D.OverlapPoint(holdPoint.position, notGrabbed))
    //        {
    //            grabbed = false;

    //            if (hit.collider.gameObject.GetComponent<Rigidbody2D>() != null)
    //            {
    //                hit.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(transform.localScale.x, 1);
    //            }
    //        }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;

        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * transform.localScale.x * distance);
    }
}
