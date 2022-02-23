using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrampasController : MonoBehaviour
{
    //Objeto trampa
    public GameObject trampa;
    public Vector3 posicion;
    public int numeroTrampas;
    public float esperaInicial;
    public float esperaEntreTrampas;
    public float esperaEntreOlas;
    AudioSource[] audioSources;
    AudioSource Trampas;
    [SerializeField] private AudioSource audioMusica;
    // Start is called before the first frame update
    void Start()
    {
        		
        //Iniciamos la corutina de creacion de trampas
        StartCoroutine(crearTrampa());
        audioSources = GetComponents<AudioSource>();
        Trampas = audioSources[0];
    }
    IEnumerator crearTrampa()
    {
        //Espero un tiempo antes de crear enemigos
        yield return new WaitForSeconds(esperaInicial);

        //Bucle durante toda la vida del juego
        while (true)
        {
            //Bucle de número de trampas
            for (int i = 0; i < numeroTrampas; i++)
            {
                //Instancio el enemigo en una posición aleatoria del tablero
                Vector3 posicionTrampa = new Vector3(Random.Range(-25, 25), 30, Random.Range(-25, 25));
                Instantiate(trampa, posicionTrampa, Quaternion.identity);

                //Espero un tiempo entre la creación de cada enemigo
                yield return new WaitForSeconds(esperaEntreTrampas);
            }

            //Espero un tiempo entre oleadas de enemigos
            yield return new WaitForSeconds(esperaEntreOlas);
        }
    }
}
