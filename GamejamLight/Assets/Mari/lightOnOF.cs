using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class lightOnOF : MonoBehaviour
{
    [SerializeField] private Light2D light;
    [SerializeField] private int waitTime;
    [SerializeField] private Collider2D collider2D;

    private void Start()
    {
        StartCoroutine(lampAan());
    }

    IEnumerator lampAan()
    {
        light.enabled = true;
        collider2D.enabled = true;
        yield return new WaitForSeconds(Random.Range(2, 5));
        StartCoroutine(lampUit());
    }

    IEnumerator lampUit()
    {
        light.enabled = false;
        collider2D.enabled = false;
        yield return new WaitForSeconds(waitTime);
        StartCoroutine(lampAan());
    }
}