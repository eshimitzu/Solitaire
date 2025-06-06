using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    [SerializeField] Image view;
    [SerializeField] List<Sprite> randomIcons;

    private CardStack currentStack;

    public CardStack CurrentStack => currentStack;


    public void Awake()
    {
        view.sprite = randomIcons[Random.Range(0, randomIcons.Count)];
    }
    
    public void MoveToStack(CardStack newStack)
    {
        if (currentStack != null)
            currentStack.RemoveCard(this);

        newStack.AddCard(this);
        currentStack = newStack;
    }
}