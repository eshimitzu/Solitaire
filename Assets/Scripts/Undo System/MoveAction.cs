public class MoveAction : IUndoableAction
{
    private Card card;
    private CardStack from;
    private CardStack to;

    public MoveAction(Card card, CardStack from, CardStack to)
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