using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaZumbi : MonoBehaviour
{
    public GameObject personagem;
    public float velocidade = 8;

    // Start is called before the first frame update
    void Start()
    {
        personagem = GameObject.FindWithTag("Player");
        int geraTipoZumbi = Random.Range(1, 28);
        transform.GetChild(geraTipoZumbi).gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        Vector3 direcao = personagem.transform.position - transform.position;
     
        

        float distancia = Vector3.Distance(personagem.transform.position, transform.position);
        if(distancia > 2.6)
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao.normalized * velocidade * Time.deltaTime));

            Quaternion novaRotacao = Quaternion.LookRotation(direcao);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
            GetComponent<Animator>().SetBool("atacando", false);
        }
        else
        {
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
