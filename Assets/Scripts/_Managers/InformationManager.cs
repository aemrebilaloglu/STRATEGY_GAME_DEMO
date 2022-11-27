using UnityEngine;
using TMPro;
public class InformationManager : MonoBehaviour
{
    public TextMeshProUGUI informationHead;
    public GameObject selectedImage;
    public GameObject soldierImage;
    public GameObject panelObj;
    public Transform selectedObj;
    #region Singleton
    public static InformationManager instance = null;
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
}
