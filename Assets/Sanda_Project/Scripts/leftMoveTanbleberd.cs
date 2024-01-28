using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class leftMoveTanbleberd : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private int destroyDelay = 5;
    [SerializeField]
    private float rotate = 1f;


    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    void Update()
    {
        transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        transform.Rotate(new Vector3(0, 0, rotate));
    }

    IEnumerator DestroyAfterDelay()
    {
        // �w�肵���b���ҋ@
        yield return new WaitForSeconds(destroyDelay);

        // �I�u�W�F�N�g��j��
        Destroy(gameObject);
    }
}