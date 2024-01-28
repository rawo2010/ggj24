using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerSystem : MonoBehaviour
{
    // Player�ɕt����X�N���v�g

    //private GameStart gameStart;
    [SerializeField]
    private Text instructionText; // �w���̕���
    [SerializeField, Header("player�ւ̎w���̕���")]
    private string firstInstruction;
    [SerializeField]
    private string SecondInstruction;
    [SerializeField]
    private string thirdInstruction;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip instructionSE;

    private bool isDistance; // 3�����ꂽ��
    //private bool isGetWeapon; // ������������Ă��邩

    void Start()
    {
        //gameStart = GetComponent<GameStart>();
        instructionText.text = firstInstruction;
        audioSource.PlayOneShot(instructionSE);
    }

    private void Update()
    {
        //�G�X�P�[�v�L�[�Ń^�C�g���V�[���ɖ߂�
        //if (Input.GetKey(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("TitleScene");
        //}

        // �󋵂ɉ����ĕ\��������ς���
        //if (isGetWeapon)
        //{
        //    instructionText.text = thirdInstruction;
        //}
        if (isDistance)
        {
            instructionText.text = thirdInstruction;
            audioSource.PlayOneShot(instructionSE);
        }

        //// �󋵂ɉ����ĕ\��������ς���
        //if (isGetWeapon)
        //{
        //    instructionText.text = thirdInstruction;
        //}
        //else if (isDistance)
        //{
        //    instructionText.text = SecondInstruction;
        //}
    }

    // Player���ŏ����l���A�Z�Z���ꂽ��true�ɂ��鏈��
    public void SetIsDistance(bool _isDistance)
    {
        isDistance = _isDistance;
    }
}


//public class PlayerSystem : MonoBehaviour
//{
//    // Player�ɕt����X�N���v�g

//    private GameStart gameStart;
//    [SerializeField]
//    private Text instructionText; // �w���̕���
//    [SerializeField, Header("player�ւ̎w���̕���")]
//    private string firstInstruction;
//    [SerializeField]
//    private string SecondInstruction;
//    [SerializeField]
//    private string thirdInstruction;

//    private bool isDistance; // 3�����ꂽ��
//    private bool isGetWeapon; // ������������Ă��邩

//    void Start()
//    {
//        gameStart = GetComponent<GameStart>();
//        instructionText.text = "";
//    }

//    private void Update()
//    {
//        if(gameStart.GetIsGameStart())
//        {
//            // �Q�[�����ɃG�X�P�[�v�L�[��������
//            // �|�[�Y�ƃ^�C�g���֖߂�����

//        }

//        // �󋵂ɉ����ĕ\��������ς���
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
//        // �����A3������Ă��Ȃ���Γ��肵�Ȃ�
//        if (!isDistance) return;

//        // �����������C���[��Weapon�̏ꍇ
//        if (other.gameObject.layer == LayerMask.NameToLayer("Weapon"))
//        {
//            // player���e�����
//            isGetWeapon = true;
//        }
//    }

//    // Player���ŏ����l���A�Z�Z���ꂽ��true�ɂ��鏈��
//    public void SetIsDistance(bool _isDistance)
//    {
//        isDistance = _isDistance;
//    }
//}
