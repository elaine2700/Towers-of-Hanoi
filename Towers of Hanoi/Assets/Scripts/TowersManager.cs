using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///The game finishes when the right stack count is the same as numOfDisks.
///Invalid move if disk on top of stack is less than selected Disk.
/// </summary>
public class TowersManager : MonoBehaviour
{
    [SerializeField] int numOfDisks = 3;
    public int NumOfDisks { get { return numOfDisks; } }
    [SerializeField] Disk diskPrefab;
    [SerializeField] List<Tower> towers = new List<Tower>();
    int numUserMovements = 0;
    [SerializeField] Tower fromTower = null;
    [SerializeField] Tower toTower = null;
    [SerializeField] Disk diskToChange = null;

    private void Start()
    {
        Tower[] towerList = FindObjectsOfType<Tower>();
        foreach(Tower tower in towerList)
        {
            towers.Add(tower);
        }

        SpawnDisks();

    }

    private void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                // First case. Selecting a tower to select disk.
                // Selected tower is empty and diskToChange is empty
                // First selection.
                // If hit object is one of the towers. Hit object is fromTower
                if(fromTower == null)
                {
                    foreach (Tower tower in towers)
                    {
                        if (hit.transform == tower.transform)
                        {
                            fromTower = tower;
                            Debug.Log($"fromTower {tower.transform.name} selected");
                            break;
                        }
                    }
                    if (fromTower == null) return;
                    if (fromTower.IsEmpty())
                    {
                        // if tower stack is empty. Invalid move.
                        Debug.Log("Stack empty.");
                        fromTower = null;
                        return;
                    }
                    // Get disk from selected tower.
                    diskToChange = fromTower.StackPeek();
                    Debug.Log($"{diskToChange.transform.name} was selected");
                }

                // Second case. Waiting to change the disk
                else if (fromTower != null )
                {
                    if (diskToChange != null)
                    {
                        foreach (Tower tower in towers)
                        {
                            if (hit.transform == tower.transform)
                            {
                                toTower = tower;
                                Debug.Log($"toTower {tower.transform.name} selected");
                                break;
                            }
                        }
                        if (toTower == null) return;
                        if (toTower.IsEmpty() || diskToChange.value < toTower.StackPeek().value)
                            ChangeTower(fromTower.StackPop(), toTower);
                        else
                        {
                            Debug.Log("Invalid Move");
                            fromTower = null;
                            diskToChange = null;
                            toTower = null;
                            
                        }
                            
                    }
                }
                
            }
        }
    }

    void SpawnDisks()
    {
        int i = numOfDisks;
        while (i > 0)
        {
            Disk diskObject = Instantiate<Disk>(diskPrefab, transform.position, Quaternion.identity);
            diskObject.transform.name = $"{diskObject.transform.name} {i}";
            diskObject.value = i;
            towers[0].AddToStack(diskObject);
            diskObject.MovePosition(towers[0]);
            i--;
        }
        
    }

    void ChangeTower(Disk disk, Tower newTower)
    {
        newTower.AddToStack(disk);
        disk.MovePosition(newTower);
        fromTower = null;
        diskToChange = null;
        toTower = null;
        numUserMovements++;
        CheckRightStack();
    }

    void CheckRightStack()
    {
        if(towers[2].GetStackSize() == numOfDisks)
        {
            Debug.Log("Game has finished.");
            // Finished game.
            // Todo End Game.
        }
    }

}
