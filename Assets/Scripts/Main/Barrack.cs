using System.Collections;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class Barrack : Buildings
{
    public GameObject timeImg;
    public float soldierSpawnTime;
    public Text soldierSpawnTimeText;
    BarracksManager bm;
    IEnumerator Start()
    {
        yield return new WaitForSeconds(5);
        SoldierSpawn();
        StartCoroutine(Start());
    }
    private void Awake()
    {
        bm = BarracksManager.instance;
        timeImg.transform.DOLocalRotate(new Vector3(0, 0, -360), 2f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Yoyo).OnUpdate(() =>
        {
            if (bm.soldierCount < 5)
            {
                soldierSpawnTime-=Time.deltaTime;

                if (soldierSpawnTime < 0)
                {
                    soldierSpawnTime = 5f;
                    bm.soldierCount++;
                }
                soldierSpawnTimeText.text = "S/" + soldierSpawnTime .ToString("0");
            }
            else
            {
                soldierSpawnTimeText.text = "FULL".ToString();
            }
        });
    }
    public void SoldierSpawn()
    {
        if (bm.soldierCount < 6)
        {
            SoldierSlot.instance.soldierSlot[bm.soldierCount].SetActive(true);
        }
    }
    public void Production()
    {
        InformationManager.instance.panelObj.SetActive(true);
        InformationManager.instance.selectedImage.GetComponent<Image>().sprite = GetComponent<SpriteRenderer>().sprite;
        InformationManager.instance.informationHead.text = "Barrack";
        InformationManager.instance.soldierImage.SetActive(true);
    }
}
