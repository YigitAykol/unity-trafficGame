using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sas : MonoBehaviour
{
    public TrafficLight trafficLight; // TrafficLight bileşenini buraya sürükleyin

    void Start()
    {
        if (trafficLight == null)
        {
            trafficLight = FindObjectOfType<TrafficLight>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("Human entered sas area");

            npsController npcController = other.GetComponent<npsController>();
            if (npcController != null)
            {
                if (trafficLight != null && !trafficLight.IsRedLight())
                {
                    StartCoroutine(npcController.WaitAtTrafficLight(5f));
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("Human exited sas area");

            npsController npcController = other.GetComponent<npsController>();
            if (npcController != null)
            {
                if (trafficLight != null && trafficLight.IsRedLight())
                {
                    Debug.Log("YESIL YESIL");
                }
                else
                {
                    StartCoroutine(npcController.WaitAtTrafficLight(5f));
                }
            }
        }
    }
}
