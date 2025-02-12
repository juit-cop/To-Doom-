using UnityEngine;

public class ProjectileDestroyer : MonoBehaviour
{
    public GameObject destroyEffect; // 爆発エフェクトのプレハブ
    public AudioClip bookHitSound;   // bookにヒットした時の音
    public AudioClip pcHitSound;    // pcにヒットした時の音
    private AudioSource audioSource;

    void Start()
    {
        // AudioSource を取得（オブジェクトにアタッチされている場合）
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            // AudioSource がない場合、自動的に追加
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 衝突したオブジェクトのタグに応じて音を変更
        if (other.CompareTag("book"))
        {
            // bookに当たった時
            Debug.Log($"Projectile が {other.gameObject.name} にヒット！");

            // book用の音を再生
            if (bookHitSound != null)
            {
                audioSource.PlayOneShot(bookHitSound);
            }

            // エフェクトを表示
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
            }

            // bookを削除
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("pc"))
        {
            // pcに当たった時
            Debug.Log($"Projectile がpcにヒット！");

            // pc用の音を再生
            if (pcHitSound != null)
            {
                audioSource.PlayOneShot(pcHitSound);
            }

            // エフェクトを表示
            if (destroyEffect != null)
            {
                Instantiate(destroyEffect, other.transform.position, Quaternion.identity);
            }

            // pcを削除（必要に応じて）
            Destroy(other.gameObject);
        }
    }
}
