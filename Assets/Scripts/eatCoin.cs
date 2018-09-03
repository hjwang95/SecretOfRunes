using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatCoin : MonoBehaviour {

    // Use this for initialization
    public int pointsToadd;
    void startTrigger (Collider2D c){
        if (c.GetComponent<PlayerController>() == null)
            return;

        //add coins to the scoreboard in the future here

        Destroy(gameObject);


    }

}
