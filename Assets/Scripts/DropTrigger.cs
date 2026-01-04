using UnityEngine;

public class DropTrigger : MonoBehaviour
{
    [SerializeField] private Rigidbody2D obstacleRb;
    private bool hasDropped = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !hasDropped)
        {
            obstacleRb.gravityScale = 1;
            hasDropped = true;
        }
    }   
}
