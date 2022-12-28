using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    // This will contain a stack to keep track of disks.
    // This list adds elements to the end and pops the last element.
    // Like a Stack but in reverse.
    [SerializeField] List<Disk> diskStack;

    private void Start()
    {
        diskStack = new List<Disk>();
    }

    public void AddToStack(Disk disk)
    {
        diskStack.Add(disk);
        Debug.Log("Stack has now: " + diskStack.Count);
    }

    /// <summary>
    /// Function that works like the Pop function in a Stack
    /// </summary>
    /// <param name="disks"></param>
    /// <returns></returns>
    public Disk StackPop()
    {
        if (diskStack.Count == 0)
            return null;
        int lastIndex = diskStack.Count - 1;
        Disk disk = diskStack[lastIndex];
        diskStack.RemoveAt(lastIndex);
        return disk;
    }

    public int GetStackSize()
    {
        return diskStack.Count;
    }

    public Disk StackPeek()
    {
        if (diskStack.Count > 0)
            return diskStack[diskStack.Count - 1];
        return null;
    }

    public bool IsEmpty()
    {
        return diskStack.Count == 0;
    }
}
