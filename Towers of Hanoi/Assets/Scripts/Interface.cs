using UnityEngine;
using TMPro;

public class Interface : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI movesText;
    TowersManager towersManager;

    private void Awake()
    {
        towersManager = FindObjectOfType<TowersManager>();
    }

    private void Start()
    {
        movesText.text = "0";
    }

    private void OnEnable()
    {
        towersManager.newMovement.AddListener(UpdateNumMovements);
    }

    private void OnDisable()
    {
        towersManager.newMovement.RemoveAllListeners();
    }

    private void UpdateNumMovements(int numMovements)
    {
        movesText.text = numMovements.ToString();
    }
}
