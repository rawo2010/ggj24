using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InGame : MonoBehaviour
{
    [SerializeField]
    private string sceneName; // タイトル画面のシーン
    [SerializeField]
    private GameObject menuDisplay;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            menuDisplay.SetActive(true);
            Time.timeScale = 0f; // ゲーム内時間停止
        }
    }

    public void backGame()
    {
        menuDisplay.SetActive(false);
        Time.timeScale = 1f; // 再開
    }

    // メニューの機能タイトルへ戻る
    // MenuDisplayのtitleを
    public void ToMenu()
    {
        SceneManager.LoadScene(sceneName);
    }

}
