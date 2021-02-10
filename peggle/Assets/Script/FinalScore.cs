using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FinalScore : MonoBehaviour
{
    private Text final;
    private PegManager _peg;
    // Start is called before the first frame update
    void Start()
    {
        final = this.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_peg == null)
        {
            _peg = GameObject.FindGameObjectWithTag("Launcher").GetComponent<PegManager>();
        }
        else
        {
            final.text = "Final Score: " + _peg.score.ToString("#,#");
        }
    }
}
