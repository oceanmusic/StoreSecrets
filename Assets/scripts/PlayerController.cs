
// Add this line at the top of the script
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [System.Serializable]
    public class PlayerModel
    {
        public float MoveSpeed = 5f;
        public int coinsCollected;
    }

    public PlayerModel model;

    private Rigidbody2D rb;
    private SpriteRenderer[] spriteRenderers;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
    }


    public void Move(float horizontalInput, float verticalInput)
    {
        Vector2 movement = new Vector2(horizontalInput, verticalInput) * model.MoveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + movement);

        // Flip character sprite
        if (horizontalInput > 0f)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = false;
            }
        }
        else if (horizontalInput < 0f)
        {
            foreach (SpriteRenderer spriteRenderer in spriteRenderers)
            {
                spriteRenderer.flipX = true;
            }
        }
    }

    public void Rotate(bool rotateLeft, bool rotateRight)
    {
        float targetRotation = rotateLeft ? -190f : (rotateRight ? 0f : transform.localRotation.eulerAngles.y);
        transform.localRotation = Quaternion.Euler(0f, targetRotation, 0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision with: " + collision.gameObject.name);
    }

    public void AddCoins(int amount)
    {
        model.coinsCollected += amount;
        Debug.Log("Coins collected: " + model.coinsCollected);

        // Update UI
        UIController uiController = FindObjectOfType<UIController>();
        if (uiController != null)
        {
            uiController.UpdateCoinsUI();
        }
    }
}
