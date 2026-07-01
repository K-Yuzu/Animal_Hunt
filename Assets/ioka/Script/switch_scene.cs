using UnityEngine;
using UnityEngine.SceneManagement;

public class Switch_scene: MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void change_scene()
    {
        SceneManager.LoadScene("SafeZone", LoadSceneMode.Single);
    }
}
