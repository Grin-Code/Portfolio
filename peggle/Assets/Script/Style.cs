﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Style : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("die",2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void die()
    {
        Destroy(this.gameObject);
    }
}
