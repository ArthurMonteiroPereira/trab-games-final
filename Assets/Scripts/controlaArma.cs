using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlaArma : MonoBehaviour
{
    [SerializeField] public float timer_cooldown = 5f;
    private float timer = 0f;
    private bool timer_locked_out = false;
    public GameObject bullet;
    public GameObject canoArma;

    public bool medkit = false;
    public GameObject inst1;

    public GameObject inst2;

    public AudioSource plin;

    public AudioSource tiro;
    // Start is called before the first frame update
    void Start()
    {
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
                
                // a delayed action could be called from here
                // once the lock-out period expires
            }
        }
        if ( timer_locked_out == false )
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                timer_locked_out = true;
                tiro.Play();
                Instantiate(bullet, canoArma.transform.position, transform.rotation);
            }
            
        }

        if(medkit){
            inst1.SetActive(false);
            inst2.SetActive(true);
        }
        else{
            inst1.SetActive(true);
            inst2.SetActive(false);
        }
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PowerUP"){
            timer_cooldown = timer_cooldown * other.gameObject.GetComponent<powerup>().upgradeCooldownMultiplicator;
            plin.Play();
            Destroy(other.gameObject);

        }

        if (other.tag == "medkit"){
            medkit = true;
            plin.Play();
            Destroy(other.gameObject);

        }

        if (other.tag == "trap"){
            other.gameObject.GetComponent<trap>().ativaArmadilha();
        }

    }
}
