using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class InGame : MonoBehaviour
{
    [SerializeField]
    private string sceneName; // タイトル画面のシーン
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
            Time.timeScale = 0f; // ゲーム内時間停止
        }

        if (alpha < 0f)
        {
            isPlayerOperation = true;
        }
        else
        {
            // gameStartText.color = new Color(0, 0, 0, alpha);
            alpha -= Time.deltaTime / 2;
            isPlayerOperation = false;
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

    public bool getPlayerOperation()
    {
        return isPlayerOperation;
    }
}
