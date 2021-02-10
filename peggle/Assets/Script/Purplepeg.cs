using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purplepeg : MonoBehaviour
{
    GameObject[] _blue;
    int random;
    private GameObject _currPurple;
    public GameObject purplePreb;
    public GameObject sqrPurplePreb;
    private GameObject _purple;

    // Start is called before the first frame update
    void Start()
    {
        SetPurple();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetPurple()
    {
        _blue = GameObject.FindGameObjectsWithTag("blue"); 
        random = Random.Range(0,_blue.Length);
        _currPurple = _blue[random];
        if(_currPurple == null)
        {
            SetPurple();
        }
        if(_currPurple.name != "Blue square peg")
        {
            _purple = Instantiate(purplePreb,_currPurple.transform.position,_currPurple.transform.rotation);
            if(_currPurple.transform.parent.name == "Spin")
            {
                _purple.transform.parent = _currPurple.transform.parent;
            }
        }
        else
        {
            _purple = Instantiate(sqrPurplePreb,_currPurple.transform.position,_currPurple.transform.rotation);
            if(_currPurple.transform.parent.name == "Spin")
            {
                _purple.transform.parent = _currPurple.transform.parent;
            }
        }
        _currPurple.SetActive(false);
    }
    public void ReturnPurple(bool hit)
    {
        if(hit == false)
        {
            //moves the location of the purple peg
            _currPurple.SetActive(true);
            Destroy(_purple);
            SetPurple();
        }
        else
        {
            //replacing the purple peg if it was hit
            _currPurple.SetActive(true);
            _currPurple.GetComponent<Peg>().die();
            SetPurple();
        }
    }
}
