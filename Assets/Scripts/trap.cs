using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap : MonoBehaviour
{
    public AudioSource source;
    public GameObject spawn;

    public GameObject trapp;

    bool ativo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ativaArmadilha(){
        if(!ativo){
            source.Play();
            spawn.SetActive(true);
            ativo=true;
            trapp.SetActive(false);
        }
        
    }
}
