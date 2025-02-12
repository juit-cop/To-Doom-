using UnityEngine;

public class TargetDestroyer : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile")) // 弾が当たったとき
        {
            Destroy(gameObject);

            if (FindObjectsOfType<TargetDestroyer>().Length == 1) // 最後のターゲットなら
            {
                GameTimer.instance.StopTimer(); // タイマー停止
            }
        }
    }
}
