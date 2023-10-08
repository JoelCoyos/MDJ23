using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{ 

    [SerializeField] GameObject creditos;
    [SerializeField] GameObject principal;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("CutsceneStart");
    }

    public void EnterCreditos()
    {
        creditos.SetActive(true);
        principal.SetActive(false);
    }

    public void ExitCreditos()
    {
        creditos.SetActive(false);
        principal.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
