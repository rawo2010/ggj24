using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    // Playerに付けるスクリプト

    //private GameStart gameStart;
    [SerializeField]
    private Text instructionText; // 指示の文字
    [SerializeField, Header("playerへの指示の文字")]
    private string firstInstruction;
    [SerializeField]
    private string SecondInstruction;
    [SerializeField]
    private string thirdInstruction;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip instructionSE;

    private bool isDistance; // 3歩離れたか
    //private bool isGetWeapon; // 武器を所持しているか

    void Start()
    {
        //gameStart = GetComponent<GameStart>();
        instructionText.text = firstInstruction;
        audioSource.PlayOneShot(instructionSE);
    }

    private void Update()
    {
        //エスケープキーでタイトルシーンに戻る
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("TitleScene");
        //}

        // 状況に応じて表示文字を変える
        //if (isGetWeapon)
        //{
        //    instructionText.text = thirdInstruction;
        //}
        if (isDistance)
        {
            instructionText.text = thirdInstruction;
            audioSource.PlayOneShot(instructionSE);
        }

        //// 状況に応じて表示文字を変える
        //if (isGetWeapon)
        //{
        //    instructionText.text = thirdInstruction;
        //}
        //else if (isDistance)
        //{
        //    instructionText.text = SecondInstruction;
        //}
    }

    // Player側で初期値より、〇〇離れたらtrueにする処理
    public void SetIsDistance(bool _isDistance)
    {
        isDistance = _isDistance;
    }
}


//public class PlayerSystem : MonoBehaviour
//{
//    // Playerに付けるスクリプト

//    private GameStart gameStart;
//    [SerializeField]
//    private Text instructionText; // 指示の文字
//    [SerializeField, Header("playerへの指示の文字")]
//    private string firstInstruction;
//    [SerializeField]
//    private string SecondInstruction;
//    [SerializeField]
//    private string thirdInstruction;

//    private bool isDistance; // 3歩離れたか
//    private bool isGetWeapon; // 武器を所持しているか

//    void Start()
//    {
//        gameStart = GetComponent<GameStart>();
//        instructionText.text = "";
//    }

//    private void Update()
//    {
//        if(gameStart.GetIsGameStart())
//        {
//            // ゲーム中にエスケープキー押したら
//            // ポーズとタイトルへ戻るを作る

//        }

//        // 状況に応じて表示文字を変える
//        if (isGetWeapon)
//        {
//            instructionText.text = thirdInstruction;
//        }
//        else if (isDistance)
//        {
//            instructionText.text = SecondInstruction;
//        }
//        else if (gameStart.GetIsGameStart())
//        {
//            instructionText.text = firstInstruction;
//        }
//    }

//    private void OnTriggerEnter(Collider other)
//    {
//        // もし、3歩離れていなければ入手しない
//        if (!isDistance) return;

//        // 当たったレイヤーがWeaponの場合
//        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon"))
//        {
//            // playerが銃を入手
//            isGetWeapon = true;
//        }
//    }

//    // Player側で初期値より、〇〇離れたらtrueにする処理
//    public void SetIsDistance(bool _isDistance)
//    {
//        isDistance = _isDistance;
//    }
//}
