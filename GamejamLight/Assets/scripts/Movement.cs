using Unity.Mathematics;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; // Snelheid van de speler
    [SerializeField] private float jumpForce = 10f; // Kracht van het springen
    private Rigidbody2D rb; // Rigidbody component
    private bool isGrounded; // Controleert of de speler op de grond is
    [SerializeField] private float G = 9.807f;
    [SerializeField] private int dashDistance;
    [SerializeField] private ParticleSystem particles;
    [SerializeField] int jumps;
    [SerializeField] int dashes;

    private Vector2 movement; // Beweging vector

    void Start()
    {
        jumps = 1;
        dashes = 1;
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
            jumps = 1;
            dashes = 1;
        }

        // Controleer of de speler springt
        if (Input.GetKeyDown(KeyCode.Space) && jumps > 0) Jump();
        if (Input.GetKeyDown(KeyCode.LeftShift) && dashes > 0) Dash();
    }

    void FixedUpdate()
    {
        // Beweeg de speler
        rb.velocity = movement;
    }

    void Jump()
    {
        jumps--;
        // Voeg een sprongetje toe
        movement.y = jumpForce;
        isGrounded = false; // De speler is nu in de lucht
    }
    void Dash()
    {
        
        Vector2 dir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        dir.Normalize();
        RaycastHit hit;
        particles.Play();
        if (Physics.Raycast(transform.position, dir, out hit) && hit.distance < dashDistance)
        {
            rb.MovePosition(hit.point);
        }
        else
        {
            rb.MovePosition(dir * dashDistance + rb.position);
        }
        dashes--;
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
