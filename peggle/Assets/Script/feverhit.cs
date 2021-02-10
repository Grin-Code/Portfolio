using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feverhit : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("ball"))
        {
            this.transform.parent.GetComponent<Fever>().FeverScore(this.gameObject.name);
        }
    }
}
