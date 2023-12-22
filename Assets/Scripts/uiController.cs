using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class uiController : MonoBehaviour
{
    
    public GameObject tutorial;
    public GameObject painel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate(){
        if(Input.GetKey(KeyCode.T)){
            tutorial.SetActive(true);
            painel.SetActive(true);
        }
        else{
            tutorial.SetActive(false);
            painel.SetActive(false);
        }
    }
}
