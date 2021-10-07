using UnityEngine;
using UnityEngine.EventSystems;
public class CardUISlot : MonoBehaviour, IDropHandler
{
    public CardController CardCurrentlyInSlot;

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            CardController card = eventData.pointerDrag.GetComponent<CardController>();
            PlaceCardInSlot(card);            
        }
    }

    public void PlaceCardInSlot(CardController card)
    {
        CardDragDrop dragDrop = card.DragDrop;
        if (dragDrop.AllowDragging)
        {
            card.transform.SetParent(transform);
            CardCurrentlyInSlot = card;
            CardCurrentlyInSlot.CurrentSlot = this;
            dragDrop.DroppedOnSlot = true;
            dragDrop.CurrentSlot = this;
            dragDrop.StartPos = transform.position;
            card.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;

            if (dragDrop.SlotAtStartOfDrag != null)
                dragDrop.SlotAtStartOfDrag.GetComponent<CardUISlot>().RemoveCardFromSlot(); // if it was in a slot, clear the slot
        }
    }

    public void RemoveCardFromSlot() => CardCurrentlyInSlot = null;
}
