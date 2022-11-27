using System.Collections.Generic;
using UnityEngine;
public class SoldierSlot : Soldier
{
    #region Singleton
    public static SoldierSlot instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            DestroyImmediate(this);
        }
    }
    #endregion
    public List<GameObject> soldierSlot = new List<GameObject>();
}
