using System.Collections.Generic;
using UnityEngine;

public class CardStack : MonoBehaviour
{
    [SerializeField] private float cardSpacing = 5;

    private List<Card> cards = new List<Card>();

    public void AddCard(Card card)
    {
        card.transform.SetAsLastSibling();

        Vector3 cardPos = transform.position + new Vector3(0, -cards.Count * cardSpacing, 0f);
        card.transform.position = cardPos;
        
        cards.Add(card);
    }

    public void RemoveCard(Card card)
    {
        cards.Remove(card);
    }

    public bool IsTopCard(Card card)
    {
        return cards.Count > 0 && cards[^1] == card;
    }
}