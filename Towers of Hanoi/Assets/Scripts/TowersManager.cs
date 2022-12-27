using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowersManager : MonoBehaviour
{
    [SerializeField] int numOfDisks = 3;
    [SerializeField] Disk disk;
    List<Tower> towers = new List<Tower>();
    int numUserMovements = 0;
    Tower selectedTower = null;

    private void Start()
    {
        Tower[] towerList = FindObjectsOfType<Tower>();
        foreach(Tower tower in towerList)
        {
            towers.Add(tower);
        }

        SpawnDisks();
    }

    void SpawnDisks()
    {
        for(int i = numOfDisks; i > 0; i--)
        {
            Disk diskObject = Instantiate(disk, towers[0].transform);
            diskObject.place = i;
            towers[0].AddToStack(diskObject);
        }
    }

    void ChangeTower(Disk disk, Tower newTower)
    {
        newTower.AddToStack(disk);
    }

}
