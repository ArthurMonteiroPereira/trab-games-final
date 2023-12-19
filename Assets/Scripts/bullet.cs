using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{

    public float velocidade = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.forward * velocidade * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider objetoColisao)
    {
        if(objetoColisao.gameObject.tag == "Inimigo")
            Destroy(objetoColisao.gameObject);
        Destroy(gameObject);
    }
}
