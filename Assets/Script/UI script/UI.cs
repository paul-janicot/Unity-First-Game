using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Collections.AllocatorManager;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class UI : MonoBehaviour

{
    public bool isStart;
    public bool isQuit;
    public bool isMenu;
    
    // Start is called before the first frame update
    void Start()
    {
        if (isStart)
        {
            GetComponent<Button>().onClick.AddListener(play);
            
        }


        else if (isQuit)
        {
            
            GetComponent<Button>().onClick.AddListener(quit);
        }
        else if (isMenu)
        {
            
            GetComponent<Button>().onClick.AddListener(menu);
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
    void play()
    {
        SceneManager.LoadScene(1);
    }
    void quit()
    {
        Application.Quit();
    }
    void menu()
    {
        SceneManager.LoadScene(0);
    }
}
