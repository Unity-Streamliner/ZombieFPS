using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    Camera fpsCamera;
    [SerializeField] float zoomIn = 30f;
    [SerializeField] float zoomOut = 60f;
    // Start is called before the first frame update
    void Start()
    {
        fpsCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            fpsCamera.fieldOfView = zoomIn;
        } 
        else 
        {
            fpsCamera.fieldOfView = zoomOut;
        }

    }
}
