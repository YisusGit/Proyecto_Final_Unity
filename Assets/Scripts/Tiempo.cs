using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tiempo : MonoBehaviour
{
    
    public Text textoTiempo;
    public GameObject jugador;
    private PlayerController playerController;
    private GameManager scriptGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();

        textoTiempo.text = "TIEMPO: 00:00";

        playerController = jugador.GetComponent<PlayerController>();
    }
    
    
    // Update is called once per frame
    void Update()
    {
        if (playerController.isTiempo)
        {
            textoTiempo.text = "TIEMPO: " + formatearTiempo();
        }
    }

    public string formatearTiempo()
    {
        if (playerController.isTiempo)
        {
            scriptGameManager.tiempo += Time.deltaTime;
        }

        string minutos = Mathf.Floor(scriptGameManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(scriptGameManager.tiempo % 60).ToString("00");

        return minutos + ":" + segundos;
    }
}
