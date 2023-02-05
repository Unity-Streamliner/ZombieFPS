using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    [SerializeField] List<AmmoSlot> ammoSlots = new List<AmmoSlot>();

    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoType type;
        public int amount;
    }

    public int GetCurrentAmmo(int current)
    {
        return current;
    }
    
    public void ReduceAmmo(int current)
    {
        GetCurrentAmmo(current);
    }
}
