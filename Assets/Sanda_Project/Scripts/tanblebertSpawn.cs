using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class tanblebertSpawn : MonoBehaviour
{
    private int randonCnt;
    private int randomInt;
    private int randomDir;

    [SerializeField]
    private GameObject leftTanblebert;
    [SerializeField]
    private GameObject rightTanblebert;

    private void Start()
    {
        // 10����15�̃����_���l�擾
        randomInt = Random.Range(10, 15);
        randomDir = Random.Range(0, 1);
        randonCnt = 60;
    }

    private void FixedUpdate()
    {
        randonCnt--;
        if(randonCnt <= 0)
        {
            // 1�b60�t���[���Ȃ̂�
            randomInt--;
            randonCnt = 60;
        }

        if (randomInt >= 0) return;

        // �����烊�X�|�[��
        if(randomDir == 0)
        {
            Instantiate(leftTanblebert, new Vector3(12, -2.97f, 0), Quaternion.identity);
        }
        else
        {
            //�E���烊�X�|�[��
            Instantiate(rightTanblebert, new Vector3(-12, -2.97f, 0), Quaternion.identity);
        }

        randomInt = Random.Range(10, 15);
        randomDir = Random.Range(0, 2);
        Debug.Log(randomDir);
    }
}
