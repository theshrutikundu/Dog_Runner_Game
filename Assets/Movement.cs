using UnityEngine;
using UnityEngine.Rendering;

public class Movement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 4f;
    public bool isGrounded=false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xInput = Input.GetAxis("Horizontal");
        Debug.Log(xInput);
        Vector2 force = new Vector2(xInput * speed, rb.velocityY);
        rb.velocity = force;
        if (Input.GetButton("Jump")&&isGrounded)
        {
            Debug.Log("Jump");
            rb.AddForce(new Vector2(0,2) , ForceMode2D.Impulse);
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        isGrounded = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
    }
}