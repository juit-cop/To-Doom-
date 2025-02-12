using UnityEngine;

public class BGMPlayer : MonoBehaviour
{
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.loop = true; // ループ再生
            audioSource.Play();
        }
    }
}
