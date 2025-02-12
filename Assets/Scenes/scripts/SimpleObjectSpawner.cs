using UnityEngine;
using System.Collections;

public class SimpleObjectSpawner : MonoBehaviour
{
    [Header("生成するオブジェクト")]
    [SerializeField] private GameObject[] objectPrefabs; // 4種類のプレハブを格納

    [Header("生成位置設定")]
    [SerializeField] private float minX = -4f;  // X座標の最小値
    [SerializeField] private float maxX = 3f;   // X座標の最大値
    [SerializeField] private float fixedY = 11f; // 固定Y座標

    [Header("タイミング設定")]
    [SerializeField] private float initialDelay = 8f;    // 開始までの待機時間（秒）
    [SerializeField] private float spawnInterval = 0.02f; // 生成間隔（秒）

    private void Start()
    {
        // 8秒待ってからスポーン開始
        StartCoroutine(DelayedSpawnStart());
    }

    private IEnumerator DelayedSpawnStart()
    {
        // 初期待機時間
        yield return new WaitForSeconds(initialDelay);
        
        // 待機後にスポーン開始
        StartCoroutine(SpawnRoutine());
    }

    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            // ランダムなX座標を計算
            float randomX = Random.Range(minX, maxX);
            
            // スポーン位置を設定（Y座標は固定）
            Vector3 spawnPosition = new Vector3(randomX, fixedY, 0f);
            
            // 4種類のオブジェクトからランダムに1つ選択
            int randomIndex = Random.Range(0, objectPrefabs.Length);
            
            // オブジェクトを生成
            Instantiate(objectPrefabs[randomIndex], spawnPosition, Quaternion.identity);
            
            // 次の生成までの待機
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    // スポーン範囲をScene viewで可視化
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        // スポーン可能なライン範囲を描画
        Gizmos.DrawLine(
            new Vector3(minX, fixedY, 0),
            new Vector3(maxX, fixedY, 0)
        );
        
        // 範囲の端を示すマーカー
        Gizmos.DrawSphere(new Vector3(minX, fixedY, 0), 0.2f);
        Gizmos.DrawSphere(new Vector3(maxX, fixedY, 0), 0.2f);
    }
}