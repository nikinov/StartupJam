using System.Collections;
using DG.Tweening;
using UnityEngine;

public class Distructable : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private float distanceFromDestruction = 5;
    [SerializeField] private float timeToDownScale = 1.5f;
    [SerializeField] private GameObject indicatorTextUI;
    [SerializeField] private bool fallApart;

    private bool called;

    private void Start()
    {
        indicatorTextUI.SetActive(false);
        DOTween.Init();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    private void Update()
    {
        if (indicatorTextUI != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < distanceFromDestruction)
            {
                if (!called)
                {
                    player.OnDestroy += Destroy;
                    called = true;
                    indicatorTextUI.SetActive(true);
                }
            }
            else
            {
                if (called)
                {
                    player.OnDestroy -= Destroy;
                    called = false;
                    indicatorTextUI.SetActive(false);
                }
            }
        }
    }

    private void Destroy()
    {
        if (fallApart)
        {
            StartCoroutine(waitForDestroyFallApart(timeToDownScale));
        }
        else
        {
            StartCoroutine(waitForDestroy(timeToDownScale));
        }
    }

    IEnumerator waitForDestroy(float timing)
    {
        indicatorTextUI.SetActive(false);
        transform.DOScale(new Vector3(0, 0, 0), timing);
        yield return new  WaitForSeconds(timing);
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        Destroy(indicatorTextUI);
        Destroy(gameObject);
    }
    IEnumerator waitForDestroyFallApart(float timing)
    {
        Destroy(indicatorTextUI);
        foreach (Transform t in transform)
        {
            if (t.gameObject.name != "Explosion")
            {
                Rigidbody rb = t.gameObject.AddComponent<Rigidbody>();
                rb.AddExplosionForce(1, Vector3.up, 2);
            }
        }
        transform.GetChild(0).gameObject.SetActive(true);
        yield return new  WaitForSeconds(timing);
        yield return new WaitForSeconds(2);
        Destroy(this);
    }
    
}
