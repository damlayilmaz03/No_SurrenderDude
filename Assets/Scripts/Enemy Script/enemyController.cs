using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyController : MonoBehaviour
{
    public float movementSpeed = 3f;
    public Vector3 move_area_center; // belirli bi alan olusturucaz bunun merkezi
    public float move_area_radi; // bu alanın yarıcapı 

    private Vector3 targetPosition; 
    private void Start()
    {
        
        random_target_pos();
    }

    private void Update()
    {
        if (is_at_target_pos())
        {
            
            random_target_pos();//target'a gelince position degis
        }

        
        move_target_pos();//yeni position a ilerle
    }

    private bool is_at_target_pos()
    {
        
        float distance_to_target = Vector3.Distance(transform.position, targetPosition);
        return distance_to_target < 0.1f; //yakin miyiz kontrolü
    }

    private void random_target_pos()
    {
        
        Vector3 random = Random.insideUnitSphere * move_area_radi; // basit bir küre 0,0 merkezli 1 birim yarıçaplı (insideUnitShere)
        targetPosition = move_area_center + new Vector3(random.x, 0f, random.z);
    }

    private void move_target_pos()
    {
        
        transform.LookAt(targetPosition);

       
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementSpeed * Time.deltaTime);
    }
}
