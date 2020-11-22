using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;


public class MainMenuController : MonoBehaviour
{
    public Canvas MainMenu;
    public Canvas HowToPlayMenu;
    public string NextScenePath;

    private RectTransform _MainMenuRectTransform;
    private RectTransform _HowToPlayRectTransform;
    private GraphicRaycaster _MainMenuRaycaster;
    private GraphicRaycaster _HowToPlayRaycaster;

    // Action functions
    public void PlayGameButtonAction()
    {
        Debug.Log("'Play' Button Pressed");
        _SwitchMenus(false);
    }
    public void EndGameAction()
    {
        Debug.Log("'Exit game' Button Pressed");
        Application.Quit();
    }
    public void StartGameButtonAction()
    {
        Debug.Log("'Start journey' Button Pressed");
        SceneManager.LoadScene(NextScenePath, LoadSceneMode.Single);
        
    }
    public void BackToTheMenuButtonAction()
    {
        Debug.Log("'Back To the Menu Button' Button Pressed");
        _SwitchMenus(true);
    }

    // If true, then MainMenu will be shown
    private void _SwitchMenus(bool MainMenu)
    {
        if (MainMenu)
        {
            _HowToPlayRaycaster.enabled = false;
            _MainMenuRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 0.5f, false);
            _HowToPlayRectTransform.DOAnchorPos(new Vector2(0.0f, 1080.0f), 0.5f, false);
            _MainMenuRaycaster.enabled = true;
        }
        else
        {
            _MainMenuRaycaster.enabled = false;
            _MainMenuRectTransform.DOAnchorPos(new Vector2(0.0f, -1080.0f), 0.5f, false);
            _HowToPlayRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 0.5f, false);
            _HowToPlayRaycaster.enabled = true;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _MainMenuRectTransform = MainMenu.GetComponent<RectTransform>();
        _HowToPlayRectTransform = HowToPlayMenu.GetComponent<RectTransform>();

        _MainMenuRaycaster = MainMenu.GetComponent<GraphicRaycaster>();
        _HowToPlayRaycaster = HowToPlayMenu.GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
