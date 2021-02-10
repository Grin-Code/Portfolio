using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tricks : MonoBehaviour
{

    public GameObject leftWall;
    public GameObject rightWall;
    float longDistance = 0;
    float distance = 0;
    public PegManager manager;
    GameObject[] peg = new GameObject[2];
    public bool returned;
    public GameObject ps;
    public Text style;
    GameObject ball;
    GameObject bucket;
    // Start is called before the first frame update
    void Start()
    {  
        //distance between the walls
        longDistance = Vector2.Distance(leftWall.transform.position,rightWall.transform.position);
        bucket = GameObject.FindGameObjectWithTag("Bucket");
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
        if(peg[0] !=null && peg[1] != null)
        {
            distance = Mathf.Abs(peg[0].transform.position.x - peg[1].transform.position.x);
        }
        //Long Shot:compare the distance of the first orange peg hit to the second orange peg hit if greater than a 1/3 of the map
        if(distance >= (longDistance*(1f/3f)) && distance < (longDistance*(2f/3f)))
        {
            Instantiate(ps,ball.transform.position,Quaternion.identity);
            style.text = "Long Shot +25,000";
            manager.score += 25000;
            peg[0] = null;
            peg[1] = null;
            distance =0;
        }
        //Super long Shot: "" 2/3 ""
        if(distance >= (longDistance*(2f/3f)))
        {
            Instantiate(ps,ball.transform.position,Quaternion.identity);
            manager.score += 50000;
            style.text = "super Long Shot +50,000";
            peg[0] = null;
            peg[1] = null;
            distance =0;
        }
        
    }
    public void SetPeg(GameObject temp, int i)
    {
        peg[i] = temp;
    }
    public void EmptyPeg()
    {
        for(int i = 0; i <peg.Length;i++)
        {
            peg[i] = null;
        }
    }

    public void FreeBall()
    {
        //FreeBallSkill: lands in the bucket after one peg
        if(manager.hit == 1)
        {
            Instantiate(ps,bucket.transform.position,Quaternion.identity);
            style.text = "free ball skills +5,000";
            manager.score += 5000;
        }
    }
}
