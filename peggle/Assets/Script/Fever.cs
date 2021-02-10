using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fever : MonoBehaviour
{
    GameObject ball;
    public GameObject bucket;
    public PegManager pegManger;
    public UIManager uiManager;
    public GameObject Canvas;
    private Launcher _launcher;

    private bool _fever = false;


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
        uiManager = GameObject.FindGameObjectWithTag("Game Manager").GetComponentInChildren<UIManager>();
        _launcher = GameObject.FindGameObjectWithTag("Launcher").GetComponent<Launcher>();
    }

    // Update is called once per frame
    void Update()
    {
        bucket.SetActive(false);
        if(ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
        if(_fever == false)
        {
            ball.GetComponent<TrailRenderer>().emitting = true;
            _fever = true;
        }        
    }
    public void FeverScore(string hit)
    {
        pegManger.score += (_launcher.balls * 10000);
        _launcher.balls = 0;
        pegManger.score += float.Parse(hit);
        Canvas.SetActive(false);
        uiManager.OnLevelFinish();
    }
}
