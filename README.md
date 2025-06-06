# 🃏 Solitaire Undo System Prototype

A Unity prototype implementing a simplified **Undo Move** system for a Solitaire-style game.

## ✅ What I Built

This is a minimal Solitaire-inspired prototype that allows the player to **drag cards between stacks** and **undo their last move**.

### Core Features:

- 🖱️ **Drag-and-drop** movement between 2–3 card stacks  
- 🔄 **Undo system** with one-step revert using a static `UndoManager`  
- 🔔 **Event-driven UI update** — Undo button state updates automatically  
- 🧩 **Extensible architecture** using `IUndoableAction` interface for undoable commands  
- 🧼 **Modular, clean code structure** with separation of concerns

---

## 🚀 What I’d Improve With More Time

With additional time, I would:

- Implement **multi-card drag** and proper Solitaire ruleset  
- Add **animations** and visual transitions (card flip, smooth movement)  
- Include **Redo** support with a forward stack  
- Build a **full game flow**: deal, reset, win state  
- Improve **mobile responsiveness** and input handling  
- Refactor to use a **command pattern** for grouped actions

---

## 🤖 AI Assistance Summary

I used **ChatGPT 4.5** during development to assist with architectural decisions, boilerplate generation, and Unity-specific best practices.

### Prompts & Usage:

- **Initial structure**:  
  _"Generate a modular Unity architecture for Undo Move in Solitaire with drag-and-drop cards."_

- **Event-based UndoManager**:  
  _"Make UndoManager static and UI-independent via events instead of direct references."_

- **Reliable drag target detection**:  
  _"PointerEventData.pointerEnter always returns the dragged card, change logic to detect stack underneath"_

- **Undo via interfaces**:  
  _"Refactor UndoManager to use interface instead of hardcoded Move class."_

> AI helped **accelerate boilerplate** and **validate patterns**, but all logic was reviewed, modified, and integrated manually to fit the project scope.

---

🛠 Built with **Unity 6000.0.44f1**, written in **C#**, using native **Unity UI** and **event system**.
