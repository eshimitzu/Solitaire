using UnityEngine;
using UnityEngine.UI;

public class UndoButton : MonoBehaviour
{
    private Button button;

    private void Awake()
    {
        button = GetComponent<Button>();
    }

    private void OnEnable()
    {
        UndoManager.OnUndoStateChanged += UpdateButtonState;
        UpdateButtonState(); 
    }

    private void OnDisable()
    {
        UndoManager.OnUndoStateChanged -= UpdateButtonState;
    }

    public void OnUndoClick()
    {
        UndoManager.UndoLast();
    }

    private void UpdateButtonState()
    {
        button.interactable = UndoManager.CanUndo;
    }
}