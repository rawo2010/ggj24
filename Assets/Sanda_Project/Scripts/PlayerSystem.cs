using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    // Playerに付けるスクリプト

    [SerializeField]
    private Text instructionText; // 指示の文字
    [SerializeField, Header("playerへの指示の文字")]
    private string firstInstruction;
    [SerializeField]
    private string SecondInstruction;
    [SerializeField]
    private string thirdInstruction;

    private bool isDistance; // 3歩離れたか

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

    // Player側で初期値より、〇〇離れたらtrueにする処理
    public void SetIsDistance(bool _isDistance)
    {
        isDistance = _isDistance;
    }
}