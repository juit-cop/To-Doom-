using UnityEngine;
using MidiJack;

public class ProjectileSpawner : MonoBehaviour
{
    public GameObject[] projectilePrefabs; // 射出するオブジェクトの配列
    public Transform spawnPoint; // 生成位置（デフォルト: (x, y) = (-4, 6)）
    private bool hasShot = false; // 最初の射出を検出

    void Start()
    {
        if (spawnPoint == null)
        {
            spawnPoint = this.transform; // デフォルトでこのオブジェクトの位置
        }
    }

    void Update()
    {
        for (int note = 24; note <= 60; note++) // 例: MIDIノート範囲
        {
            if (MidiMaster.GetKeyDown(note)) // MIDIキーが押されたら
            {
                ShootProjectile(note);
            }
        }
    }

    void ShootProjectile(int note)
{
    int type = GetProjectileType(note);
    if (type >= 0 && type < projectilePrefabs.Length)
    {
        Instantiate(projectilePrefabs[type], spawnPoint.position, Quaternion.identity);

        if (!hasShot)
        {
            if (GameTimer.instance == null)
            {
                Debug.LogError("GameTimer.instance が null です！");
            }
            else
            {
                GameTimer.instance.StartTimer(); // タイマー開始
                Debug.Log("タイマー開始");
                hasShot = true;
            }
        }
    }
}


    int GetProjectileType(int note)
    {
        if (note >= 36 && note <= 51) return 0; // タイプ0
        if (note >= 52 && note <= 67) return 1; // タイプ1
        if (note >= 68 && note <= 73) return 2; // タイプ2
        if (note >= 74 && note <= 99) return 3; // タイプ3
        return -1; // 無効なノート
    }
}
