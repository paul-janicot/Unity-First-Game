using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionsHandler : MonoBehaviour
{
    public List<GameObject> hearts = new List<GameObject>();
    public GameObject canvas;
    public GameObject canvas2;
    public int life = 4;

    // Start is called before the first frame update
    void Start()
    {
        updateLife();
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    void lifeloss(int perte)
    {
        if (life > 1) 
        life -= perte;
        else
        {
            canvas.SetActive(false);
            canvas2.SetActive(true);
        }

    }

    void lifegain(int gain)
    {
        life += gain;
    }
    void updateLife()
    {
        foreach (GameObject a in hearts)
        {

            a.SetActive(false);
        }
        for (int i = 0; i < life; i++)
        {
            hearts[i].SetActive(true);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            lifeloss(1);
            updateLife();
        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        lifegain(1);
        updateLife();
    }

}
