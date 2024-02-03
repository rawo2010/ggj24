using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveLeft : MonoBehaviour, IDistancable
{
    //è„îºêg
    [SerializeField] HingeJoint2D armRight;
    [SerializeField] HingeJoint2D armLeft;
    private JointMotor2D armRightMotor;
    private JointMotor2D armLeftMotor;

    //Gun
    [SerializeField] HingeJoint2D gun;
    private JointMotor2D gunMotor;

    //â∫îºêg
    [SerializeField] HingeJoint2D legRight;
    [SerializeField] HingeJoint2D legLeft;
    private JointMotor2D legRightMotor;
    private JointMotor2D legLeftMotor;


    [SerializeField] float hingeSpeed;
    [SerializeField] GameClear gameClear;

    [SerializeField] AudioSource hitAudioSource;
    [SerializeField] AudioClip hitSE;

    bool isDistance;

    public bool GetIsDistance
    {
        get { return isDistance; }
    }

    private void Awake()
    {
        //è„îºêg
        armRight.useMotor = false;
        armLeft.useMotor = false;

        //Gun
        gun.useMotor = false;

        //â∫îºêg
        legRight.useMotor = false;
        legLeft.useMotor = false;

        isDistance = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        //è„îºêg
        armRightMotor = armRight.motor;
        armLeftMotor = armLeft.motor;

        //Gun
        gunMotor = gun.motor;

        //â∫îºêg
        legRightMotor = legRight.motor;
        legLeftMotor = legLeft.motor;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        //ç∂ãr
        if (Input.GetKey(KeyCode.K))
        {
            legLeft.useMotor = true;
            legLeftMotor.motorSpeed = hingeSpeed;
            legLeft.motor = legLeftMotor;
        }
        else
        {
            legLeft.useMotor = false;
        }

        //âEãr
        if (Input.GetKey(KeyCode.J))
        {
            legRight.useMotor = true;
            legRightMotor.motorSpeed = -hingeSpeed;
            legRight.motor = legRightMotor;
        }
        else
        {
            legRight.useMotor = false;
        }

        //ç∂òr
        if (Input.GetKey(KeyCode.O))
        {
            armLeft.useMotor = true;
            armLeftMotor.motorSpeed = hingeSpeed;
            armLeft.motor = armLeftMotor;
        }
        else
        {
            armLeft.useMotor = false;
        }

        //âEòr
        if (Input.GetKey(KeyCode.U))
        {
            armRight.useMotor = true;
            armRightMotor.motorSpeed = hingeSpeed;
            armRight.motor = armRightMotor;
        }
        else
        {
            armRight.useMotor = false;
        }

        //èe
        if (Input.GetKey(KeyCode.I))
        {
            gun.useMotor = true;

            if (Input.GetKey(KeyCode.Space))
            {
                gunMotor.motorSpeed = -hingeSpeed;
            }
            else
            {
                gunMotor.motorSpeed = hingeSpeed;
            }

            gun.motor = gunMotor;
        }
        else
        {
            gun.useMotor = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameClear.getIsGameClear())
        {
            return;
        }

        if (collision.tag == "GunGetAreaLeft")
        {
            isDistance = true;
        }

        if (collision.gameObject.tag == "bullet")
        {
            var script = collision.gameObject.GetComponent<GunMove>();
            if (script.GetOwner == "RightPlayer")
            {
                gameClear.setWinnerName("1P");
                gameClear.setIsGameClear(true);
                hitAudioSource.PlayOneShot(hitSE);
                Destroy(collision.gameObject);
                Debug.Log("ìñÇΩÇ¡ÇΩ(1PÇÃèüóò)");

                // îöî≠.
                transform.parent.Bomb();
            }
        }
    }

    bool IDistancable.GetIsDistance()
    {
        return isDistance;
    }
}
