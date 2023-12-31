using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlaZumbi : MonoBehaviour
{
    public GameObject personagem;
    UnityEngine.AI.NavMeshAgent agent;
    public float velocidade = 8;
    public bool ativado ;
    public AudioSource som;

    [SerializeField] public float timer_cooldown = 20f;
    private float timer = 0f;

    private bool timer_locked_out = true;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        personagem = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        timer_cooldown = Random.Range(4, 8);
        timer = Random.Range(0,timer_cooldown);

    }

    // Update is called once per frame
    void Update()
    {
        if ( timer_locked_out == true )
        {
            timer -= Time.deltaTime;
        
            if ( timer <= 0 )
            {
                timer = timer_cooldown;
                timer_locked_out = false;
            }
        }
        if ( timer_locked_out == false )
        {
            timer_locked_out = true;
            som.Play();
            
        }
    }

    void FixedUpdate()
    {
        
        
        if(personagem != null){
           Vector3 direcao = personagem.transform.position - transform.position;
     
        

            float distancia = Vector3.Distance(personagem.transform.position, transform.position);

            if(distancia < 35){
                ativado = true;
            }
            if(ativado){
                if(distancia > 2.6)
                {
                    agent.destination = personagem.transform.position;
                    //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao.normalized * velocidade * Time.deltaTime));

                    Quaternion novaRotacao = Quaternion.LookRotation(direcao);
                    GetComponent<Rigidbody>().MoveRotation(novaRotacao);
                    GetComponent<Animator>().SetBool("atacando", false);
                }
                
                else
                {
                    agent.destination = personagem.transform.position;
                    Quaternion novaRotacao = Quaternion.LookRotation(direcao);
                    GetComponent<Rigidbody>().MoveRotation(novaRotacao);
                    GetComponent<Animator>().SetBool("atacando", true);
                } 
            }
            
        }
        
        
    }

    void atacaJogador()
    {
        if(!personagem.GetComponent<ControlaPlayer>().textoVitoria.activeSelf){
            personagem.GetComponent<ControlaPlayer>().textoGameOver.SetActive(true);
            personagem.GetComponent<ControlaPlayer>().vivo=false;
        }
        
        
        
        
        //personagem.GetComponent<controlaJogador>().vivo = false;
    }
}
 