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
    public Canvas LoadingScreen;
    public string NextScenePath;

    private RectTransform _MainMenuRectTransform;
    private RectTransform _LoadingScreenRectTransform;
    private RectTransform _HowToPlayRectTransform;

    private GraphicRaycaster _MainMenuRaycaster;
    private GraphicRaycaster _HowToPlayRaycaster;

    // Action functions
    public void PlayGameButtonAction()
    {
        Debug.Log("'Play' Button Pressed");
        _SwitchMenus(1);
    }
    public void EndGameAction()
    {
        Debug.Log("'Exit game' Button Pressed");
        Application.Quit();
    }
    public void StartGameButtonAction()
    {
        Debug.Log("'Start journey' Button Pressed");
        _SwitchMenus(2);
        SceneManager.LoadScene(NextScenePath, LoadSceneMode.Single);
        
    }
    public void BackToTheMenuButtonAction()
    {
        Debug.Log("'Back To the Menu Button' Button Pressed");
        _SwitchMenus(0);
    }

    // If true, then MainMenu will be shown
    private void _SwitchMenus(int x)
    {
        if (x == 0)
        {
            _HowToPlayRaycaster.enabled = false;
            _MainMenuRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 0.5f, false);
            _HowToPlayRectTransform.DOAnchorPos(new Vector2(0.0f, 1080.0f), 0.5f, false);
            _MainMenuRaycaster.enabled = true;
        }
        else if (x == 1)
        {
            _MainMenuRaycaster.enabled = false;
            _MainMenuRectTransform.DOAnchorPos(new Vector2(0.0f, -1080.0f), 0.5f, false);
            _HowToPlayRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 0.5f, false);
            _HowToPlayRaycaster.enabled = true;
        }
        else
        {
            _MainMenuRaycaster.enabled = false;
            _HowToPlayRaycaster.enabled = false;
            _MainMenuRectTransform.DOAnchorPos(new Vector2(0.0f, -1080.0f), 0.5f, false);
            _LoadingScreenRectTransform.DOAnchorPos(new Vector2(0.0f, 0.0f), 0.5f, false);
            _HowToPlayRectTransform.DOAnchorPos(new Vector2(0.0f, -1080.0f), 0.5f, false);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _MainMenuRectTransform = MainMenu.GetComponent<RectTransform>();
        _HowToPlayRectTransform = HowToPlayMenu.GetComponent<RectTransform>();
        _LoadingScreenRectTransform = LoadingScreen.GetComponent<RectTransform>();

        _MainMenuRaycaster = MainMenu.GetComponent<GraphicRaycaster>();
        _HowToPlayRaycaster = HowToPlayMenu.GetComponent<GraphicRaycaster>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
