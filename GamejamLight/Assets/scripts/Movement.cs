using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Snelheid van de speler
    [SerializeField] private float jumpForce = 10f; // Kracht van het springen
    private Rigidbody2D rb; // Rigidbody component
    private bool isGrounded; // Controleert of de speler op de grond is
    [SerializeField] private float G = 9.807f;

    private Vector2 movement; // Beweging vector

    void Start()
    {
        // Verkrijg de Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Verkrijg invoer van de speler
        movement.x = Input.GetAxis("Horizontal") * moveSpeed;

        if (!isGrounded)
        {
            movement.y -= G * Time.deltaTime;
        }
        else 
        { 
            movement.y = -0.1f;
        }

        // Controleer of de speler springt
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        // Beweeg de speler
        rb.velocity = movement;
    }

    void Jump()
    {
        // Voeg een sprongetje toe
        movement.y = jumpForce;
        isGrounded = false; // De speler is nu in de lucht
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Controleert of de speler de grond raakt
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Speler is weer op de grond
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
