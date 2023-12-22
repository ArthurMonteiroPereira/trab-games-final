using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class powerup : MonoBehaviour
{
    public float upgradeCooldownMultiplicator = 0.90f;
    public float rotationSpeed = 1;

    
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.0f, rotationSpeed, 0.0f, Space.Self);
    }

 

    

}
