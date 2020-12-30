using System.Collections;
using System;
        public class Canvas
        {
            private ArrayList canvas= new ArrayList();
            private int count=0;

            public void Add(IShape s)
            {
                IShape newOne= (IShape)s; 
                canvas.Add(s);
                count++;
                Console.WriteLine("Added Shape to canvas: {0}" + Environment.NewLine, s);
            }
            public void Remove()
            {
                canvas.RemoveAt(count);
                Console.WriteLine("Removed Shape from canvas: ");
            }

            public Canvas(){}

            public override string ToString()
            {
                String str = "Canvas (" + canvas.Count + " elements): " + Environment.NewLine;
                foreach (IShape s in canvas)
                {
                    str += "   > " + s + Environment.NewLine;
                }
                return str;
            }
            public ArrayList GetState()
            {
                return this.canvas;
            }
        
            public void SetState(Memento savedOne)
            {
                canvas.Clear();
                ArrayList newar =savedOne.GetState();
                foreach(var item in newar){
                    canvas.Add(item);
                }
            }

        }