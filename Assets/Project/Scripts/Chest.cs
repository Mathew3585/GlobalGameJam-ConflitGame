using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject[] Gun;
    public Chest[] ChestStart;
    public Collider[] ChestTriggerStart;
    public int RandomGun;
    public GameObject SpawnObject;

    public GameObject HandUi;
    private bool detecter;
    public bool open;
    public bool StartSchest;
    public  Animator animator;
    public Collider Trigger;
    public Collider Collider;




    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interaction") && detecter && !open)
        {
            open = true;
            animator.SetBool("Open", true);
            RandomGun = Random.Range(0, Gun.Length);
            Trigger.enabled = false;
            Collider.enabled = false;
            HandUi.SetActive(false);
            if (StartSchest)
            {
                for (int i = 0; i < ChestStart.Length; i++)
                {
                    ChestStart[i].enabled = false;
                    ChestTriggerStart[i].enabled = false;
                }
            }
            if (RandomGun == 0)
            {
                Instantiate(Gun[0], SpawnObject.transform.position, SpawnObject.transform.rotation);
            }
            else if (RandomGun == 1)
            {
                Instantiate(Gun[1], SpawnObject.transform.position, SpawnObject.transform.rotation);
            }
            else if (RandomGun == 2)
            {
                Instantiate(Gun[2], SpawnObject.transform.position, SpawnObject.transform.rotation);
            }
            else if (RandomGun == 3)
            {
                Instantiate(Gun[3], SpawnObject.transform.position, SpawnObject.transform.rotation);
            }
            else if (RandomGun == 4)
            {
                Instantiate(Gun[4], SpawnObject.transform.position, SpawnObject.transform.rotation);
            }

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = true;
            HandUi.SetActive(true);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            detecter = true;
            HandUi.SetActive(false);
        }
    }
}
