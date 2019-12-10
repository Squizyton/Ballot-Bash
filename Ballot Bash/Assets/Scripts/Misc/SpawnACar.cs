using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnACar : MonoBehaviour
{


    public GameObject[] Cars;

    public GameObject spawnedCar;

    public int rotation;

    public int CarSpeed;

    public bool goRight, goLeft;

    public int MinTimer, MaxTimer;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }


    IEnumerator Timer()
    {
       int timer = Random.Range(MinTimer, MaxTimer);

        Debug.Log(timer);
        yield return new WaitForSeconds(timer);

        Spawn();
    }


    public void Spawn()
    {

        spawnedCar = Instantiate(Cars[Random.Range(0, Cars.Length)], transform.position, transform.rotation);
        if (goRight)
        {
            spawnedCar.GetComponent<CarMovement>().goRight = true;
            spawnedCar.GetComponent<CarMovement>().speed = CarSpeed;
        }
        else if(goLeft)
        {

            spawnedCar.GetComponent<CarMovement>().goLeft = true;
            spawnedCar.GetComponent<CarMovement>().speed = CarSpeed;
        }

        StartCoroutine(Timer());
        Debug.Log("loop");
    }

    

}
