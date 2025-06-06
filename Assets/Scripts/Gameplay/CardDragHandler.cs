using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;

public class CardDragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startPos;
    private Transform originalParent;
    private Canvas canvas;
    private Card card;

    private void Awake()
    {
        card = GetComponent<Card>();
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (card.CurrentStack == null || !card.CurrentStack.IsTopCard(card))
        {
            eventData.pointerDrag = null;
            return;
        }

        startPos = transform.position;
        originalParent = transform.parent;

        transform.SetAsLastSibling();
    }


    public void OnDrag(PointerEventData eventData)
    {
        transform.position += (Vector3)eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        List<RaycastResult> raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);

        foreach (var result in raycastResults)
        {
            CardStack targetStack = result.gameObject.GetComponent<CardStack>();
            if (targetStack != null && targetStack != card.CurrentStack)
            {
                UndoManager.RegisterMove(card, card.CurrentStack, targetStack);
                card.MoveToStack(targetStack);
                return;
            }
        }

        transform.position = startPos;
    }
}