using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Stack Generation")]
    [SerializeField] private CardStack cardStackPrefab;
    [SerializeField] private int numberOfStacks = 3;
    [SerializeField] private float stackSpacing = 220f;
    [SerializeField] private Transform boardRoot;
    
    [Header("Card Generation")]
    [SerializeField] private Card cardPrefab;
    [SerializeField] private int numberOfCards = 3;

    
    private void Awake()
    {
        UndoManager.Reset();
        GenerateStacks();
    }

    private void GenerateStacks()
    {
        if (cardStackPrefab == null || numberOfStacks <= 0) return;

        float totalWidth = (numberOfStacks - 1) * stackSpacing;
        float startX = -totalWidth / 2f;

        for (int i = 0; i < numberOfStacks; i++)
        {
            float xPos = startX + i * stackSpacing;
            Vector3 position = new Vector3(xPos, 0f, 0f);

            CardStack cardStack = Instantiate(cardStackPrefab, boardRoot);
            cardStack.transform.localPosition = position;
            cardStack.name = $"CardStack_{i}";
          
            GenerateCards(cardStack);
        }
    }

    private void GenerateCards(CardStack stack)
    {
        for (int i = 0; i < numberOfCards; i++)
        {
            Card card = Instantiate(cardPrefab, boardRoot);
            card.name = $"Card_{i}";
            
            card.MoveToStack(stack);
        }
    }
}