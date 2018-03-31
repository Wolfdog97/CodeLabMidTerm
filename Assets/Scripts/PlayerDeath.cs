using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour {


    void EndGame()
    {
        SceneManager.LoadScene("DeathScreen");
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "killer")
        {
            Destroy(gameObject);
            EndGame();
        }
    }

}
