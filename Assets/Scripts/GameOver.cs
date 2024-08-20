using UnityEngine;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    public GameObject panel;

    private void Start()
    {
        panel.SetActive(false);
        GetComponent<Health>().OnDeath += ShowPanel;
    }

    private void ShowPanel()
    {
        panel.SetActive(true);
    }

    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
