////using UnityEngine;

////public class PlayerMove : MonoBehaviour
////{

////    private Rigidbody2D _Rigidbody2D;
////    public float Speed = 5f;
////    public float horizonta;
////    // Start is called once before the first execution of Update after the MonoBehaviour is created
////    void Start()
////    {
////        _Rigidbody2D = GetComponent<Rigidbody2D>();
////    }


////    void Update()
////    {
////       float horizontal = Input.GetAxisRaw("Horizontal");
////       //  float vertical = Input.GetAxisRaw("Vertical");
////    }

////    private void FixedUpdate()
////    {
////       // _Rigidbody2D.Velocity = new Vector2(horizonta * Speed, _Rigidbody2D.Velocity.y);
////         float horizontal = Input.GetAxisRaw("Horizontal") * Time.deltaTime;
////        float vertical = Input.GetAxisRaw("Vertical") * Time.deltaTime;
////         Vector2 direction = new Vector2(horizontal, 0f).normalized;
////        _Rigidbody2D.linearVelocity = direction * 5f;
////    }
////}

//using UnityEngine;

//public class PlayerMove : MonoBehaviour
//{
//    // Componentes
//    private Rigidbody2D rb;
//    public Animator animator;

//    // Variables de movimiento
//    [SerializeField] private float moveSpeed = 5f;
//    [SerializeField] private float jumpForce = 10f;

//    // Variables de control
//    private float horizontalInput;
//    private bool isGrounded;

//    // Referencia al suelo
//    [SerializeField] private Transform groundCheck;
//    [SerializeField] private float checkRadius = 0.2f;
//    [SerializeField] private LayerMask groundLayer;

//    void Start()
//    {
//        // Obtener el componente Rigidbody2D
//        rb = GetComponent<Rigidbody2D>();
//    }

//    void Update()
//    {
//        // Obtener input horizontal
//        horizontalInput = Input.GetAxisRaw("Horizontal");

//        animator.SetFloat("Movement", Mathf.Abs(horizontalInput));

//        // Verificar si está en el suelo
//        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

//        // Salto
//        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
//        {
//            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
//        }
//    }

//    void FixedUpdate()
//    {
//        // Movimiento horizontal
//        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
//    }

//    // Visualización del círculo de verificación de suelo en el editor
//    void OnDrawGizmos()
//    {
//        if (groundCheck != null)
//        {
//            Gizmos.color = Color.red;
//            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
//        }
//    }
//}

using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Componentes
    private Rigidbody2D rb;
    public Animator animator;

    // Variables de movimiento
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;

    // Variables de control
    private float horizontalInput;
    private bool isGrounded;

    // Referencia al suelo
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float checkRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    void Start()
    {
        // Obtener el componente Rigidbody2D
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Obtener input horizontal
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // Actualizar animador
        animator.SetFloat("Movement", Mathf.Abs(horizontalInput));

        // Verificar si está en el suelo
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // Salto
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    void FixedUpdate()
    {
        // Movimiento horizontal
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    void OnDrawGizmos()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, checkRadius);
        }
    }
}
