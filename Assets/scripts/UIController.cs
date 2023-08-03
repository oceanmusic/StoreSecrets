using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public UIModel model;
    private PlayerController playerController;

    private void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
        {
            Debug.LogError("PlayerController not found in the scene!");
        }
    }


    private void Update()
    {
        UpdateCoinsUI();
    }

    public void UpdateCoinsUI()
    {
        if (playerController != null)
        {
            model.coinsText.text = "Cash: " + playerController.model.coinsCollected;
        }
        else
        {
            Debug.LogError("PlayerController is null!");
        }
    }
}
