using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public enum Phase 
{
    Gameplay,
    Pause,
    ItemsMenu,
    WeaponsMenu,
    GameOver,
    FinalCutscene
}
public class GameLogic : MonoBehaviour
{
    public Phase activePhase;
    public GameObject pauseScreen;
    public Animator doorAnimator;
    public Animator elevatorAnimator;
    public GameObject player;
    public GameObject gameOverScreen;
    public GameObject finalScreen;
    public CinemachineVirtualCamera overheadCam;
    // Start is called before the first frame update
    void Start()
    {
        activePhase = Phase.Gameplay;
        OpenElevatorDoor();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            TogglePause();
        }
    }

    void SetPhase(Phase newPhase)
    {
        activePhase = newPhase;
    }

    void TogglePause()
    {
        if (activePhase == Phase.Gameplay)
        {
            activePhase = Phase.Pause;
        }
        else if (activePhase == Phase.Pause)
        {
            activePhase = Phase.Gameplay;
        }
        pauseScreen.SetActive(!pauseScreen.activeSelf);
    }

    void OpenElevatorDoor()
    {
        doorAnimator.SetBool("openDoor", true);
    }

    void CloseElevatorDoor()
    {
        doorAnimator.SetBool("openDoor", false);
    }

    void RaiseElevator()
    {
        elevatorAnimator.SetBool("elevatorLeaving", true);
    }

    public IEnumerator EndGame()
    {
        activePhase = Phase.FinalCutscene;
        CloseElevatorDoor();
        player.SetActive(false);
        RaiseElevator();
        yield return new WaitForSeconds(1.0f);
        elevatorAnimator.gameObject.SetActive(false);
        finalScreen.SetActive(true);
        overheadCam.Priority = 8;
        StartCoroutine(RestartGame(60.0f));

    }

    public void GameOver()
    {
        activePhase = Phase.GameOver;
        gameOverScreen.SetActive(true);
        StartCoroutine(RestartGame(2.0f));
    }

    IEnumerator RestartGame(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(0);
    }
}
