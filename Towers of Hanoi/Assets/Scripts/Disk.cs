using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disk : MonoBehaviour
{
    public int value = 1;
    [SerializeField] float maxSize = 1f;
    [SerializeField] float minSize = 0.5f;
    TowersManager towersManager;
    float numOfDisks = 0f;

    private void Start()
    {
        towersManager = FindObjectOfType<TowersManager>();
        numOfDisks = towersManager.NumOfDisks;
        SetSize();
    }

    private void SetSize()
    {
        // Interpolate size
        float size = Mathf.Lerp(minSize, maxSize, value / numOfDisks);
        Vector3 newSize = new Vector3(size, transform.localScale.y, size);
        transform.localScale = newSize;
    }

    public void MovePosition(Tower newTower)
    {
        Vector3 newPos = newTower.fallPoint.position;
        transform.position = newPos;
    }
}
