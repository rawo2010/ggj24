using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerLeft : MonoBehaviour
{
    [SerializeField] PlayerMoveLeft body;

    [SerializeField] PlayerSystem playerSystem;
    [SerializeField] GameClear gameClear;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject readyGun;
    [SerializeField] GameObject bullet;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSE;

    //bool isChangeGun;
    bool isShot;
    bool isSetIsDistance;

    private float reloadtingTime = 0.0f;
    private const float INTERVAL = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        //gun.SetActive(false);
        //readyGun.SetActive(true);

        //isChangeGun = false;
        isShot = false;
        isSetIsDistance = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        //�e����
        if (!isShot && body.GetIsDistance == true)
        {
            reloadtingTime = Mathf.Clamp(
                reloadtingTime + Time.deltaTime, 0, INTERVAL);
            if (reloadtingTime < INTERVAL)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.K))
            {
                var go = Instantiate(bullet);

                var t = go.transform;

                var r = gun.transform.rotation.eulerAngles;
                r.z -= 27.0f;

                t.position = gun.transform.position;
                t.localEulerAngles = r;

                var script = go.GetComponent<GunMove>();
                script.SetOwner = "LeftPlayer";
                isShot = false;
                audioSource.PlayOneShot(shotSE);  //���ʉ�
                Debug.Log("�e����");

                reloadtingTime = 0.0f;
            }
        }

        //���Ă�͈͂ɓ��B�����̂ŁA�����\�����ς���
        if(!isSetIsDistance && body.GetIsDistance == true)
        {
            playerSystem.SetIsDistance(body.GetIsDistance);
            isSetIsDistance = true;
        }

        ////�e�̓���ւ�
        //if (!isChangeGun && body.GetIsGetGun == true)
        //{
        //    gun.SetActive(true);
        //    readyGun.SetActive(false);

        //    isChangeGun = true;
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if(collision.gameObject.tag == "bullet")
    //    {
    //        var script = collision.gameObject.GetComponent<GunMove>();
    //        if (script.GetOwner == "RightPlayer")
    //        {
    //            gameClear.setWinnerName("1P");
    //            gameClear.setIsGameClear(true);
    //            Destroy(collision.gameObject);
    //            Debug.Log("��������(1P�̏���)");
    //        }
    //    }
    //}
}
