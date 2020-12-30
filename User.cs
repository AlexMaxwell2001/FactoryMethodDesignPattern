using System;
using System.Collections.Generic;
public class User
{
    private Stack<Memento> undo;
    private Stack<Memento> redo;
    public int UndoCount { get => undo.Count; }
    public int RedoCount { get => undo.Count; }
    public User()
    {
        Reset();
    }
    public void Reset()
    {
        undo = new Stack<Memento>();
        redo = new Stack<Memento>();
    }

    public void Action(IShape s, Canvas current)
    {
        Memento m=new Memento();
        m.SetMemento(current.GetState());
        undo.Push(m);  
        current.Add(s);
        redo.Clear(); 
    }
    public void Undo(Canvas canvas)
    {
        if (undo.Count > 0)
        {
            Console.WriteLine("Undoing operation!"); 
            Memento old=new Memento();
            old.SetMemento(canvas.GetState());
            Memento c = undo.Pop();canvas.SetState(c);redo.Push(old);
        }else {
            Console.WriteLine("No operation to undo!"); 
        }

    }
     public void Redo(Canvas canvas)
    {
        if (redo.Count > 0)
        {
            Console.WriteLine("Redoing operation!"); 
            Memento c = redo.Pop(); canvas.SetState(c); undo.Push(c);
        }else{
            Console.WriteLine("No operation to be redone!"); 
        }

    }
}