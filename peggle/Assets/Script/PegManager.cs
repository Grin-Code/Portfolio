using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PegManager : MonoBehaviour
{
    public int oHit = 0;
    public int hit = 0;
    public float multi = 1;
    public float score = 0.0f;
    public float totalScore = 0;
    public float baseScore = 0;
    public Text sText;
    public Text mText;
    public Text tText;
    GameObject[] bluePegs;
    GameObject[] orangePegs;
    GameObject[] greenPegs;
    GameObject purplePeg;
    public GameObject ball;
    private GameObject _lastPeg;
    public GameObject extreamFever;

    public Text oText;
    public Text bText;
    public Text pText;

    public Purplepeg purple;
    private bool _pHit = false;
    // Start is called before the first frame update
    void Start()
    {
        totalScore = PlayerPrefs.GetFloat("TotalScore");
        bluePegs = GameObject.FindGameObjectsWithTag("blue");
        orangePegs = GameObject.FindGameObjectsWithTag("orange");
        greenPegs = GameObject.FindGameObjectsWithTag("Green");
        purplePeg = GameObject.FindGameObjectWithTag("Purple");
    }

    // Update is called once per frame
    void Update()
    {
        if(ball == null)
        {
            ball = GameObject.FindGameObjectWithTag("ball");
        }
        if(tText != null)
            tText.text = "" + totalScore.ToString("#,#");
        if(sText != null)    
            sText.text = "Score: " + score.ToString("#,#");
        if(mText != null)
            mText.text = "Multiplier: " + multi;
        if(oText != null)
            oText.text ="" + multi*100;
        if(bText != null)
            bText.text ="" + multi*10;
        if(pText != null)
            pText.text ="" + (multi*1000).ToString("#,#");
        if(oHit == 24 && _lastPeg == null)
        {
            getLast();
            Slow(_lastPeg);
        }
        if(oHit == 24 && _lastPeg.GetComponent<Peg>().hit == true)
        {
            extreamFever.SetActive(true);
        }
    }
    public void Score()
    {
        purplePeg = GameObject.FindGameObjectWithTag("Purple");
        for(int i = 0;i<bluePegs.Length;i++)
        {
            if(bluePegs[i] != null)
            {
                if(bluePegs[i].GetComponent<Peg>().hit == true)
                {
                    bluePegs[i].GetComponent<Peg>().die();
                    baseScore += (multi*10);
                }
            }
        }
        for(int i = 0;i<orangePegs.Length;i++)
        {
            if(orangePegs[i] != null)
            {
                if(orangePegs[i].GetComponent<Peg>().hit == true)
                {
                    orangePegs[i].GetComponent<Peg>().die();
                    baseScore += (multi*100);
                    oHit++;
                }
            }
        }
        for(int i = 0;i<greenPegs.Length;i++)
        {
            if(greenPegs[i] != null)
            {
                if(greenPegs[i].GetComponent<Peg>().hit == true)
                {
                    greenPegs[i].GetComponent<Peg>().die();
                    baseScore += (multi*10);
                }
            }
        }
        if(purplePeg != null)
        {
            if(purplePeg.GetComponent<Peg>().hit == true)
            {
                purplePeg.GetComponent<Peg>().die();
                baseScore += (multi*1000);
                _pHit = true;
            }
            else
            {
                _pHit = false;
            }
        }
        
        score += baseScore * hit;
        PlayerPrefs.SetFloat("TotalScore",(score + totalScore));
        totalScore += score;
        baseScore = 0;
        hit = 0;
        Multiplier();
        if(purple != null)
            purple.ReturnPurple(_pHit);
    }
    
    void Multiplier()
    {
        switch (oHit)
        {
            case 10:
                multi = 2;
                break;
            case 15:
                multi = 3;
                break;
            case 19:
                multi = 5;
                break;
            case 22:
                multi = 10;
                break;  
            default:
                break;
        }
    }
    void getLast()
    {
        for(int i = 0;i<orangePegs.Length;i++)
        {
            if(orangePegs[i] != null)
            {
                if(orangePegs[i].GetComponent<Peg>().hit == false)
                {
                    _lastPeg = orangePegs[i];
                }
            }
        }
    }
    public void Slow(GameObject lastPeg)
    {
        if(Vector2.Distance(ball.transform.position, lastPeg.transform.position) < 1)
        {
            Time.timeScale = 0.5f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}