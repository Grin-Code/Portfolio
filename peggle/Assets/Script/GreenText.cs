using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GreenText : MonoBehaviour
{
    ParticleSystem _ps;
    public Text power;
    public Powers powers;

    private Peg _peg;
    private bool _play = false;
    // Start is called before the first frame update
    void Start()
    {
        if(powers.power ==1)
        {
            power.text = "SuperGuide Next 3 Turns";
        }
        if(powers.power == 2)
        {
            power.text = "MULTIBALL!!!";
        }
        _peg = transform.parent.GetComponent<Peg>();
        _ps = this.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_peg.hit == true && !_play)
        {
            _ps.Play();
            _play = true;
        }
    }
}
