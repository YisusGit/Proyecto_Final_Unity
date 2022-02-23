using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavEnemigo : MonoBehaviour
{

    NavMeshAgent agente;
    GameObject jugador;
    Animator anim;

    void Start () {

        //Busco el jugador
        jugador = GameObject.Find("Jugador");

        //Capturamos en nav mesh agent del enemigo
        agente = GetComponent<NavMeshAgent>();

        //Le doy animacion al enemigo
        anim = GetComponent<Animator>();

    }
	
    void Update () {

        //Muevo el enemigo hacia el jugador (si no lo han matado aún)
        if (jugador != null)
        {
            agente.SetDestination(jugador.transform.position);
            anim.SetInteger("Walk", 1);
        }

    }
    
}
