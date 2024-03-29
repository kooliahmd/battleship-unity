﻿
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class FireSlotSelector : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Coordination firePosition;

    public bool IsSelected = false;
    public bool ToHit = false;
    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (GetComponent<Slot>().IsHit() || GetComponent<Slot>().IsMiss()) {
            return;
        }
        initAll();
        firePosition = GetComponent<Slot>().Coordination;
        IsSelected = true;
        GetComponent<Image>().color = Color.gray;
        Debug.Log(firePosition.x);
        Debug.Log(firePosition.y);
        GameObject.Find("fire-btn").GetComponent<Button>().interactable = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (ToHit) {
            return;
        }
        GetComponent<Image>().color = Color.gray ;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (ToHit)
        {
            return;
        }
        if (!IsSelected) {
            GetComponent<Image>().color = new Color(0.1174351f, 0.483185f, 0.8584906f);
        }
        
    }

    private void initAll() {
        GameObject[] slots = GameObject.FindGameObjectsWithTag("opponent-slot");
        foreach (GameObject slot in slots) {
            if (slot.GetComponent<FireSlotSelector>().ToHit) {
                continue;
            }
            slot.GetComponent<FireSlotSelector>().IsSelected = false ;
            slot.GetComponent<Image>().color = new Color(0.1174351f, 0.483185f, 0.8584906f);
        }
    }


}
