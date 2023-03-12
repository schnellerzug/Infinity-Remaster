using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePlayerDirection : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.attachedRigidbody.velocity = Vector2.zero;
            collision.attachedRigidbody.gravityScale = -collision.attachedRigidbody.gravityScale;
            GameManager.instance.ChangeLevel();
        }

    }
}
