using UnityEngine;
public class BarracksManager : MonoBehaviour
{
    public int soldierCount = -1;
    public Unit SoldierUnit;
    public bool soldierMove = false;
    public bool onMove = false;
    #region Singleton
    public static BarracksManager instance = null;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    #endregion
}
