using UnityEngine;

public class PositionLock : MonoBehaviour
{
    [SerializeField]
    private Vector2 fixedPosition;

    [SerializeField]
    private float fixedRotation;

    [SerializeField]
    private bool lockX = true;
    
    [SerializeField]
    private bool lockY = true;

    [SerializeField]
    private bool lockRotation = true;

    void Update()
    {
        // 位置の固定
        Vector3 currentPosition = transform.position;
        Vector3 newPosition = currentPosition;

        if (lockX)
        {
            newPosition.x = fixedPosition.x;
        }
        
        if (lockY)
        {
            newPosition.y = fixedPosition.y;
        }

        transform.position = newPosition;

        // 回転の固定
        if (lockRotation)
        {
            transform.rotation = Quaternion.Euler(0, 0, fixedRotation);
        }
    }

    // エディタ上で現在の位置と回転を固定値として設定するための便利メソッド
    public void SetCurrentTransformAsFixed()
    {
        fixedPosition = transform.position;
        fixedRotation = transform.rotation.eulerAngles.z;
    }
}