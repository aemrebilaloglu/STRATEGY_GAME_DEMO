using UnityEngine;
using UnityEngine.UI;
public class Buildings : MonoBehaviour
{
    public void Production()
    {
        CheckButton();
    }
    public void ProductionReplacement()
    {
        CheckNames();
    }
    public void CheckNames()
    {
        if (BarracksManager.instance.onMove) return;

        if (GetComponent<Image>().sprite.name == "Barrack")
        {
            UIManager.instance.powerPlant.transform.position = new Vector3(50, 50, 0);
            UIManager.instance.barrack.transform.GetChild(0).GetComponent<DragAndDrop>().Drag();
            UIManager.instance.barrack.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
        else if (GetComponent<Image>().sprite.name == "PowerPlant")
        {
            UIManager.instance.barrack.transform.position = new Vector3(50, 50, 0);
            UIManager.instance.powerPlant.transform.GetChild(0).GetComponent<DragAndDrop>().Drag();
            UIManager.instance.powerPlant.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
        else if (GetComponent<Image>().sprite.name == "soldier")
        {
            UIManager.instance.barrack.transform.position = new Vector3(50, 50, 0);
            UIManager.instance.powerPlant.transform.position = new Vector3(50, 50, 0);
            UIManager.instance.soldier.transform.GetChild(0).GetComponent<DragAndDrop>().Drag();
            UIManager.instance.soldier.transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
    }
    public void CheckButton()
    {
        if (GetComponent<Image>().sprite.name == "Barrack")
        {
            InformationManager.instance.panelObj.SetActive(true);
            InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            InformationManager.instance.informationHead.text = "Barrack";
            InformationManager.instance.soldierImage.SetActive(true);

        }
        else if (GetComponent<Image>().sprite.name == "PowerPlant")
        {
            InformationManager.instance.panelObj.SetActive(true);
            InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<Image>().sprite;
            InformationManager.instance.informationHead.text = "Power Plant";
            InformationManager.instance.soldierImage.SetActive(false);
        }
    }
}
