using System.Collections;
using UnityEngine;

public class Effects : MonoBehaviour
{
    [Header("Effects")] public GameObject HandEffect;

    private void OnTriggerEnter(Collider other)
    {
        // 10% of effec percentage
        int effectPercentage = Random.Range(0, 10);
        if (effectPercentage == 0)
        {
            HandEffect.SetActive(true);
            StartCoroutine(DisableEffectAfterXSecond(1.0f));
        }
    }

    private IEnumerator DisableEffectAfterXSecond(float secondsToWait)
    {
        yield return new WaitForSeconds(secondsToWait);
        HandEffect.SetActive(false);
    }
}