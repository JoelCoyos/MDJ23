using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
    [SerializeField] private Sprite[] textures;
    [SerializeField] private Image currentImage;
    private int textureNumber;

    private AudioSource source;

    public string NextScene;


    private void Start()
    {
        currentImage.sprite = textures[0];
        textureNumber = 1;
        source  = GetComponent<AudioSource>();
        source.Play();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && textureNumber < textures.Length)
        {
            currentImage.sprite = textures[textureNumber];
            textureNumber++;
        }
        else if(Input.GetKeyDown(KeyCode.Space) && textureNumber ==textures.Length)
        {
            SceneManager.LoadScene(NextScene);
        }
    }
}
