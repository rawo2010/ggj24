using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveRight : MonoBehaviour
{
    //上半身
    [SerializeField] HingeJoint2D armRight;
    [SerializeField] HingeJoint2D armLeft;
    //[SerializeField] HingeJoint2D handRight;
    //[SerializeField] HingeJoint2D handLeft;
    private JointMotor2D armRightMotor;
    private JointMotor2D armLeftMotor;
    //private JointMotor2D handRightMotor;
    //private JointMotor2D handLeftMotor;

    //Gun
    [SerializeField] HingeJoint2D gun;
    private JointMotor2D gunMotor;

    //下半身
    [SerializeField] HingeJoint2D legRight;
    [SerializeField] HingeJoint2D legLeft;
    //[SerializeField] HingeJoint2D footRight;
    //[SerializeField] HingeJoint2D footLeft;
    private JointMotor2D legRightMotor;
    private JointMotor2D legLeftMotor;
    //private JointMotor2D footRightMotor;
    //private JointMotor2D footLeftMotor;



    //[SerializeField] private Rigidbody2D legRightRb;
    //[SerializeField] private Rigidbody2D legLeftRb;
    //[SerializeField] private Rigidbody2D footRightRb;
    //[SerializeField] private Rigidbody2D footLeftRb;

    [SerializeField] float hingeSpeed;
    [SerializeField] GameClear gameClear;

    [SerializeField] AudioSource moveAudioSource;
    [SerializeField] AudioSource hitAudioSource;
    [SerializeField] AudioClip moveSE;
    [SerializeField] AudioClip hitSE;

    [SerializeField]bool isDistance;  //距離をとったか？

    public bool GetIsDistance
    {
        get { return isDistance; }
    }
    private void Awake()
    {
        //上半身
        armRight.useMotor = false;
        armLeft.useMotor = false;
        //handRight.useMotor = false;
        //handLeft.useMotor = false;

        //Gun
        gun.useMotor = false;

        //下半身
        legRight.useMotor = false;
        legLeft.useMotor = false;
        //footRight.useMotor = false;
        //footLeft.useMotor = false;

        isDistance = false;

        // for debug.
        isDistance = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        //クリアしたら操作を受け付けない

        //上半身
        armRightMotor = armRight.motor;
        armLeftMotor = armLeft.motor;
        //handRightMotor = handRight.motor;
        //handLeftMotor = handLeft.motor;

        //Gun
        gunMotor = gun.motor;

        //下半身
        legRightMotor = legRight.motor;
        legLeftMotor = legLeft.motor;
        //footRightMotor = footRight.motor;
        //footLeftMotor = footLeft.motor;

        //footRightRb.simulated = false;
        //footLeftRb.simulated = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        //Shiftで逆回転
        //if (Input.GetKey(KeyCode.LeftShift))
        //{
        //    hingeSpeed *= -1.0f;
        //}

        //左脚
        if (Input.GetKey(KeyCode.D))
        {
            //footLeft.useMotor = false;

            legLeft.useMotor = true;
            legLeftMotor.motorSpeed = hingeSpeed;
            legLeft.motor = legLeftMotor;
        }
        else
        {
            legLeft.useMotor = false;
        }
        //else if(Input.GetKeyUp(KeyCode.D))
        //{
        //    legLeft.useMotor = false;

        //    footLeft.useMotor = true;
        //    footLeftMotor.motorSpeed = hingeSpeed * 100.0f;
        //    footLeft.motor = footLeftMotor;
        //}

        //右脚
        if (Input.GetKey(KeyCode.A))
        {
            //footRight.useMotor = false;

            legRight.useMotor = true;
            legRightMotor.motorSpeed = -hingeSpeed;
            legRight.motor = legRightMotor;
        }
        else
        {
            legRight.useMotor = false;
        }
        //else if(Input.GetKey(KeyCode.A))
        //{
        //    legRight.useMotor = false;

        //    footRight.useMotor = true;
        //    footRightMotor.motorSpeed = hingeSpeed * 100.0f;
        //    footRight.motor = footRightMotor;
        //}

        //左腕
        if (Input.GetKey(KeyCode.E))
        {
            armLeft.useMotor = true;

            armLeftMotor.motorSpeed = -hingeSpeed;
            //armLeftMotor.motorSpeed = hingeSpeed;

            armLeft.motor = armLeftMotor;
        }
        else
        {
            armLeft.useMotor = false;
        }

        //右腕
        if (Input.GetKey(KeyCode.Q))
        {
            armRight.useMotor = true;

            armRightMotor.motorSpeed = -hingeSpeed;
            //armRightMotor.motorSpeed = -hingeSpeed;

            armRight.motor = armRightMotor;
        }
        else
        {
            armRight.useMotor = false;
        }

        //銃
        if (Input.GetKey(KeyCode.W))
        {
            gun.useMotor = true;

            if (Input.GetKey(KeyCode.LeftShift))
            {
                gunMotor.motorSpeed = -hingeSpeed;
            }
            else
            {
                gunMotor.motorSpeed = hingeSpeed;
                //gunMotor.motorSpeed = hingeSpeed;
            }

            gun.motor = gunMotor;
        }
        else
        {
            gun.useMotor = false;
        }


        //元に戻す
        //if(hingeSpeed < 0.0f)
        //{
        //    hingeSpeed *= -1.0f;
        //}



        ////脚
        //if (Input.GetKey(KeyCode.D))
        //{
        //    legRight.useMotor = true;
        //    legLeft.useMotor = true;

        //    legRightMotor.motorSpeed = -hingeSpeed;
        //    legLeftMotor.motorSpeed = hingeSpeed;

        //    legRight.motor = legRightMotor;
        //    legLeft.motor = legLeftMotor;
        //}
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    legRight.useMotor = true;
        //    legLeft.useMotor = true;

        //    legRightMotor.motorSpeed = hingeSpeed;
        //    legLeftMotor.motorSpeed = -hingeSpeed;

        //    legRight.motor = legRightMotor;
        //    legLeft.motor = legLeftMotor;
        //}
        //else
        //{
        //    legRight.useMotor = false;
        //    legLeft.useMotor = false;

        //    legRight.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 0 };
        //    legLeft.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 0 };
        //}

        ////足
        //if (Input.GetKey(KeyCode.C))
        //{
        //    footRight.useMotor = true;
        //    footLeft.useMotor = true;

        //    footRightMotor.motorSpeed = -hingeSpeed;
        //    footLeftMotor.motorSpeed = hingeSpeed;

        //    footRight.motor = footRightMotor;
        //    footLeft.motor = footLeftMotor;
        //}
        //else if (Input.GetKey(KeyCode.Z))
        //{
        //    footRight.useMotor = true;
        //    footLeft.useMotor = true;

        //    footRightMotor.motorSpeed = hingeSpeed;
        //    footLeftMotor.motorSpeed = -hingeSpeed;

        //    footRight.motor = footRightMotor;
        //    footLeft.motor = footLeftMotor;
        //}
        //else
        //{
        //    footRight.useMotor = false;
        //    footLeft.useMotor = false;

        //    Debug.Log("foot無効化");

        //    footRight.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 0 };
        //    footLeft.motor = new JointMotor2D { motorSpeed = 0, maxMotorTorque = 0 };
        //}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        if (collision.tag == "GunGetAreaRight")
        {
            isDistance = true;
            Debug.Log("右当たった");
        }

        if (collision.gameObject.tag == "bullet")
        {
            var script = collision.gameObject.GetComponent<GunMove>();
            if (script.GetOwner == "LeftPlayer")
            {
                gameClear.setWinnerName("2P");
                gameClear.setIsGameClear(true);
                hitAudioSource.PlayOneShot(hitSE);
                Destroy(collision.gameObject);
                Debug.Log("当たった(2Pの勝利)");
            }
        }
    }
}
