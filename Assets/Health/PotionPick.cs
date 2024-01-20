using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotionPick : MonoBehaviour
{
    [SerializeField] private float healthValue;
    private Transform player;
    [SerializeField] private AudioClip pickupSound;

    // Start is called before the first frame update
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnMouseDown()
    {
        Use();
        SoundManager.instance.PlaySound(pickupSound);
        Destroy(gameObject);
    }

    private void Use()
    {
        player.GetComponent<Health>().AddHealth(healthValue);
        gameObject.SetActive(false);
    }
}
