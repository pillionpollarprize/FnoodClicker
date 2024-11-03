using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Clicker : MonoBehaviour
{
    [Header("Animation settings")]
    public float scale = 1.2f;
    public float duration = 0.1f;
    public Ease ease = Ease.OutElastic;

    [Header("Audio")]
    public AudioClip clickSound;
    [HideInInspector]public int clicks = 0;
    private AudioSource audioSource;
    
    [HideInInspector]public int bpc; //bread per click

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        bpc = 1;
    }
    private void OnMouseDown() 
    {
        clicks += bpc;
        Debug.Log("Clicks: " + bpc);
        UiManager.instance.UpdateClicks(clicks);

        audioSource.pitch = Random.Range(0.9f, 1.1f);
        audioSource.PlayOneShot(clickSound);
        transform
            .DOScale(1, duration)
            .ChangeStartValue(scale * Vector3.one)
            .SetEase(ease);
            //.SetLoops(2, LoopType.Yoyo);
    }
}
