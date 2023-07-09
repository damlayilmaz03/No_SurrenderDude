using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class enemyAI : MonoBehaviour , IDamageable
{
   
    Rigidbody rb;
    public float follow_speed;
    public GameObject[] players;
    private Transform target;
    float max_follow_distance = 6f;
    public bool isGrounded = false;
    public float force;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        players = GameObject.FindGameObjectsWithTag("Player");
       

    }

    private void Update()
    {
        find_close_players();
        move_to_target();
        

    }

    private void find_close_players()
    {
        float min_follow_distance = 5f;
        
        GameObject closePlayer = null; 

        foreach (GameObject player in players) // olusturdugumuz gameobject turundeki arrayde playerlara tek tek bakıyoruz 
        {
            float distance_to_player = Vector3.Distance(transform.position, player.transform.position); // player ile enemy arasindaki mesafeye bakiyoruz
            if (distance_to_player < min_follow_distance)
            {
                min_follow_distance = distance_to_player; 
                closePlayer = player; // yakindaki oyuncu bulundu

            }
        }

        if (closePlayer != null && min_follow_distance <= max_follow_distance)
        {
            target = closePlayer.transform;
        }
        else
        {
            target=null; // takibi birak
        }
    }

    private void move_to_target()
    {
        if (target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget >  max_follow_distance) // max uzakligia bakiyoruz
            {
                target = null; // takip birakilacak
                return;
            }
            
            transform.LookAt(target);//target'a dogru bakiyor
            transform.position = Vector3.MoveTowards(transform.position, target.position, follow_speed * Time.deltaTime); // enemy target'a dogru harekete geciyor
        }
    }
    

    public void OnHit(Vector3 knockback) // interfeace // bu kisim oyuncunun dusmana vurmasini/itmesini sagliyor
    {
        rb.AddForce(knockback);
    }

    private void OnCollisionEnter(Collision other)
    {
        
        if (other.gameObject.CompareTag("Player"))  // düsman oyuncuya vuruyor
        {
            Vector3 parentPos = gameObject.GetComponent<Transform>().position;

            Vector3 direction = (Vector3)(other.gameObject.transform.position - parentPos).normalized;

            Vector3 knockback = direction * force;

            rb.AddForce(knockback);
        }
    }
    

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
           
            isGrounded = true;
        }
        else
        {
            isGrounded= false;
        }
    }
    public void OnHit(System.Numerics.Vector3 knockback) // interface
    {
        throw new System.NotImplementedException();
    }
}
