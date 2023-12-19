using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class controlaJogador : MonoBehaviour
{
    public float velocidade = 10;
    public Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject textoGameOver;
    public bool vivo = true;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        float eixoX=Input.GetAxis("Horizontal");
        float eixoZ=Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        

        if (direcao!=Vector3.zero)
        {
            GetComponent<Animator>().SetBool("Movendo", true);
        }
        else
        {
            GetComponent<Animator>().SetBool("Movendo", false);
        }

        if(vivo == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                SceneManager.LoadScene("game");               
            }
        }
    }
    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Time.deltaTime * velocidade));

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100 , MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }

    }

    


}