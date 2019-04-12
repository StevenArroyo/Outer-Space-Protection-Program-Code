using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MTpopup : MonoBehaviour,  IPointerEnterHandler, IPointerExitHandler
{
    public bool isOver = false;

    public GameObject unitInfo;

    public void OnPointerEnter(PointerEventData eventData)
    {
        unitInfo.SetActive (true);
        Debug.Log("Mouse enter");
        isOver = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        unitInfo.SetActive (false);
        Debug.Log("Mouse exit");
        isOver = false;
    }
}
