using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
     void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            Ball ball = col.gameObject.GetComponent<Ball>();
            ball.die();
        }
    }   
}
