using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powers : MonoBehaviour
{
    int turns;
    Trajectory _traj;
    GameObject _ball;
    public int power;
    private Launcher _launcher;
    private int _balls;
    bool _super;
    // Start is called before the first frame update
    void Start()
    {
        _launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Launcher>();
        _traj = GameObject.FindGameObjectWithTag("Phantom").GetComponent<Trajectory>();
        _balls = _launcher.balls;
    }

    // Update is called once per frame
    void Update()
    {

        if(_ball == null)
        {
            _ball = GameObject.FindGameObjectWithTag("ball");
        }
        if(turns >=1 && _launcher.balls != _balls)
        {
            _balls = _launcher.balls;
            turns -=1;
        }
        if(turns <= 0)
        {
            _traj.super = false;
            _super = false;
        }
        if(power ==1 && _super)
        {
            _traj.super = true;
        }
    }
    void FixedUpdate()
    {        
        if(_traj == null && _launcher.launched == false)
        {
            _traj = GameObject.FindGameObjectWithTag("Phantom").GetComponent<Trajectory>();
        }
    }

    public void Activate()
    {
        if(power ==1)
        {
            SuperGuild();
        }
        if(power ==2)
        {
            Multiball();
        }
    }

    public void SuperGuild()
    {
        turns += 4;
        _traj.super = true;
        _super = true;
    }
    public void Multiball()
    {
        GameObject obj = Instantiate(_ball,_ball.transform.position,_ball.transform.rotation);
        obj.GetComponent<Rigidbody2D>().simulated = true;
    }
}
