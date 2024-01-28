using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameClear : MonoBehaviour
{
    [SerializeField] Text gameClearText;
    [SerializeField] Text player1_text;
    [SerializeField] Text player2_text;
    [SerializeField] Text p1;
    [SerializeField] Text p2;
    [SerializeField]
    private string winnerName;

    private bool isGameClear;

    private bool isDisplayWinnerText;

    private void Start()
    {
        winnerName = null;
        isGameClear = false;
        isDisplayWinnerText = false;

        gameClearText.enabled = false;
    }

    private void Update()
    {
        if (!isGameClear) return;

        if (isDisplayWinnerText) return;

        // 勝利条件を考える
        // player1を取得して、取得できたら1Pの勝利、
        // nullが帰ってきてplayer1が消えていたら2Pの勝利
        // if文で勝利した側にwinnerNameにplayer1などを代

        gameClearText.enabled = true;  //クリアテキスト表示
        player1_text.enabled = false;
        player2_text.enabled = false;
        p1.enabled = false;
        p2.enabled = false;
        gameClearText.text = winnerName + "の勝利!!";

        isDisplayWinnerText = true;  //勝利者決定

        StartCoroutine(GameTitle());
    }

    public void setIsGameClear(bool _isGameClear)
    {
        isGameClear = _isGameClear;
    }

    public bool getIsGameClear()
    {
        return isGameClear;
    }

    public void setWinnerName(string _winnerName)
    {
        if (winnerName != null)
        {
            return;
        }

        Debug.Log("winnerNameセット");
        winnerName = _winnerName;
    }

    private IEnumerator GameTitle()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("TitleScene");
    }

}
