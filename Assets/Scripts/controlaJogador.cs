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

    public GameObject chuva;

    // camera 1ps
    public float Sensitivity {
		get { return sensitivity; }
		set { sensitivity = value; }
	}
	[Range(0.1f, 9f)][SerializeField] float sensitivity = 2f;
	[Tooltip("Limits vertical camera rotation. Prevents the flipping that happens when rotation goes above 90.")]
	[Range(0f, 90f)][SerializeField] float yRotationLimit = 88f;

	Vector2 rotation = Vector2.zero;
	const string xAxis = "Mouse X"; //Strings in direct code generate garbage, storing and re-using them creates no garbage
	const string yAxis = "Mouse Y";
    // Start is called before the first frame update
    void Start()
    {
        //baseOrientation = transform.localRotation;  
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;


        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        float eixoX=Input.GetAxis("Horizontal");
        float eixoZ=Input.GetAxis("Vertical");
        direcao = new Vector3(eixoX, 0, eixoZ);

        //animaçoes

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
        /////////

        rotation.x += Input.GetAxis(xAxis) * sensitivity;
		rotation.y += Input.GetAxis(yAxis) * sensitivity;
		rotation.y = Mathf.Clamp(rotation.y, -yRotationLimit, yRotationLimit);
		var xQuat = Quaternion.AngleAxis(rotation.x, Vector3.up);
		var yQuat = Quaternion.AngleAxis(rotation.y, Vector3.left);

		transform.localRotation = xQuat * yQuat;

        if(Input.GetKey(KeyCode.C)){
                chuva.SetActive(false);
        }
    
    }
    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + (direcao * Time.deltaTime * velocidade));

        transform.position = transform.position + (Time.deltaTime * direcao * velocidade);

        /*Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit impacto;

        if (Physics.Raycast(raio, out impacto, 100 , MascaraChao))
        {
            Vector3 posicaoMiraJogador = impacto.point - transform.position;
            posicaoMiraJogador.y = transform.position.y;
            Quaternion novaRotacao = Quaternion.LookRotation(posicaoMiraJogador);
            GetComponent<Rigidbody>().MoveRotation(novaRotacao);
        }
        */

    }

  

    


}