using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Needed for reloading scenes

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    public float jumpSpeed = 8f;
    public GameObject gameOverPanel; // UI panel or Game Over image object

    private float direction = 0f;
    private Rigidbody2D player;
    private bool isGameOver = false; // Track game state

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        gameOverPanel.SetActive(false); // Hide game over UI
        Time.timeScale = 1f; // Ensure game runs if restarted
    }

    void Update()
    {
        if (isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Time.timeScale = 1f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Restart scene
            }
            return; // Skip movement if game is over
        }

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
            isGameOver = true;
            gameOverPanel.SetActive(true); // Show "Game Over" UI (text or image)
            Time.timeScale = 0f; // Pause game
        }
    }
}
