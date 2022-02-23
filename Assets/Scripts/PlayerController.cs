using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Audio;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 3;
    [Range(1,10)]
    public float salto = 7;
    Animator anim;
    Rigidbody rb;
    private NavMeshAgent agente;
    private GameManager scriptGameManager;
    public bool isTiempo;
    AudioSource[] audioSources;
    AudioSource Disparo,Trampas;
    [SerializeField] private AudioSource audioMusica;
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        agente = GetComponent<NavMeshAgent>();
        audioSources = GetComponents<AudioSource>(); 
    }

    void Update()
    {
        ControllPlayer();
    }

    void ControllPlayer()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButton("Jump") && isSuelo()){
            //Aplico el movimiento vertical con la potencia de salto
            rb.velocity += Vector3.up * salto;
        }

        if (isTiempo)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                scriptGameManager.pausar();
            }
        }
    }

    private bool isSuelo()
    {

        //Genero el array de colisiones de la esfera/jugador pasando su centro y su radio
        Collider[] colisiones = Physics.OverlapSphere(transform.position, 0.5f);
        //Recorro ese array y si está colisionando con el suelo devuelvo true
        foreach (Collider colision in colisiones)
        {
            if (colision.tag == "Suelo")
            {
                return true;
            }
        }

        return false;
    }

}