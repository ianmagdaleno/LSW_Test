using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RockPaperScissors : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private UIUpdater manager;

    [SerializeField] private GameObject panelGame;
    [SerializeField] private TMP_Text resultText;
    [SerializeField] private Button rockButton;
    [SerializeField] private Button paperButton;
    [SerializeField] private Button scissorsButton;
    [SerializeField] private GameObject interactiveFlag;

    private bool playerChoiceMade = false;
    private bool playerInside;
    private int playerChoice;
    private int NPCChoice;

    private void Start()
    {
        rockButton.onClick.AddListener(() => MakeChoice(0));
        paperButton.onClick.AddListener(() => MakeChoice(1));
        scissorsButton.onClick.AddListener(() => MakeChoice(2));
    }
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
                if (!panelGame.activeSelf)
                {
                    panelGame.SetActive(true);
                }
                else
                {
                    panelGame.SetActive(false);
                }
            }
        }
    }

    private void MakeChoice(int choice)
    {
        if (!playerChoiceMade)
        {
            playerChoice = choice;
            playerChoiceMade = true;
            StartCoroutine(CountdownAndDetermineWinner());
        }
    }

    private IEnumerator CountdownAndDetermineWinner()
    {
        for (int countdown = 3; countdown >= 1; countdown--)
        {
            resultText.text = countdown.ToString();
            yield return new WaitForSeconds(1f);
        }

        NPCChoice = Random.Range(0, 3);
        string[] choices = { "Rock", "Paper", "Scissor" };

        string result = DetermineResult(playerChoice, NPCChoice);
        resultText.text = $"Your choice {choices[playerChoice]}. NPC choice {choices[NPCChoice]}. {result}";

        playerChoiceMade = false;
    }

    private string DetermineResult(int playerChoice, int computerChoice)
    {
        if (playerChoice == computerChoice)
        {
            return "Empate!";
        }
        else if ((playerChoice == 0 && computerChoice == 2) ||
                 (playerChoice == 1 && computerChoice == 0) ||
                 (playerChoice == 2 && computerChoice == 1))
        {
            character.coins += 100f;
            manager.UpdateCoins();
            return "You Wins!";
        }
        else
        {

            return "NPC Wins!";
        }
    }

}
