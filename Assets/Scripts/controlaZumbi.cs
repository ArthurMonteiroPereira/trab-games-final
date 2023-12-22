using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaZumbi : MonoBehaviour
{
    public GameObject personagem;
    UnityEngine.AI.NavMeshAgent agent;
    public float velocidade = 8;

    public AudioSource som;

    [SerializeField] public float timer_cooldown = 20f;
    private float timer = 0f;

    private bool timer_locked_out = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        personagem = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
        timer_cooldown = Random.Range(4, 8);
        timer = timer_cooldown;

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
        
        
        
        Vector3 direcao = personagem.transform.position - transform.position;
     
        

        float distancia = Vector3.Distance(personagem.transform.position, transform.position);
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

    void atacaJogador()
    {
        Time.timeScale = 0;
        personagem.GetComponent<controlaJogador>().textoGameOver.SetActive(true);
        personagem.GetComponent<controlaJogador>().vivo = false;
    }
}
