using AdvancedShooterKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorrDetectPlayer : MonoBehaviour
{

    public GameObject uiHand;
    public Animator uiLoad;
    ASKInputManager m_Input;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("Interaction"))
            {
                uiLoad.SetBool("ActiveTp", true);
            }
                uiHand.SetActive(true);
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
