using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class heli : MonoBehaviour
{
    public GameObject personagem;
    public GameObject doctor;

    public AudioSource musicaVitoria;

    public GameObject camPrincipal;
    public GameObject camFinal;



    bool subindo = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float distancia = Vector3.Distance(personagem.transform.position, transform.position);
        float distancia2 = Vector3.Distance(doctor.transform.position, transform.position);

        

        if (distancia < 15 && distancia2 < 15){
            //Time.timeScale = 0;
            personagem.GetComponent<ControlaPlayer>().textoVitoria.SetActive(true);
            personagem.SetActive(false);
            doctor.SetActive(false);
            musicaVitoria.Play();
            subindo =  true;
            camFinal.SetActive(true);
            camPrincipal.SetActive(false);
            //personagem.GetComponent<ControlaPlayer>().vivo = false;
        }
        
    }

    void FixedUpdate(){
        Vector3 pos = new Vector3 (0,0.05f,0);
        if(subindo){
            transform.position = transform.position + pos;
            if(Input.GetButtonDown("Fire1")){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
 