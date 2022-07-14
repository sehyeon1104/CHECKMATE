using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SetselectButton : MonoBehaviour
{
    [SerializeField]
    private GameObject[] pauseButtons;
    [SerializeField]
    private GameObject pausePanel;
    private Button ContBtn;
    private Button DiffBtn;

    private bool isPause = false;

    private void Start()
    {
        ContBtn = pauseButtons[0].GetComponent<Button>();
        DiffBtn = pauseButtons[1].GetComponent<Button>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPause)
            {
                isPause = true;
                Time.timeScale = 0f;
            }
            else
            {
                isPause = false;
                Time.timeScale = 1f;
            }
        }
        pausePanel.SetActive(isPause);
        if (pausePanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                Debug.Log("안도!");
                EventSystem.current.SetSelectedGameObject(pauseButtons[0]);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                EventSystem.current.SetSelectedGameObject(pauseButtons[1]);
            }
            if (Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                if (EventSystem.current.currentSelectedGameObject == pauseButtons[0])
                {
                    ContBtn.Select();
                    Debug.Log("야호");
                }
                else if (EventSystem.current.currentSelectedGameObject == pauseButtons[1])
                {
                    DiffBtn.Select();
                    Debug.Log("하하");
                }
            }
        }
    }

    public void OnClickContBtn()
    {
        isPause = false;
        Time.timeScale = 1f;
    }

    public void OnClickDiffBtn()
    {
        LoadingSceneController.LoadScene("SelectScene");
    }
}
