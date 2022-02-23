using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Final : MonoBehaviour
{
    public Text textoTiempo;
    public Text textoPuntos;
    public Text textoPinguinos;
    public Text usuario;
    private GameManager scriptGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();

        textoTiempo.text = "TIEMPO: " + formatearTiempo();
        textoPinguinos.text = "PINGÜINOS: " + scriptGameManager.pinguinosMuertos;
        textoPuntos.text = "PUNTOS: " + scriptGameManager.puntos;
        usuario.text = "USUARIO: " + scriptGameManager.nombreUsuario;
    }

    public string formatearTiempo()
    {
        string minutos = Mathf.Floor(scriptGameManager.tiempo / 60).ToString("00");
        string segundos = Mathf.Floor(scriptGameManager.tiempo % 60).ToString("00");

        return minutos + ":" + segundos;
    }
}
