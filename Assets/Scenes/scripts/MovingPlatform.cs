using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float moveDistance = 2f;  // 上下の移動距離
    public float moveSpeed = 2f;     // 移動速度
    public float waitTime = 1f;      // 待機時間

    private Vector3 startPos;
    private Vector3 targetPos;
    private bool movingUp = true;
    private float waitTimer = 0f;

    void Start()
    {
        startPos = transform.position;
        targetPos = startPos + Vector3.up * moveDistance;
    }

    void Update()
    {
        if (waitTimer > 0)
        {
            waitTimer -= Time.deltaTime;
            return;
        }

        // 移動処理
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);

        // 目標地点に到達したら方向を変更して待機
        if (Vector3.Distance(transform.position, targetPos) < 0.01f)
        {
            movingUp = !movingUp;
            targetPos = movingUp ? startPos + Vector3.up * moveDistance : startPos;
            waitTimer = waitTime;
        }
    }
}
