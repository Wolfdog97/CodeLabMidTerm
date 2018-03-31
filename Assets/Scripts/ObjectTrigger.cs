using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    public List<GameObject> objectsToTurnOn;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("???????????");

        foreach (GameObject thisObject in objectsToTurnOn)
        {
            thisObject.SetActive(true);
        }
    }
}
