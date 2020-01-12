using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rigid;

    public float bulletSpeed;
    public float destroyTime;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();

        Move();

        DestroyObject(gameObject);
    }
    
    void Update()
    {

    }

    private void Move()
    {
        rigid.AddForce(Vector3.up * bulletSpeed,ForceMode2D.Impulse);
    }


    private void DestroyObject(GameObject gameObject)
    {
        GameObject.Destroy(gameObject, destroyTime);
    }
}
