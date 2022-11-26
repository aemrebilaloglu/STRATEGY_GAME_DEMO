using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Buildings : MonoBehaviour
{
    public void Production()
    {
        if(GetComponent<Image>().sprite.name == "Barrack")
        {
            InformationManager.instance.panelObj.SetActive(true);
            InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            InformationManager.instance.informationHead.text = "Barrack";
            InformationManager.instance.informationTextOne.text = "Level : MAX";
            InformationManager.instance.informationTextTwo.text = "Spawn : MAX";
            InformationManager.instance.soldierImage.SetActive(true);

        }
        else if(GetComponent<Image>().sprite.name == "PowerPlant")
        {
            InformationManager.instance.panelObj.SetActive(true);
            InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            InformationManager.instance.informationHead.text = "Power Plant";
            InformationManager.instance.informationTextOne.text = "Power : MAX";
            InformationManager.instance.informationTextTwo.text = "Capacity : MAX";
            InformationManager.instance.soldierImage.SetActive(false);
        }
    }
    public void ProductionReplacement()
    {
        if (GetComponent<Image>().sprite.name == "Barrack")
        {
            UIManager.instance.barrack.transform.GetChild(0).GetComponent<DragAndDrop>().Drag();
            UIManager.instance.barrack.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
        else if (GetComponent<Image>().sprite.name == "PowerPlant")
        {
            UIManager.instance.powerPlant.transform.GetChild(0).GetComponent<DragAndDrop>().Drag();
            UIManager.instance.powerPlant.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
    }
}
