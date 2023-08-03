using UnityEngine;

public class CircleColliderScript : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Square"))
        {
            Debug.Log("Circle collided with square!");
        }
    }
}
