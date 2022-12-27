using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // This will contain a stack to keep track of disks
    Stack<Disk> stack = new Stack<Disk>();

    public void AddToStack(Disk disk)
    {
        stack.Push(disk);
    }

    public Disk RemoveFromStack()
    {
        return stack.Pop();
    }
}
