//UPDDATED TO INCLUDE GAME OVER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public GameObject gameOverPanel; // Drag your panel here in the inspector

    private float direction = 0f;
    private Rigidbody2D player;

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false); // Make sure panel is hidden at start
    }

    void Update()
    {
        direction = Input.GetAxis("Horizontal");

        if (direction != 0f)
        {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
        }
        else
        {
            player.velocity = new Vector2(0, player.velocity.y);
        }

        if (Input.GetButtonDown("Jump"))
        {
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameOverPanel.SetActive(true); // Show Game Over screen
            Time.timeScale = 0f; // Pause the game
        }
    }
}
