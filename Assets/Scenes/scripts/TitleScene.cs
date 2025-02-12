using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    void Start()
    {
        // 初期化処理（必要なら追加）
    }

    void Update()
    {
        // マウスクリックを検出
        if (Input.GetMouseButtonDown(0))
        {
            CheckClick();
        }
    }

    void CheckClick()
    {
        // マウスの位置を取得し、2D Raycast を飛ばす
        Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

        if (hit.collider != null && hit.collider.gameObject == gameObject)
        {
            // クリックされたオブジェクトがこのスクリプトのオブジェクトならシーン遷移
            ChangeScene();
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
