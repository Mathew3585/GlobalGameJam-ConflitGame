using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorrDetectPlayer : MonoBehaviour
{

    public GameObject uiHand;
    public Animator uiLoad;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if(Input.GetButtonDown())
            uiHand.SetActive(true);
            uiLoad.SetBool("ActiveTp", true);
            Debug.Log("Player Detect");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            uiHand.SetActive(false);
            Debug.Log("Player Exit");
        }
    }
}
