using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // レイヤーを生成して設定

    enum CustomLayers
    {
        PLAY = 8,
        EXPLSNSTION,
        CREDIT,
    }

    [SerializeField]
    private GameObject play_kanban; // Play看板
    [SerializeField]
    private GameObject expl_kanban; // 説明看板
    [SerializeField]
    private GameObject credit_kanban; // ｸﾚｼﾞｯﾄ看板

    [SerializeField]
    private GameObject play_kanban_ana; // 穴開いてるﾊﾞｰｼﾞｮﾝ
    [SerializeField]
    private GameObject expl_kanban_ana; 
    [SerializeField]
    private GameObject credit_kanban_ana;

    [SerializeField]
    private GameObject expl_image;
    [SerializeField]
    private GameObject credit_image;
    [SerializeField]
    private GameObject expl_Button;
    [SerializeField]
    private GameObject credit_Button;


    private KanbanRotate play_kanban_rotate; // 回転ｽｸﾘﾌﾟﾄ
    private KanbanRotate expl_kanban_rotate;
    private KanbanRotate credit_kanban_rotate;

    // 押した際のアニメーション中に
    // 割り込みされない用のフラグ
    private bool isplay; 
    private bool isexpl;
    private bool iscredit;

    void Start()
    {
        play_kanban_rotate = play_kanban_ana.GetComponent<KanbanRotate>();
        expl_kanban_rotate = expl_kanban_ana.GetComponent<KanbanRotate>();
        credit_kanban_rotate = credit_kanban_ana.GetComponent<KanbanRotate>();
    }

    private IEnumerator GameBegin()
    {
        yield return new WaitForSeconds(3f);

        play_kanban.SetActive(false);
        expl_kanban.SetActive(false);
        credit_kanban.SetActive(false);
        play_kanban_ana.SetActive(false);
        expl_kanban_ana.SetActive(false);
        credit_kanban_ana.SetActive(false);

        isplay = false;
        isexpl = false;
        iscredit = false;

        //ゲームシーンへ
        SceneManager.LoadScene("GameScene");
    }
    private IEnumerator ExplsnstionDisplay()
    {
        yield return new WaitForSeconds(3f);

        play_kanban.SetActive(false);
        expl_kanban.SetActive(false);
        credit_kanban.SetActive(false);
        play_kanban_ana.SetActive(false);
        expl_kanban_ana.SetActive(false);
        credit_kanban_ana.SetActive(false);

        isplay = false;
        isexpl = false;
        iscredit = false;

        expl_image.SetActive(true);
        expl_Button.SetActive(true);
    }

    private IEnumerator CreditDisplay()
    {
        yield return new WaitForSeconds(3f);

        play_kanban.SetActive(false);
        expl_kanban.SetActive(false);
        credit_kanban.SetActive(false);
        play_kanban_ana.SetActive(false);
        expl_kanban_ana.SetActive(false);
        credit_kanban_ana.SetActive(false);

        isplay = false;
        isexpl = false;
        iscredit = false;

        credit_image.SetActive(true);
        credit_Button.SetActive(true);
    }



    private void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // 当たったオブジェクトのレイヤーを取得
            int layer = hit.collider.gameObject.layer;

            // レイヤーによって処理を分岐
            switch ((CustomLayers)layer)
            {
                case CustomLayers.PLAY:
                    if (isplay) return;
                    if (isexpl) return;
                    if (iscredit) return;

                    if (Input.GetMouseButtonDown(0))
                    {
                        isplay = true;
                        play_kanban.SetActive(false);
                        play_kanban_ana.SetActive(true);
                        play_kanban_rotate.RatateStart();
                        StartCoroutine(GameBegin());
                    }
                    break;
                case CustomLayers.EXPLSNSTION:
                    if (isplay) return;
                    if (isexpl) return;
                    if (iscredit) return;

                    if (Input.GetMouseButtonDown(0))
                    {
                        isexpl = true;
                        expl_kanban.SetActive(false);
                        expl_kanban_ana.SetActive(true);
                        expl_kanban_rotate.RatateStart();
                        StartCoroutine(ExplsnstionDisplay());
                    }
                    break;
                case CustomLayers.CREDIT:
                    if (isplay) return;
                    if (isexpl) return;
                    if (iscredit) return;

                    if (Input.GetMouseButtonDown(0))
                    {
                        iscredit = true;
                        credit_kanban.SetActive(false);
                        credit_kanban_ana.SetActive(true);
                        credit_kanban_rotate.RatateStart();
                        StartCoroutine(CreditDisplay());
                    }
                    break;
            }
        }
    }

    // 説明からタイトルへ
    public void expltoTitle()
    {
        expl_image.SetActive(false);
        expl_Button.SetActive(false);

        play_kanban.SetActive(true);
        expl_kanban.SetActive(true);
        credit_kanban.SetActive(true);
    }

    // クレジットからタイトルへ
    public void credittoTitle()
    {
        credit_image.SetActive(false);
        credit_Button.SetActive(false);

        play_kanban.SetActive(true);
        expl_kanban.SetActive(true);
        credit_kanban.SetActive(true);
    }
}
