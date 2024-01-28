using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class InGame : MonoBehaviour
{
    [SerializeField]
    private string sceneName; // �^�C�g����ʂ̃V�[��
    [SerializeField]
    private GameObject menuDisplay;
    [SerializeField]
    private Text gameStartText;
    private float alpha = 1f;
    private bool isPlayerOperation;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay.SetActive(true);
            Time.timeScale = 0f; // �Q�[�������Ԓ�~
        }

        if (alpha < 0f)
        {
            isPlayerOperation = true;
        }
        else
        {
            gameStartText.color = new Color(0, 0, 0, alpha);
            alpha -= Time.deltaTime / 2;
            isPlayerOperation = false;
        }
    }

    public void backGame()
    {
        menuDisplay.SetActive(false);
        Time.timeScale = 1f; // �ĊJ
    }

    // ���j���[�̋@�\�^�C�g���֖߂�
    // MenuDisplay��title��
    public void ToMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

    public bool getPlayerOperation()
    {
        return isPlayerOperation;
    }
}
