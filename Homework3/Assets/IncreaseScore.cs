using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseScore : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Cube")
        {
            print("Collision detected!");
            ScoreMan.instance.AddPoints();
        }
    }
}
