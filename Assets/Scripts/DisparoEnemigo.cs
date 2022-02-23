using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisparoEnemigo : MonoBehaviour
{
    private GameManager scriptGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();
        
        //Destruir el disparo a los 3 segundos
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Destruir si alcanza a un enemigo
        if (other.gameObject.CompareTag("Jugador"))
        {
            //Destruyo el disparo
            Destroy(gameObject);
            
            //Le resto una vida
            scriptGameManager.vidas--;
            
            //Compruebo las vidas
            scriptGameManager.GameOver();

        }
    }
}
