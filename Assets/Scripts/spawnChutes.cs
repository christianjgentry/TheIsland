using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnChutes : MonoBehaviour
{

    public GameObject chute = null;
    public int number = 100;

    private void Start()
    {
        for (int i = 0; i < number; i++)
        {
            spawn();
        }
    }

    public void spawn()
    {
        GameObject newChute = Instantiate(chute, transform);
        newChute.AddComponent<RandomDrop>();
    }
}
