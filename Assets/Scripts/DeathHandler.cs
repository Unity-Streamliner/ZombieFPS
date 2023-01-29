using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] Canvas menu;

    void Start()
    {
        Time.timeScale = 1;
        menu.enabled = false;
    }

    public void ShowMenu()
    {
        menu.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
