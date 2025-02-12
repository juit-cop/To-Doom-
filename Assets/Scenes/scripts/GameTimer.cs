using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public Text timerText; // UIのテキスト（タイマー表示）
    private float elapsedTime = 0f;
    private bool isTiming = false;

    public static GameTimer instance; // シングルトン（他のスクリプトからアクセスしやすくする）

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        if (isTiming)
        {
            elapsedTime += Time.deltaTime;
            timerText.text = $"Time: {elapsedTime:F2} sec"; // 小数点2桁で表示
        }
    }

    public void StartTimer()
    {
        isTiming = true;
        elapsedTime = 0f;
        Debug.Log("タイマー開始");
    }

    public void StopTimer()
    {
        isTiming = false;
        ShowResult();
    }

    void ShowResult()
    {
        timerText.text = $"Final Time: {elapsedTime:F2} sec"; // 最終タイム表示
    }
}
