using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    public TrailRenderer trail;
    public Rigidbody2D rb;
    public int bounces;
    public bool super = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(bounces >= 1 && !super)
        {
            rb.simulated = false;
            this.GetComponent<Collider2D>().isTrigger = true;
        }
        if(bounces >=2 && super)
        {
            rb.simulated = false;
            this.GetComponent<Collider2D>().isTrigger = true;
        }
    }

    public void Simulate()
    {
        if(bounces <1)
        {
            rb.simulated = true;
        }
    }

    public void Trail()
    {
        trail.time = 0;
    }
    public void die()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        bounces++;
        if(col.gameObject.CompareTag("bottom"))
        {
            rb.simulated = false;
            this.GetComponent<Collider2D>().isTrigger = true;
        }
    }
}
