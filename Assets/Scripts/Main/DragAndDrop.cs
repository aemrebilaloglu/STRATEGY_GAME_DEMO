using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;
public class DragAndDrop : MonoBehaviour/*,IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerDownHandler*/
{
    private Camera mainCamera;
    private float CameraZDistance;
    public List<GameObject> gridList = new List<GameObject>();
    public bool isBarrack = false;
    public bool isPowerPlant = false;
    public bool isSoldier = false;
    public int correctGridCount; // Barrack = 16, PowerPlant = 6
    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance =
            mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }
    private void Update()
    {
        if (gridList.Count> 1 && gridList.Count < correctGridCount)
        {
            for (int i = 0; i < gridList.Count; i++)
            {
                gridList[i].transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 0.12f, 0f, 1);
            }
        }
    }
    public void Drag()
    {
        OnMouseDrag();
    }
    void OnMouseDrag()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        transform.parent.position = NewWorldPosition;
        transform.parent.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.65f);
       
    }
    private void OnMouseDown()
    {
        if (isSoldier)
        {
            transform.GetComponent<BoxCollider>().size = new Vector3(0.015f, 0.015f, 1);
        }
    }
    public void CorrectGrid()
    {
        if (gridList.Count == correctGridCount)
        {
            bool allGreen = true;

            for (int i = 0; i < gridList.Count; i++)
            {
                if (!gridList[i].GetComponent<SlotGrid>().isGreen)
                {
                    allGreen = false;
                }
            }
            if (allGreen)
            {
                float xPos = 0;
                float yPos = 0;

                for (int i = 0; i < gridList.Count; i++)
                {
                    xPos += gridList[i].transform.position.x;
                    yPos += gridList[i].transform.position.y;
                }
                xPos /= correctGridCount;
                yPos /= correctGridCount;

                transform.parent.DOMove(new Vector3(xPos, yPos, 0), 0.05f).OnComplete(() =>
                {
                    if (isBarrack)
                    {
                        Instantiate(Resources.Load("SpawnBarrack"), new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    else if (isPowerPlant)
                    {
                        Instantiate(Resources.Load("SpawnPower"), new Vector3(xPos, yPos, 0), Quaternion.identity);
                    }
                    else if (isSoldier)
                    {
                        Instantiate(Resources.Load("SpawnSoldier"), new Vector3(xPos, yPos, 0), Quaternion.identity);
                        transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 1f, 1f);

                        SoldierSlot.instance.soldierSlot[BarracksManager.instance.soldierCount].SetActive(false);
                        BarracksManager.instance.soldierCount--;

                        if (BarracksManager.instance.SoldierUnit.transform.childCount>1)
                        {
                            BarracksManager.instance.SoldierUnit.transform.GetChild(1).parent = null;
                        }
                    }
                    transform.parent.position = new Vector3(50, 50, 0);
                });
                transform.parent.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);

                for (int i = 0; i < gridList.Count; i++)
                {
                    if (isSoldier)
                    {
                        gridList[i].transform.parent.GetComponent<NodeBase>().SoldierCheck(true);
                    }
                    gridList[i].transform.parent.GetComponent<NodeBase>().Walk(false);
                    gridList[i].transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 0.12f, 0f, 1);
                }
                gridList.Clear();
            }
        }
        else
        {
            transform.parent.position = new Vector3(50, 50, 0); // out
            if (isSoldier)
            {
                transform.GetComponent<BoxCollider>().size = new Vector3(0.5f, 1f, 1f);
            }
        }
    }
    private void OnMouseUp()
    {
        CorrectGrid();
    }
}
