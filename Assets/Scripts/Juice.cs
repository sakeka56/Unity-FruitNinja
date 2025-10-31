using UnityEngine;
using DG;
using DG.Tweening;
using System.Collections;

public class Juice : MonoBehaviour
{
    public float FadeTime = 2f;

    private void OnEnable()
    {
        StartCoroutine( Fade(FadeTime));

    }

    IEnumerator Fade(float time)
    {
        yield return new WaitForSeconds(time);
        transform.GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetDelay(0.5f).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}
