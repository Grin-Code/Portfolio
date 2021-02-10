using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{

    private Vector2 _pos1 = new Vector2(4f,-4.72f);
    private Vector2 _pos2 = new Vector2(-4f,-4.72f);
    GameObject launch;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       transform.position = Vector3.Lerp (_pos1, _pos2, (Mathf.Sin(1 * Time.time) + 1.0f) / 2.0f);
    }

    public void Return()
    {
        //returns the ball
        launch = GameObject.FindGameObjectWithTag("Launcher");
        launch.GetComponent<Tricks>().FreeBall();
        launch.GetComponent<Launcher>().balls++;
    }
}
