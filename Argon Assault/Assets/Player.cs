using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [SerializeField][Tooltip("In ms^1")] float speed = 10f;
    [SerializeField] [Tooltip("In m")] float xRange = 6f;
    [SerializeField] [Tooltip("In m")] float yRange = 3f;

    [SerializeField] float positionPitchFactor = -5f;
    [SerializeField] float controlledPitchFactor = -10f;

    [SerializeField] float positionYawFactor = 1f;

    [SerializeField] float controlledRollFactor = -12f;

    float xThrow, yThrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        //Pitch depende de la posición y throw
        float pitchDueToPosition = transform.localPosition.y * positionPitchFactor;
        float pitchDueToControlThrow = yThrow * controlledPitchFactor;
        float pitch = pitchDueToPosition + pitchDueToControlThrow;

        //Yaw depende de la posición
        float yaw = transform.localPosition.x * positionYawFactor;

        //Roll depende del throw
        float roll = xThrow * controlledRollFactor;

        transform.localRotation = Quaternion.Euler(pitch, yaw, roll); //pitch, yaw, roll
    }

    private void ProcessTranslation()
    {
        //Cálculos para posición de X
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal"); //Obtengo eje horizontal
        float xOffset = xThrow * speed * Time.deltaTime;
        float rawXPos = transform.localPosition.x + xOffset;
        var clampedXPos = Mathf.Clamp(rawXPos, -xRange, xRange); //Con Mathf podemos retornar un valor validando que se encuentre entre un mínimo y máximo.

        //Cálculos para posición de Y
        yThrow = CrossPlatformInputManager.GetAxis("Vertical"); //Obtengo eje horizontal
        float yOffset = yThrow * speed * Time.deltaTime;
        float rawYPos = transform.localPosition.y + yOffset;
        var clampedYPos = Mathf.Clamp(rawYPos, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
