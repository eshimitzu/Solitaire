using System;
using System.Collections.Generic;

public static class UndoManager
{
    private static Stack<IUndoableAction> history = new Stack<IUndoableAction>();

    public static event Action OnUndoStateChanged;

    public static bool CanUndo => history.Count > 0;

    public static void RegisterAction(IUndoableAction action)
    {
        history.Push(action);
        OnUndoStateChanged?.Invoke();
    }

    public static void UndoLast()
    {
        if (history.Count > 0)
        {
            var action = history.Pop();
            action.Undo();
            OnUndoStateChanged?.Invoke();
        }
    }

    public static void Reset()
    {
        history.Clear();
        OnUndoStateChanged?.Invoke();
    }
}