using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 3;
    void Awake() {
        Destroy(gameObject, bulletLife);

    }

    //void OnCollisionEnter(Collision collision)//other 
    //{
        //Destroy(collision.gameObject);
        //Destroy(gameObject);

    //}
}