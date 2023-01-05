using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnCheck_LJH : MonoBehaviour
{
    public Transform respawnZone;
    public GameObject explosionFactory;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            audioSource.Play();
            PlayerInfo_LJH.instance.respawnPosition = respawnZone.position;
            GameObject explosion = Instantiate(explosionFactory);
            explosion.transform.position = other.bounds.ClosestPoint(transform.position);

        }
    }

}
