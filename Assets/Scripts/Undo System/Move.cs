public struct Move
{
    public Card card;
    public CardStack from;
    public CardStack to;

    public Move(Card card, CardStack from, CardStack to)
    {
        this.card = card;
        this.from = from;
        this.to = to;
    }

    public void Undo()
    {
        card.MoveToStack(from);
    }
}