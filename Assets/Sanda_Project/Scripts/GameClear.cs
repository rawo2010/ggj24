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

        // �����������l����
        // player1���擾���āA�擾�ł�����1P�̏����A
        // null���A���Ă���player1�������Ă�����2P�̏���
        // if���ŏ�����������winnerName��player1�Ȃǂ��

        gameClearText.enabled = true;  //�N���A�e�L�X�g�\��
        player1_text.enabled = false;
        player2_text.enabled = false;
        p1.enabled = false;
        p2.enabled = false;
        gameClearText.text = winnerName + "�̏���!!";

        isDisplayWinnerText = true;  //�����Ҍ���

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

        Debug.Log("winnerName�Z�b�g");
        winnerName = _winnerName;
    }

    private IEnumerator GameTitle()
    {
        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene("TitleScene");
    }

}
