using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarPuntos : MonoBehaviour
{
    public Text textoPuntos;
    public Text textoPinguinos;
    private GameManager scriptGameManager;

    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();

        textoPuntos.text = "PUNTOS: 0";
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptGameManager.puntos != 0)
        {
            textoPuntos.text = "PUNTOS: " + scriptGameManager.puntos;
        }

        if (scriptGameManager.pinguinosMuertos != 0)
        {
            textoPinguinos.text = "PINGÜINOS: " + scriptGameManager.pinguinosMuertos;
        }
    }
}
