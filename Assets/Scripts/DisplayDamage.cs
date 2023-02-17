using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayDamage : MonoBehaviour
{

    [SerializeField] Canvas damageReceiveCanvas;
    [SerializeField] float showingDamageTime = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        damageReceiveCanvas.enabled = false;
    }

    public void ShowDamageCanvas()
    {
        StartCoroutine(ShowDamage());
    }

    IEnumerator ShowDamage()
    {
        damageReceiveCanvas.enabled = true;
        yield return new WaitForSeconds(showingDamageTime);
        damageReceiveCanvas.enabled = false;
    }
}
