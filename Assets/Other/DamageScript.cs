using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public int damageAmount=20;
    void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "zombi")
        {
            other.GetComponent<ZombiScript>().TakeDamage(damageAmount);
        }
    }
}
