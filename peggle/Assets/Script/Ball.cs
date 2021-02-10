using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool launched = false;
    Rigidbody2D rb;
    public Tricks trick;
    int oHit;
    public PegManager manager;

    static int count;
    public int countHelper; 
    private Launcher launcher;

    // Start is called before the first frame update
    void Start()
    {
        count++;
        rb = this.GetComponent<Rigidbody2D>();
        trick = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Tricks>();
        manager= GameObject.FindGameObjectWithTag("Launcher").GetComponent<PegManager>();
        launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        countHelper = count;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Bucket"))
        {
            Bucket b = col.gameObject.GetComponent<Bucket>();
            b.Return();
            die();
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("orange") && oHit < 2)
        {
            trick.SetPeg(col.gameObject,oHit);
            oHit++;
        }
        else
        {
            oHit =0;
            trick.EmptyPeg();
        }
    }

    public void die()
    {
        if(count <=1)
        {
            manager.Score();
            launcher.Reload();
        }
        count--;
        Destroy(this.gameObject);
    }

    public void SetCount()
    {
        count =0;
    }
}