using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowMotion : MonoBehaviour
{
    [SerializeField] private PostProcessVolume ProcessVolume;

    private void Awake()
    {
        ProcessVolume.weight = 0.0f;
    }

    public void Play()
    {
        StartCoroutine(CoMain());
    }

    private IEnumerator CoMain()
    {
        var before  = Time.timeScale;
        Time.timeScale = 0.1f;
        ProcessVolume.weight = 1;

        yield return new WaitForSecondsRealtime(5.0f);

        Time.timeScale = before;
        ProcessVolume.weight = 0;
    }
}