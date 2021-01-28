using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CSharpTheory
{
    public class Lists 
    {
        public void initialize()
        {
            List<int> myList = new List<int>();
            myList.Add(5);
            myList.Add(6);

            int a = myList[0]; 
            int b = myList[1];
            Debug.Log($" a = {a} et b = {b}");

            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);

            int c = myQueue.Dequeue();
            int d = myQueue.Dequeue();
            Debug.Log($" c = {c} et d = {d}");

            Stack<int> myStack = new Stack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);

            int e = myStack.Pop();
            int f = myStack.Peek();
            Debug.Log($" e = {e} et f = {f}");
            Debug.Log($" Size de myStack = {myStack.Count}");

            Dictionary<string, int> dict = new Dictionary<string, int>();
            dict.Add("First", 1);
            dict.Add("Two", 2);

            int g = dict["First"];
            int h;

            if(dict.TryGetValue("Two",out h))
            {
                Debug.Log($" h = {h}");
            }

        }
    }
}

