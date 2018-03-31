using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour {

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            FalseEnd();
        }

    }

    public void FalseEnd()
    {
        SceneManager.LoadScene("DeathScreen");
    }
}
