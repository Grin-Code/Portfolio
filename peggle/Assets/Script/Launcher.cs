using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviour
{

    float angle;
    Vector2 dir;
    Vector3 curr;
    float max = 340;
    float min = 200;
    public GameObject ball;
    public GameObject spawnBall;
    public GameObject phantom;
    public GameObject spawnPhantom;
    public Transform start;
    Vector3 prevPos;
    public bool launched = false;
    public float power = 10f;
    
    public int balls = 10;
    public Text Btext;


    // Start is called before the first frame update
    void Awake()
    {
        ball.GetComponent<Ball>().SetCount();
    }
    void Start()
    {
        prevPos = start.transform.position;
        ball.transform.parent = this.transform; 
        ball.transform.rotation = this.transform.rotation;
        phantom.transform.parent = this.transform;
        phantom.transform.rotation = this.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        //changes ball ui
        Btext.text = "Balls:" + balls;

        if(launched == false && balls != 0)
        {
            //on left mouse fire the ball
            if(Input.GetButtonDown("Fire1") == true || Input.GetButtonDown("Jump") == true)
            {
                phantom.GetComponent<Trajectory>().die();
                balls--;
                Rigidbody2D brb = ball.GetComponent<Rigidbody2D>();
                ball.transform.parent = null;
                brb.simulated = true;
                brb.AddForce(ball.transform.right * power,ForceMode2D.Impulse);
                launched = true;
            }
        }
    }
    void FixedUpdate()
    {
        //gets mouse postion and places it in to a vector 3
        dir = Input.mousePosition - Camera.main.WorldToScreenPoint(this.transform.position);
        angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        //make the launcher look at the mouse with a range
        curr = this.transform.localRotation.eulerAngles;
        curr.z = Mathf.Clamp(curr.z,min,max);
        transform.transform.localRotation = Quaternion.Euler(curr);
        
        //fires a phantom ball and destroy the old one if the angle of fire is changed 
        if(prevPos != start.transform.position && phantom != null)
        {
            //destroy the previous phantom
            phantom.GetComponent<Trajectory>().die();

            //Fire a new Pantom at new angle
            phantom = Instantiate(spawnPhantom,new Vector2(0f,2.91f),this.transform.rotation);
            phantom.transform.parent = this.transform;
            phantom.transform.localPosition = new Vector2(0.12f,0);
            phantom.name ="PhantomBall";
            Rigidbody2D phtm = phantom.GetComponent<Rigidbody2D>();
            phantom.GetComponent<Trajectory>().Simulate();
            phtm.AddForce(ball.transform.right * power, ForceMode2D.Impulse);
        }

        //fire a phantom ball is phantom is null
        if(phantom == null && launched == false)
        {
            phantom = Instantiate(spawnPhantom,new Vector2(0f,2.91f),this.transform.rotation);
            phantom.transform.parent = this.transform;
            phantom.transform.localPosition = new Vector2(0.12f,0);
            phantom.name ="PhantomBall";
            Rigidbody2D phtm = phantom.GetComponent<Rigidbody2D>();
            phantom.GetComponent<Trajectory>().Simulate();
            phtm.AddForce(ball.transform.right * power, ForceMode2D.Impulse); 
        }
        prevPos = start.transform.position;
    }


    //when ball is lost or returned
    public void Reload()
    {
        ball = Instantiate(spawnBall,new Vector2(0f,2.91f),this.transform.rotation);
        launched = false;
        ball.transform.parent = this.transform;
        ball.transform.localPosition = new Vector2(0.12f,0);
        ball.name = "ball";
    }
}
