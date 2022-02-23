
using UnityEngine;

public class Disparo : MonoBehaviour

{
    private GameManager scriptGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();
        
        //Destruir el disparo a los 3 segundos
        Destroy(gameObject, 3.0f);
    }

    private void OnTriggerExit(Collider other)
    {
        //Destruir si alcanza a un enemigo
        if (other.gameObject.CompareTag("Enemigo"))
        {
                        
            //Destruyo el disparo
            Destroy(gameObject);
            
            //Sumo los puntos
            scriptGameManager.Puntos();
            
            //Sumo los pinguinos muertos
            scriptGameManager.PinguinosMuertos();
            
            //Destruyo al enemigo
            Destroy(other.gameObject);

        }
        
        if(other.gameObject.CompareTag("Paredes"))
        {
            //Destruyo el disparo si choca con una pared
            Destroy(gameObject);
        }
    }
}
