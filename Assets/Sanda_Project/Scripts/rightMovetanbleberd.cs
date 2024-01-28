using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightMovetanbleberd : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;
    private int destroyDelay = 5;
    [SerializeField]
    private float rotatespeed = 0.05f;

    private void Start()
    {
        StartCoroutine(DestroyAfterDelay());
    }

    void Update()
    {
        //transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        transform.position += new Vector3(rotatespeed, 0, 0);

        transform.Rotate(new Vector3(0, 0, -1));
    }

    IEnumerator DestroyAfterDelay()
    {
        // �w�肵���b���ҋ@
        yield return new WaitForSeconds(destroyDelay);

        // �I�u�W�F�N�g��j��
        Destroy(gameObject);
    }
}
