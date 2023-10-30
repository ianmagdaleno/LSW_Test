using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerToMenu : MonoBehaviour
{
    [SerializeField] private GameObject flaginteractiveFlag;
    private bool playerInside = false; 
    private float timer = 0f;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flaginteractiveFlag.SetActive(true);
            playerInside = true; 
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            flaginteractiveFlag.SetActive(false);
            playerInside = false; 
            timer = 0f; 
        }
    }

    private void Update()
    {
        if (playerInside)
        {
            timer += Time.deltaTime; 

            if (timer >= 3f) 
            {
                SceneManager.LoadScene("MainMenu"); 
            }
        }
    }
}
