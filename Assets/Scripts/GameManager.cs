using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private float requestsInterval;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            StartCoroutine(CheckRequests());
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if (GvrViewer.Instance.BackButtonPressed)
        {
            Application.Quit();
        }
    }

    private IEnumerator CheckRequests()
    {
        while (true)
        {
            WWW request = new WWW("http://vates.pythonanywhere.com/todo1");
            yield return request;
            if (string.IsNullOrEmpty(request.error))
            {
                string value = request.text.Split('\"')[3];
                TryToOpenCorrectScene(value);
            }
            yield return new WaitForSeconds(requestsInterval);
        }
    }

    private void TryToOpenCorrectScene(string sceneName)
    {
        switch(sceneName.ToLower())
        {
            case "beach":
                if (SceneManager.GetActiveScene().name != "Beach") SceneManager.LoadScene("Beach");
                break;
            case "moon":
                if (SceneManager.GetActiveScene().name != "Moon") SceneManager.LoadScene("Moon");
                break;
            case "mountains":
                if (SceneManager.GetActiveScene().name != "Mountains") SceneManager.LoadScene("Mountains");
                break;
            case "farm":
                if(SceneManager.GetActiveScene().name != "Farm") SceneManager.LoadScene("Farm");
                break;
            case "back":
            case "menu":
                if (SceneManager.GetActiveScene().name != "Menu") SceneManager.LoadScene("Menu");
                break;
        }
    }
}
