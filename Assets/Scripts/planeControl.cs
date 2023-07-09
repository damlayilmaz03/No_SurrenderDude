using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class planeControl : MonoBehaviour
{
    // zeminde olmadıklarında silmek için zemin kenarlarına oluşturduğum sınır neslerinin içerisinde olacak bu script

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Player")) 
        {

            Destroy(other.gameObject,1f);
        }
        
    }
}
