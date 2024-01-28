using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    // ���C���[�𐶐����Đݒ�

    enum CustomLayers
    {
        PLAY = 8,
        EXPLSNSTION,
        CREDIT,
    }

    [SerializeField]
    private GameObject play_kanban; // Play�Ŕ�
    [SerializeField]
    private GameObject expl_kanban; // �����Ŕ�
    [SerializeField]
    private GameObject credit_kanban; // �ڼޯĊŔ�

    [SerializeField]
    private GameObject play_kanban_ana; // ���J���Ă��ް�ޮ�
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


    private KanbanRotate play_kanban_rotate; // ��]������
    private KanbanRotate expl_kanban_rotate;
    private KanbanRotate credit_kanban_rotate;

    // �������ۂ̃A�j���[�V��������
    // ���荞�݂���Ȃ��p�̃t���O
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

        //�Q�[���V�[����
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
            // ���������I�u�W�F�N�g�̃��C���[���擾
            int layer = hit.collider.gameObject.layer;

            // ���C���[�ɂ���ď����𕪊�
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

    // ��������^�C�g����
    public void expltoTitle()
    {
        expl_image.SetActive(false);
        expl_Button.SetActive(false);

        play_kanban.SetActive(true);
        expl_kanban.SetActive(true);
        credit_kanban.SetActive(true);
    }

    // �N���W�b�g����^�C�g����
    public void credittoTitle()
    {
        credit_image.SetActive(false);
        credit_Button.SetActive(false);

        play_kanban.SetActive(true);
        expl_kanban.SetActive(true);
        credit_kanban.SetActive(true);
    }
}
