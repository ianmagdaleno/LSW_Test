using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorToEdit : MonoBehaviour
{
    [SerializeField] private GameObject interactiveFlag;
    [SerializeField] private UIManager manager;
    private bool playerInside = false;
    private float timer = 0f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactiveFlag.SetActive(true);
            playerInside = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactiveFlag.SetActive(false);
            playerInside = false;
        }
    }
    private void Update()
    {
        if (playerInside)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                manager.OpenCharacterEditor();
            }
        }
    }
}
