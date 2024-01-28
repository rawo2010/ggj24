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
        // ��]�̖ڕW�l�i��Ƃ���y���𒆐S��90�x��]�j
        Vector3 targetRotation = new Vector3(0f, -810f, 0f);

        // ���݂̉�]�l
        Vector3 currentRotation = transform.rotation.eulerAngles;

        // ��]�ɂ����鎞��
        float duration = 2f;

        // �o�ߎ���
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            // �C���^�[�|���[�V�����ŐV������]�l���v�Z
            Vector3 newRotation = Vector3.Lerp(currentRotation, targetRotation, elapsedTime / duration);

            // �I�u�W�F�N�g����]
            transform.rotation = Quaternion.Euler(newRotation);

            // �o�ߎ��Ԃ��X�V
            elapsedTime += Time.deltaTime;

            // 1�t���[���ҋ@
            yield return null;
        }

        // �ŏI�I�ȉ�]�l���Z�b�g�i�덷�␳�j
        transform.rotation = Quaternion.Euler(targetRotation);
    }
}
