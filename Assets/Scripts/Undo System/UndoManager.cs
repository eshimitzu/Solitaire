using System;
using System.Collections.Generic;

public static class UndoManager
{
    private static Stack<Move> moveHistory = new Stack<Move>();

    public static event Action OnUndoStateChanged;

    public static bool CanUndo => moveHistory.Count > 0;

    public static void RegisterMove(Card card, CardStack from, CardStack to)
    {
        moveHistory.Push(new Move(card, from, to));
        OnUndoStateChanged?.Invoke();
    }

    public static void UndoLastMove()
    {
        if (moveHistory.Count > 0)
        {
            Move lastMove = moveHistory.Pop();
            lastMove.Undo();
            OnUndoStateChanged?.Invoke();
        }
    }

    public static void Reset()
    {
        moveHistory.Clear();
        OnUndoStateChanged?.Invoke();
    }
}