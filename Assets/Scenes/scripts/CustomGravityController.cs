using UnityEngine;

public class CustomGravityController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    [SerializeField]
    private Vector2 gravityDirection = Vector2.down;
    
    [SerializeField]
    private float gravityForce = 9.81f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f; // 通常の重力を無効化
    }
    
    void FixedUpdate()
    {
        // カスタム重力を適用
        rb.AddForce(gravityDirection.normalized * gravityForce, ForceMode2D.Force);
    }
}