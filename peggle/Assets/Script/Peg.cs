using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peg : MonoBehaviour
{
    public SpriteRenderer inner;
    float r;
    float g;
    float b;
    public bool hit =false;

    static float pitch;
    
    string myTag;
    ParticleSystem ps;
    PegManager manager;
    public bool _contact = false;
    public float timer;
    private Powers _powers;


    // Start is called before the first frame update
    void Start()
    {
        myTag = this.tag;
        r =  inner.color.r;
        g =  inner.color.g;
        b =  inner.color.b;
        ps = this.gameObject.GetComponent<ParticleSystem>();
        manager = GameObject.FindGameObjectWithTag("Launcher").GetComponent<PegManager>();
        _powers = GameObject.FindGameObjectWithTag("Power").GetComponent<Powers>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_contact == true)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            timer = 0.5f;
        }
        if(timer <=0)
        {
            this.GetComponent<SpriteRenderer>().enabled = false;
            inner.enabled = false;
            this.GetComponent<Collider2D>().enabled = false;
        }
    }

    public void die()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball") && !hit)
        {
            ps.Play();
            hit = true;
            manager.hit++;
            r = r +0.4f;
            g = g +0.4f;
            b = b +0.4f;
            inner.color = new Color (r,g,b,1f);
            //activates powers
            if(this.tag =="Green")
            {
                _powers.Activate();
            }
        }
    }
    void OnCollisionStay2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            _contact = true;
        }
    }
     void OnCollisionExit2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("ball"))
        {
            _contact = false;
        }
    }
}


