using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    // Player�ɕt����X�N���v�g

    [SerializeField]
    private Text instructionText; // �w���̕���
    [SerializeField, Header("player�ւ̎w���̕���")]
    private string firstInstruction;
    [SerializeField]
    private string SecondInstruction;
    [SerializeField]
    private string thirdInstruction;

    private bool isDistance; // 3�����ꂽ��

    void Start()
    {
        instructionText.text = firstInstruction;
    }

    private void Update()
    {
        if (isDistance)
        {
            instructionText.text = thirdInstruction;
        }
    }

    // Player���ŏ����l���A�Z�Z���ꂽ��true�ɂ��鏈��
    public void SetIsDistance(bool _isDistance)
    {
        isDistance = _isDistance;
    }
}