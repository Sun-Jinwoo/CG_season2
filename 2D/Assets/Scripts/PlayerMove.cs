using UnityEngine;

public class PlayerMove : MonoBehaviour
{

    private Rigidbody2D _Rigidbody2D;
    public float Speed = 5f;
    public float horizonta;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       float horizontal = Input.GetAxisRaw("Horizontal");
       //  float vertical = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
       // _Rigidbody2D.Velocity = new Vector2(horizonta * Speed, _Rigidbody2D.Velocity.y);
         float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
         Vector2 direction = new Vector2(horizontal, 0f).normalized;
        _Rigidbody2D.linearVelocity = direction * 5f;
    }
}
