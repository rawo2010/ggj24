using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerRight : MonoBehaviour
{
    [SerializeField] PlayerMoveRight body;

    [SerializeField] PlayerSystem playerSystem;
    [SerializeField] GameClear gameClear;
    [SerializeField] InGame InGame;

    [SerializeField] GameObject gun;
    [SerializeField] GameObject readyGun;
    [SerializeField] GameObject bullet;

    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip shotSE;

    bool isShot;
    bool isSetIsDistance;

    private float reloadtingTime = 0.0f;
    private const float INTERVAL = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        isShot = false;
        isSetIsDistance = false;

        this.Pause();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            this.Resume();
        }

        //弾発射
        if (!isShot && body.GetIsDistance == true)
        {
            reloadtingTime = Mathf.Clamp(
                reloadtingTime + Time.deltaTime, 0, INTERVAL);
            if (reloadtingTime < INTERVAL)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.S))
            {
                var go = Instantiate(bullet);

                var t = go.transform;
                
                var r = gun.transform.rotation.eulerAngles;
                r.z -= 27.0f;
                
                t.position = gun.transform.position;
                t.localEulerAngles = r;

                var script = go.GetComponent<GunMove>();
                script.SetOwner = "RightPlayer";
                isShot = false;
                audioSource.PlayOneShot(shotSE);  //効果音
                Debug.Log("弾発射" + r);

                reloadtingTime = 0.0f;  
            }
        }

        //撃てる範囲に到達したので、文字表示も変える
        if (!isSetIsDistance && body.GetIsDistance == true)
        {
            playerSystem.SetIsDistance(body.GetIsDistance);
            isSetIsDistance = true;
        }
    }
}
