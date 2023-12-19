using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doctor : MonoBehaviour
{
    public GameObject personagem;
    public float raioDeSeguimento = 9;

    bool ativado = false;
    UnityEngine.AI.NavMeshAgent agent;
    public float velocidade = 8;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        personagem = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate()
    {

        float distancia = Vector3.Distance(personagem.transform.position, transform.position);


        if(ativado){
            Debug.Log("distancia: " + distancia);
            if(distancia > raioDeSeguimento || distancia < 2.1)
            {
                agent.destination = agent.transform.position;
            }

            else
            {
                agent.destination = personagem.transform.position;


            }    
        }
        else{
            if(Input.GetKey(KeyCode.E) && distancia < 10){
                ativado = true;
            }
        }
        
        
    }

    
}
