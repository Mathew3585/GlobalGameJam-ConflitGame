using AdvancedShooterKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorrDetectPlayer : MonoBehaviour
{

    public GameObject uiHand;
    public Animator uiLoad;
    private bool detecter;
    ASKInputManager m_Input;

    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && detecter)
        {
            Debug.Log("OpenDoor");
            uiLoad.SetBool("ActiveTp", true);
            Debug.Log("OpenDoor");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = true;
            uiHand.SetActive(true);
            Debug.Log("Player Detect");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = false;
            uiHand.SetActive(false);
            Debug.Log("Player Exit");
        }
    }
}
