using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //Obtengo eje horizontal
        print(horizontalThrow); //Imprimo la inclinación del axis Horizontal, para saber si el player está moviendo a la izquierda o derecha.

    }
}
