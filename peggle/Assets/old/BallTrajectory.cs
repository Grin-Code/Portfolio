using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallTrajectory : MonoBehaviour
{
    public Transform startPoint;
    public LineRenderer sightLine;
    public Launcher launch;
    public float segmentScale = 1;
    public int segmentCount = 20;
    int bounce;

    //private Collider _hitObject;
    //public Collider hitObject {get{return _hitObject;}}
    private Collider2D _hitObject;
    public Collider2D hitObject {get{return _hitObject;}}


    void FixedUpdate()
    {
        if(launch.launched == false)
        {
            segmentScale = 1;
        }
        else
        {
            //segmentScale =0;
        }
        SimPath();  

    }

    void SimPath()
    {
        Vector2[] segment = new Vector2[segmentCount];

        segment[0] = (Vector2) startPoint.transform.position;

        Vector2 segVeloicty = launch.transform.right * launch.power * Time.deltaTime;

        _hitObject = null;

        for(int i =1; i<segmentCount; i++)
        {
            float segTime = (segVeloicty.sqrMagnitude !=0) ? segmentScale/segVeloicty.magnitude:0;

            segVeloicty = segVeloicty + Physics2D.gravity * segTime;

            //RaycastHit hit;
            RaycastHit2D hit = Physics2D.Raycast(segment[i-1], segVeloicty,2f);
            if(hit.collider != null && !hit.collider.CompareTag("ball"))
            //if(Physics.Raycast(segment[i-1], segVeloicty, out hit, segmentScale))
            {
                _hitObject = hit.collider;
                segment[i] = segment[i - 1] + segVeloicty.normalized * hit.distance;
                segVeloicty = segVeloicty - Physics2D.gravity *(segmentScale - hit.distance)/segVeloicty.magnitude;
                segVeloicty = Vector2.Reflect(segVeloicty * 0.6f, hit.normal);
            }
            else
            {
                segment[i] = segment[i-1] + segVeloicty * segTime;
            }
        }

        Color startColor = Color.red;
		Color endColor = startColor;
		startColor.a = 1;
		endColor.a = 0;
		sightLine.startColor = startColor;
        sightLine.endColor = endColor;

        sightLine.positionCount = segmentCount;
        for(int i = 0; i<segmentCount;i++)
        {
            sightLine.SetPosition(i,segment[i]);
        }
        
    }
}
