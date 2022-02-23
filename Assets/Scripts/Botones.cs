using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Botones : MonoBehaviour
{
    //Objeto Game Manager
    private GameManager gameManager;

    //Botones
    public Button botonPausa, botonReinicio;
    [SerializeField] private InputField inputUsuario, inputContra;
    // Start is called before the first frame update
    void Start()
    {
        //Busco mi objeto Game Manager
        gameManager = FindObjectOfType<GameManager>();
        
        if (botonPausa)
        {
            botonPausa.GetComponent<Button>().onClick.AddListener((() => gameManager.pausar()));
        }

        if (botonReinicio)
        {
            gameManager.puntos = 0;
            gameManager.vidas = 3;
            gameManager.tiempo = 0;
            gameManager.pinguinosMuertos = 0;
            SceneManager.LoadScene("Final");
        }
    }
}
