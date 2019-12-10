using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasterEgg : MonoBehaviour
{
    public int count;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (count >= 50)
        {
            GameObject.FindGameObjectWithTag("RightSpawner").GetComponent<SpawnACar>().CarSpeed = 250;
            GameObject.FindGameObjectWithTag("RightSpawner").GetComponent<SpawnACar>().MaxTimer = 0;
            GameObject.FindGameObjectWithTag("RightSpawner").GetComponent<SpawnACar>().MinTimer = 0;
            GameObject.FindGameObjectWithTag("LeftSpawner").GetComponent<SpawnACar>().CarSpeed = 250;
            GameObject.FindGameObjectWithTag("LeftSpawner").GetComponent<SpawnACar>().MaxTimer = 0;
            GameObject.FindGameObjectWithTag("LeftSpawner").GetComponent<SpawnACar>().MinTimer = 0;
            GameObject.FindGameObjectWithTag("RightSpawner").GetComponent<SpawnACar>().Spawn();
            GameObject.FindGameObjectWithTag("LeftSpawner").GetComponent<SpawnACar>().Spawn();
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
            {
            count++;
        }
    }
}
