using UnityEngine;
public class Soldier : Buildings
{
    public void Production()
    {
        if (BarracksManager.instance.SoldierUnit.transform.childCount < 2)
        {
            BarracksManager.instance.soldierMove = true;
            transform.SetParent(BarracksManager.instance.SoldierUnit.transform);
        }
    }
}
