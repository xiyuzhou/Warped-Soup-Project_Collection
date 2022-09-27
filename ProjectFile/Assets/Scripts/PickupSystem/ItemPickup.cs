using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ItemPickup : MonoBehaviour
{
    [SerializeField]
    public Item item;

    public Text pickUpText;

    private bool pickUpAllowed;

    // Use this for initialization
    private void Start()
    {
        pickUpText.gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            pickUpText.gameObject.SetActive(false);
            Pickup();
        }
            
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log(collision.GetComponent<Collider>().tag);
        if (collision.GetComponent<Collider>().tag == "Player")
        {

            pickUpText.gameObject.SetActive(true);
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.GetComponent<Collider>().tag == "Player")
        {
            pickUpText.gameObject.SetActive(false);
            pickUpAllowed = false;
        }
    }
    void Pickup()
    {
        InventoryManager.Instance.Add(item);
        Destroy(gameObject);
        InventoryManager.Instance.ShowContent();
    }

}
