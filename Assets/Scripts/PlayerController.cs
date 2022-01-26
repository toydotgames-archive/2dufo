using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    private Rigidbody2D rb;
    public float speed;
    private int count = 0;
    public Text countText;
    public Text winText;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        winText.text = "";
        UpdateCountText();
    }

    void FixedUpdate() {
        float horizontalMovement = Input.GetAxis("Horizontal");
        float verticalMovement = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalMovement, verticalMovement); // Movement vector based off of player input.
        rb.AddForce(movement * speed); // Move the Rigidbody element of the player sprite depending on `movement`. `speed` can be modified in the Editor to allow for more playable movement speeds.

    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Gem")) { // Runs when touching gem.
            other.gameObject.SetActive(false);
            count++;
            UpdateCountText();
        }
    }

    void UpdateCountText() {
        countText.text = "Count: " + count.ToString();
        if(count >= 7) {
            winText.text = "You win!";
        }
    }
}
