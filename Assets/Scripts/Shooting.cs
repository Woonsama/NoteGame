using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    GameObject player;
    public GameObject bullet;

    AudioSource source;
    AudioClip clip;

    private float currentTime;
    public float shotDelay;
    
    void Start()
    {
        player = GameObject.Find("Player");
        source = GetComponent<AudioSource>();
        clip = source.clip;
    }

    void Update()
    {
        currentTime += Time.deltaTime;

        if(Input.GetKey(KeyCode.Z))
        {
            Shot();
        }
    }

    private void CreateBullet()
    {
        
    }

    public void Shot()
    {
        if (currentTime >= shotDelay)
        {
            Instantiate(bullet, player.transform.position - new Vector3(0,0,-1), Quaternion.identity);
            source.Play();
            currentTime = 0;
        }
    }
}
