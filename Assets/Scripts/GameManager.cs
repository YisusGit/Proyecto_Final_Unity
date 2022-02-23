using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//Objeto GameManager
	private GameObject gameManager;

	//Le ponemos la cantidad de vidas al jugador
	public int vidas = 3;
	public int puntos;
	public int pinguinosMuertos;
	//Tiempo juego 
	public float tiempo = 0.0f;
	
	//Pausar juego
	public bool isPausa;
	//LLamo a la rutina de crear enemigos
	
	public string nombreUsuario;

	void Start () {
		
		//Busco el objeto llamado GameManager
		GameObject gameManager = GameObject.Find("GameManager");

		//Le indico que no se destruya al cargar otra escena 
		DontDestroyOnLoad(gameManager);

		//Cargo la escena de inicio
		SceneManager.LoadScene("Inicio");

	}
	
	public void cambiarEscena(string nombreEscena){

		SceneManager.LoadScene(nombreEscena);
		
	}
	
	public void cambiarNombreUsuario(string nombre)
	{
		if (nombre != "")
		{
			nombreUsuario = nombre;
		}
	}

	public void pausar()
	{
		if (!isPausa)
		{
			Time.timeScale = 0;
		}

		else
		{
			Time.timeScale = 1;
		}

		isPausa = !isPausa;
		
	}
	
	public void Puntos()
	{
		puntos += 5;
	}

	public void PinguinosMuertos()
	{
		pinguinosMuertos++;
	}
	
	public void GameOver()
	{
		if (vidas == 0)
		{
			SceneManager.LoadScene("Final");
		}
	}

}
