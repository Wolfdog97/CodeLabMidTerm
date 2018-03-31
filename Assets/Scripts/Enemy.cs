using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public Transform Target;
    public float moveSpeed;
    public float boostSpeed;

    private GameObject Player;

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		
	} 

    void attackPlayer()
    {

    }

    void killPlayer()
    {
        Destroy(Player);
    }

    void enemyMovement()
    {

    }

}
