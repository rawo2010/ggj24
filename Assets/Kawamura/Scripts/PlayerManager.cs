using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField] PlayerSystem playerSystem;
    [SerializeField] GameClear gameClear;
    [SerializeField] InGame InGame;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject readyGun;
    [SerializeField] GameObject bullet;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSE;

    [SerializeField] private bool IsRightPlayer = true;

    KeyCode ShotKey => IsRightPlayer ?  KeyCode.S : KeyCode.K;

    string OnwerName => IsRightPlayer ? "RightPlayer" : "LeftPlayer";


    private IDistancable Distancable;



    //bool isChangeGun;
    bool isShot;
    bool isSetIsDistance;

    private float reloadtingTime = 0.0f;
    private const float INTERVAL = 0.8f;

    private void Awake()
    {
        this.Pause();
    }

    // Start is called before the first frame update
    void Start()
    {
        //gun.SetActive(false);
        //readyGun.SetActive(true);

        //isChangeGun = false;
        isShot = false;
        isSetIsDistance = false;

        StartCoroutine(WaitGameStart());
    }
    
    bool GetIsDistance()
    {
        if (Distancable == null)
        {
            Distancable = GetComponentInChildren<IDistancable>();
        }
        return Distancable.GetIsDistance();
    }

    private IEnumerator WaitGameStart()
    {
        yield return new WaitUntil(() => InGame.getPlayerOperation());

        this.Resume();

        yield return MainLoop();
    }

    private IEnumerator MainLoop()
    {
        while (true)
        {
            yield return null; 

            if (gameClear.getIsGameClear())
            {
                break;
            }

            //弾発射
            if (!isShot && GetIsDistance() == true)
            {
                reloadtingTime = Mathf.Clamp(
                    reloadtingTime + Time.deltaTime, 0, INTERVAL);
                if (reloadtingTime < INTERVAL)
                {
                    continue;
                }

                if (Input.GetKeyDown(ShotKey))
                {
                    var go = Instantiate(bullet);

                    var t = go.transform;

                    var r = gun.transform.rotation.eulerAngles;
                    r.z -= 27.0f;

                    t.position = gun.transform.position;
                    t.localEulerAngles = r;

                    var script = go.GetComponent<GunMove>();
                    script.SetOwner = OnwerName;
                    isShot = false;
                    audioSource.PlayOneShot(shotSE);  //効果音
                    Debug.Log("弾発射");

                    reloadtingTime = 0.0f;
                }
            }

            //撃てる範囲に到達したので、文字表示も変える
            if (!isSetIsDistance && GetIsDistance())
            {
                playerSystem.SetIsDistance(GetIsDistance());
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
    //            Debug.Log("当たった(1Pの勝利)");
    //        }
    //    }
    //}
}
