using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coin;
    
    public Vector3 spawnRange;
    private int maxCoinCount = 5;
    void Start()
    {
        
        InvokeRepeating("SpawnObject", 1f, 5f);
    }

    void SpawnObject()
    {
        
        if (GameObject.FindGameObjectsWithTag("Coin").Length >= maxCoinCount) // sahnede bulunan coinlere bir limit ekledik eğer limitteyse yeni spawn yapılmayacak 
        {
            return;
        }

        float spawnX = Random.Range(-11f,11f);
        float spawnZ = Random.Range(-11f,11f);

        Vector3 spawnPosition =  new Vector3(spawnX, -0.5f, spawnZ); // coinler rastgele bir position da spawnlanacak
        GameObject coinobject;
        coinobject=Instantiate(coin, spawnPosition, Quaternion.identity);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            //coin player ile temas ettiğinde score artacak ve coin silinecek
            CoinText.coinAmount += 10; 
            Destroy(gameObject);
        }
    }
}
