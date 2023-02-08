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

    public int GetCurrentAmmo(AmmoType type)
    {
        return GetAmmoSlot(type).amount;
    }

    public void IncreaseAmmo(AmmoType type, int amount)
    {
        GetAmmoSlot(type).amount += amount;
    }
    
    public void ReduceAmmo(AmmoType type)
    {
        GetAmmoSlot(type).amount--;
    }

    private AmmoSlot GetAmmoSlot(AmmoType type)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.type == type)
            {
                return slot;
            }
        }
        return null;
    }
}
