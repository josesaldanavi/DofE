using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool live;
    public static bool inicioJuego=false;
    
    // Start is called before the first frame update

    private void Awake()
    {
        //pseudo singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(int scenenumber)
    {
        SceneManager.LoadScene(scenenumber);
        inicioJuego = true;
    }
    
}
