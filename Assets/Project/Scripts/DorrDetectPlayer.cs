using AdvancedShooterKit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DorrDetectPlayer : MonoBehaviour
{

    public GameObject uiHand;
    public Animator uiLoad;
    private Transform Player;
    public Transform Playmode;
    private bool detecter;
    private bool Wait;
    public float TimeToTp;
    public float TimeSpeed;
    ASKInputManager m_Input;

    private void Update()
    {
        if (Input.GetButtonDown("Interaction") && detecter)
        {
            Wait = true;
            Debug.Log("OpenDoor");
            uiLoad.SetBool("ActiveTp", true);


            Debug.Log("OpenDoor");
        }
        if (Wait)
        {
            TimeToTp += Time.deltaTime * TimeSpeed;
            if (TimeToTp >= 3)
            {
                Player.transform.position = Playmode.position;
                Player.transform.rotation = Playmode.rotation;
                uiLoad.SetBool("ActiveTp", false);
                Wait = false;
                return;
            }
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = true;
            uiHand.SetActive(true);
            Player = other.GetComponent<Transform>();
            Debug.Log("Player Detect");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = false;
            uiHand.SetActive(false);
            Player = null;
            Debug.Log("Player Exit");
        }
    }
}
