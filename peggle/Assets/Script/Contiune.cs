using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Contiune : MonoBehaviour
{
    public Launcher launcher;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void button()
    {
        this.gameObject.SetActive(false);
        launcher.enabled = true;
    }
}
