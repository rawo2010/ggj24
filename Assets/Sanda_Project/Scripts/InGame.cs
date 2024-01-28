using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    [SerializeField]
    private string sceneName; // �^�C�g����ʂ̃V�[��
    [SerializeField]
    private GameObject menuDisplay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay.SetActive(true);
            Time.timeScale = 0f; // �Q�[�������Ԓ�~
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

}
