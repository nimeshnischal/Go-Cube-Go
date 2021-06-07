using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardForce = 500f;
    public float lateralForce = 50f;
    public float jumpForce = 500f;

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        moveLeft = Input.GetKey("a");
        moveRight = Input.GetKey("d");
        jump = Input.GetKeyDown("space");
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce);
        // transform.Translate(Vector3.forward / (forwardForce /10));
        if (moveLeft)
            rb.AddForce(-lateralForce, 0, 0, ForceMode.VelocityChange);
        if (moveRight)
            rb.AddForce(lateralForce, 0, 0, ForceMode.VelocityChange);
        if (jump)
            rb.AddForce(0, jumpForce, 0);
        if (rb.position.y < -1)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }
}
