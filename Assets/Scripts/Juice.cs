using UnityEngine;
using DG;
using DG.Tweening;
using System.Collections;

public class Juice : MonoBehaviour ,IPoolable
{
    public FruitType FruitType;
    public float FadeTime = 2f;

    private void OnEnable()
    {
        //StartCoroutine( Fade(FadeTime));
    }

    IEnumerator Fade(float time)
    {
        yield return new WaitForSeconds(time);
        transform.GetComponent<SpriteRenderer>().DOFade(0, 0.5f).SetDelay(0.5f).OnComplete(() =>
        {
            //Destroy(gameObject);
            ObjectPoolManager.Instance.Despawn(this);
        });
    }

    public void OnSpawn()
    {
        StartCoroutine(Fade(FadeTime));
    }

    public void OnDespawn()
    {
        Color c = transform.GetComponent<SpriteRenderer>().color;
        transform.GetComponent<SpriteRenderer>().color = new Color(c.r, c.g, c.b, 1f);
    }
}
