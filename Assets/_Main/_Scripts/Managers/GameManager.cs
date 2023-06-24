
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //SINGLETON
    private static GameManager instance;

    //SINGLETON
    public static GameManager Instance => instance;

    //SCORE VARIABLES:
    private int gemScore = 0;
    private int winScore = 250;
    public GameObject gameOver;
    public GameObject gameWin;
    public TextMeshProUGUI scoreText;
    private int currentScore;

    //UI:
    public GameObject miniMap;
    
    //GEMS DICTIONARY:
    private Dictionary<string, int> gemValues = new Dictionary<string, int>
    {
        { "Diamondo", 10 },
        { "SphereGemLarge", 20 },
        { "BeveledStar", 40 },
        // Agrega más gemas y sus respectivos valores según sea necesario
    };

    //SINGLETON--------------------
    private void Awake()
    {
        // Verificar si ya existe una instancia del GameManager
        if (instance != null && instance != this)
        {
            // Ya hay una instancia, destruir este objeto
            Destroy(gameObject);
            return;
        }

        // Establecer esta instancia como la instancia actual del GameManager
        instance = this;

        // Mantener este objeto GameManager en todas las escenas
        DontDestroyOnLoad(gameObject);
    }
    
    //POSIBLE FIX POR EL QUE CRASHEA UNITY AL DAR RETRY??¿¿ (NO) :(
    //CON ESTE MÉTODO, EL GAME MANAGER NO PIERDE SUS REFERENCIAS AL CARGAR LA NUEVA ESCENA.
    void Start()
    {
        // Buscar y asignar referencias a los objetos de la interfaz de usuario
        gameOver = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.name == "PanelDefeat");  //ENCUENTRA OBJETOS TANTO ACTIVADOS COMO DESACTIVADOS.
        gameWin = Resources.FindObjectsOfTypeAll<GameObject>().FirstOrDefault(g => g.name == "PanelWin");
        scoreText = GameObject.Find("PlayerScore").GetComponent<TextMeshProUGUI>();
        miniMap = GameObject.Find("BackMap");
    }

    //SCORE DE GEMAS RECOLECTADAS DESDE ITEM:
    public void AddGemScore(int score)
    {
        gemScore += score;
        scoreText.text = "Score: " + gemScore;
        Debug.Log("Puntaje actual: " + gemScore);

        if (gemScore >= winScore)
        {
            WinGame();
        }
    }
    
    //WIN GCONDITION
    public void WinGame()
    {
        gameWin.SetActive(true);
        miniMap.SetActive(false);
        Time.timeScale = 0;
       print("¡You Win!");
    }

    public int GetScore()
    {
        return currentScore;
    }
    
 //GAME OVER
    public void GameOver()
    {

        gameOver.SetActive(true);
        miniMap.SetActive(false);
        Time.timeScale = 0;
       print("¡Game over!.");

    }

    //COMENTAR ESTOS METODOS?
    public void UpdateGemCount()
    {
        int gemCount = 0;
        foreach (var gem in gemValues)
        {
            int gemValue = gem.Value;
            gemCount += gemValue;
        }
    }

    //COMENTAR ESTOS METODOS?
    public int GetGemCount()
    {
        return gemValues.Count;
    }

}