using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotacionCielo : MonoBehaviour
{
    public float velRotacion = 1.2f;
    // Update is called once per frame
    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * velRotacion);
    }
}
