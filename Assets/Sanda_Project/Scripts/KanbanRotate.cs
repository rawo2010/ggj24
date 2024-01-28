using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KanbanRotate : MonoBehaviour
{
    public void RatateStart()
    {
        StartCoroutine(Ratate());
    }

    private IEnumerator Ratate()
    {
        // 回転の目標値（例としてy軸を中心に90度回転）
        Vector3 targetRotation = new Vector3(0f, -810f, 0f);

        // 現在の回転値
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // 回転にかかる時間
        float duration = 2f;

        // 経過時間
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // インターポレーションで新しい回転値を計算
            Vector3 newRotation = Vector3.Lerp(currentRotation, targetRotation, elapsedTime / duration);

            // オブジェクトを回転
            transform.rotation = Quaternion.Euler(newRotation);

            // 経過時間を更新
            elapsedTime += Time.deltaTime;

            // 1フレーム待機
            yield return null;
        }

        // 最終的な回転値をセット（誤差補正）
        transform.rotation = Quaternion.Euler(targetRotation);
    }
}
