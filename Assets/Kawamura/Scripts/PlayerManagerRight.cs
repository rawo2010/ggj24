using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerRight : MonoBehaviour
{
    [SerializeField] PlayerMoveRight body;

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

        //弾発射
        if (!isShot && body.GetIsDistance == true)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                Vector3 euler = new Vector3(
                    0.0f,
                    0.0f,
                    gun.transform.localEulerAngles.z - 20.0f);
                var go = Instantiate(bullet, gun.transform.position, Quaternion.Euler(euler));


                //var go = Instantiate(bullet, gun.transform.position, Quaternion.identity);
                //var go = Instantiate(bullet, gun.transform.position, gun.transform.rotation);
                var script = go.GetComponent<GunMove>();
                script.SetOwner = "RightPlayer";
                isShot = false;
                audioSource.PlayOneShot(shotSE);  //効果音
                Debug.Log("弾発射");
            }
        }

        //撃てる範囲に到達したので、文字表示も変える
        if (!isSetIsDistance && body.GetIsDistance == true)
        {
            playerSystem.SetIsDistance(body.GetIsDistance);
            isSetIsDistance = true;
        }

        ////銃の入れ替え
        //if (!isChangeGun && body.GetIsGetGun == true)
        //{
        //    gun.SetActive(true);
        //    readyGun.SetActive(false);

        //    isChangeGun = true;
        //}
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "bullet")
    //    {
    //        var script = collision.gameObject.GetComponent<GunMove>();
    //        if (script.GetOwner == "LeftPlayer")
    //        {
    //            gameClear.setWinnerName("2P");
    //            gameClear.setIsGameClear(true);
    //            Destroy(collision.gameObject);
    //            Debug.Log("当たった(2Pの勝利)");
    //        }
    //    }
    //}
}
