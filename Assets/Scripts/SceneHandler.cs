using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{
    public GameObject pausePanel;
    private bool isPaused = false;
    private bool IsPaused
    {
        get
        {
            return isPaused;
        }
        set
        {
            isPaused = value;
            pausePanel.SetActive(value);
            Time.timeScale = value ? 0 : 1;
        }
    }

 

    // Start is called before the first frame update
    void Start()
    {
     

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;    
        }
    }
    
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);

    }


    public void togglepause()
    {
        IsPaused = !IsPaused;
    }


    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;

#endif
        Application.Quit();
    }

}
