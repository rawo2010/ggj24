using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class timer : MonoBehaviour
{
    private float countUp;
    [SerializeField]
    private Text timeText;
    [SerializeField]
    private GameClear gameClear;


    private void FixedUpdate()
    {
        if(!gameClear.getIsGameClear())
        {
            countUp += Time.deltaTime;
            timeText.text = countUp.ToString("f2") + "•b";
        }
        else
        {
            timeText.text = countUp.ToString("f2") + "•b";
        }
    }
}
