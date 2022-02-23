using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MostrarVidas : MonoBehaviour
{
    public Image vida1;
    public Image vida2;
    public Image vida3;

    private GameManager scriptGameManager;

    // Start is called before the first frame update
    void Start()
    {
        scriptGameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (scriptGameManager.vidas == 2)
        {
            vida3.enabled = false;
            vida2.enabled = true;
        }
        
        else if (scriptGameManager.vidas == 1)
        {
            vida3.enabled = false;
            vida2.enabled = false;      
        }

        else
        {
            vida3.enabled = true;
            vida2.enabled = true;
            vida1.enabled = true;
        }
    }
}
