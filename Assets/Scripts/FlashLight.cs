using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    [SerializeField] float lightDecay = .1f;
    [SerializeField] float angleDecay = 1f;
    [SerializeField] float minimumAngle = 40f;

    Light _light;
    // Start is called before the first frame update
    private void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    private void Update()
    {
        DecreaseLightAngle();
        DecreaseLightIntensity();
    }

    private void DecreaseLightAngle()
    {
        if (_light.spotAngle <= minimumAngle)
        {
            return;
        }
        _light.spotAngle -= angleDecay * Time.deltaTime;
    }

    private void DecreaseLightIntensity()
    {
        _light.intensity -= lightDecay * Time.deltaTime;
    }
}
