using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController controller;
    private Animator animator;
    public GameObject visualComponent;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponent<Animator>();
    }


    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate character
        if (Input.GetKeyDown(KeyCode.A))
        {
            RotateCharacter(-190f); // Rotate left
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            RotateCharacter(0f); // Rotate back to original rotation
        }

        controller.Move(horizontalInput, verticalInput);

        // Update animator parameters
        UpdateAnimatorParameters(horizontalInput, verticalInput);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Debug.Log("Coin collected!");
            CollectCoin(other.GetComponent<Coin>());
        }
    }

    private void CollectCoin(Coin coin)
    {
        Debug.Log("Adding coins: " + coin.model.coinValue);
        controller.AddCoins(coin.model.coinValue);
        Destroy(coin.gameObject);
    }

    private void UpdateAnimatorParameters(float horizontalInput, float verticalInput)
    {
        bool isMoving = horizontalInput != 0f || verticalInput != 0f;

        // Set IsMoving parameter
        animator.SetBool("IsMoving", isMoving);

        // Set movement parameters
        animator.SetFloat("Horizontal", horizontalInput);
        animator.SetFloat("Vertical", verticalInput);
    }

    private void RotateCharacter(float targetRotation)
    {
        visualComponent.transform.localRotation = Quaternion.Euler(0f, targetRotation, 0f);
    }
}
