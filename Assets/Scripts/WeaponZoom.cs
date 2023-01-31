using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    Camera fpsCamera;
    [SerializeField] float zoomIn = 30f;
    [SerializeField] float zoomOut = 60f;
    [SerializeField] float zoomInSensitivity = 0.5f;
    [SerializeField] float zoomOutSensitivity = 2f;
    RigidbodyFirstPersonController playerController;
    // Start is called before the first frame update
    void Start()
    {
        fpsCamera = Camera.main;
        playerController = GetComponent<RigidbodyFirstPersonController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            fpsCamera.fieldOfView = zoomIn;
            playerController.mouseLook.XSensitivity = zoomInSensitivity;
            playerController.mouseLook.YSensitivity = zoomInSensitivity;
        } 
        else 
        {
            fpsCamera.fieldOfView = zoomOut;
            playerController.mouseLook.XSensitivity = zoomOutSensitivity;
            playerController.mouseLook.YSensitivity = zoomOutSensitivity;
        }

    }
}
