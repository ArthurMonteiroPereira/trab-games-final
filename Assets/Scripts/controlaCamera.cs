using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaCamera : MonoBehaviour
{
    public GameObject personagem;
    Vector3 diferenca;
    // Start is called before the first frame update
    void Start()
    {
        diferenca = transform.position - personagem.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = personagem.transform.position+diferenca;
    }
}
