using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float speed = 7f;
    public float jumpHeight = 10f;
    public bool isGrounded = false;

    public List<Transform> colliders;
    public LayerMask groundLayer;
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Input.GetAxis("Horizontal") * speed * Time.deltaTime * Vector3.right;
        isGrounded = GroundCheck();

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb2d.velocity = Vector3.up * jumpHeight;
        }
    }

    bool GroundCheck()
    {
        foreach (Transform t in colliders) {
            if (Physics2D.Raycast(t.position, Vector3.down, .02f, groundLayer)) {
                return true;
            }
        }
        return false;
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death") {
            Death();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Death") {
            Death();
        }
    }
}