using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestruirTiempo : MonoBehaviour
{
    private GameManager scriptGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();
        
        Destroy(this.gameObject, 4);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            //Destruyo la trampa
            Destroy(gameObject);
            
            //Le resto una vida
            scriptGameManager.vidas--;
            
            //Compruebo las vidas
            scriptGameManager.GameOver();

        }
    }
}
