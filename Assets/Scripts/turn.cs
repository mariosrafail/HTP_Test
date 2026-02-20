using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turn : MonoBehaviour
{
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player");

        gameObject.transform.localScale = new Vector2 (player.transform.localScale.x , gameObject.transform.localScale.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
