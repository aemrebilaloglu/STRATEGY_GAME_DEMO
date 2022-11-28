using UnityEngine;
using UnityEngine.UI;
public class PowerPlant : Buildings
{
    public void Production()
    {
        if (GetComponent<SpriteRenderer>().sprite.name == "PowerPlant")
        {
            InformationManager.instance.panelObj.SetActive(true);
            InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
            InformationManager.instance.informationHead.text = "Power Plant";
            InformationManager.instance.soldierImage.SetActive(false);
        }
    }
}
