using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class InformationManager : MonoBehaviour
{
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
    public TextMeshProUGUI informationHead;
    public TextMeshProUGUI informationTextOne;
    public TextMeshProUGUI informationTextTwo;
    public TextMeshProUGUI informationTextThree;
    public TextMeshProUGUI informationTexFour;
    public GameObject selectedImage;
    public GameObject panelObj;
    public Transform selectedObj;
}
