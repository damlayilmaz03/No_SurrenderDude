using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackScript : MonoBehaviour
{
    public Collider attack_collider;
    public float knockbackForce;
    
    private void Start()
    {
        attack_collider.GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))//player enemy e vuruyor
        {
            Vector3 parentPos = gameObject.GetComponent<Transform>().position;

            Vector3 direction = (Vector3)(other.gameObject.transform.position - parentPos).normalized;

            Vector3 knockback = direction * knockbackForce;

            other.SendMessage("OnHit", knockback);
        }
        
    }
}
