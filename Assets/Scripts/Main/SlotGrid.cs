using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class SlotGrid : MonoBehaviour
{
    DragAndDrop drop;
    public bool isGreen = false;
    public bool isSoldier = false;
   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Barrack"))
        {
            if (transform.parent.GetComponent<SquareNode>().Walkable)
            {
                isGreen = true;
                drop = other.GetComponent<DragAndDrop>();
                drop.gridList.Add(gameObject);
                if (drop.gridList.Count < drop.correctGridCount)
                {
                    for (int i = 0; i < drop.gridList.Count; i++)
                    {
                        transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1f, 0.12f, 0f, 1);
                    }
                }
                else
                {
                    for (int i = 0; i < drop.gridList.Count; i++)
                    {
                        drop.gridList[i].transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.16f, 1, 0.12f, 1);
                    }
                }
                Debug.Log("zaa");
            }
        }
        if (other.CompareTag("Soldier"))
        {
            transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.64f, 0.58f, 0.287f, 1);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Barrack"))
        {
            if (transform.parent.GetComponent<SquareNode>().Walkable)
            {
                isGreen = false;
                drop.gridList.Remove(gameObject);
                transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.64f, 0.58f, 0.287f, 1);
            }
        }
        if (other.CompareTag("Soldier"))
        {
           transform.parent.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.64f, 0.58f, 0.287f, 1);         
        }
    }
}
