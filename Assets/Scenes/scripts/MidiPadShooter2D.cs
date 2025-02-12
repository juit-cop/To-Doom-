using UnityEngine;
using MidiJack;

public class MidiPadShooter2D : MonoBehaviour
{
    public GameObject[] projectilePrefabs; // 4種類の物体プレハブ
    public Transform playerTransform; // プレイヤーのTransform
    public Vector2 spawnOffset = new Vector2(0f, 0f); // プレイヤーからの相対位置
    public float minForceX = 2f;
    public float maxForceX = 5f;
    public float[] yForceMultipliers = { 0.1f, 0.3f, 0.6f, 1.2f };
    public float destroyDelay = 3f;

    private float lastShotTime = -1f;
    public float shotCooldown = 0.2f;

    private void OnEnable()
    {
        MidiMaster.noteOnDelegate += NoteOn;
    }

    private void OnDisable()
    {
        MidiMaster.noteOnDelegate -= NoteOn;
    }

    private void NoteOn(MidiChannel channel, int note, float velocity)
    {
        if (Time.time - lastShotTime < shotCooldown) return;
        lastShotTime = Time.time;
        if (velocity == 0) return;

        int typeIndex = GetProjectileType(note);
        if (typeIndex == -1 || typeIndex >= projectilePrefabs.Length) return;

        // プレイヤーの位置 + オフセットを射出位置とする
        Vector2 spawnPosition = (Vector2)playerTransform.position + spawnOffset;

        GameObject projectile = Instantiate(projectilePrefabs[typeIndex], spawnPosition, Quaternion.identity);
        projectile.AddComponent<ProjectileDestroyer>();

        float forceX = Mathf.Lerp(minForceX, maxForceX, velocity);
        float forceY = forceX * yForceMultipliers[typeIndex];

        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(new Vector2(forceX, forceY), ForceMode2D.Impulse);
        }

        Destroy(projectile, destroyDelay);
    }

    private int GetProjectileType(int note)
    {
        if (note >= 36 && note <= 51) return 0;
        if (note >= 52 && note <= 67) return 1;
        if (note >= 68 && note <= 83) return 2;
        if (note >= 84 && note <= 99) return 3;
        return -1;
    }
}
