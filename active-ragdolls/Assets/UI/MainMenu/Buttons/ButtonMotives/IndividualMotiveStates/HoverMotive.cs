using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMotive : MonoBehaviour , IPointerEnterHandler , IPointerExitHandler
{
    public GameObject Motive;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Motive.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       Motive.SetActive(false); 
    }
}
