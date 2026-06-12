using UnityEngine;
using UnityEngine.SceneManagement;
public class Scene_Manager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Mob");
        if(objs.Length>0)
        {
            Debug.Log("“GŠ´’m");
        }
        else if(objs.Length<=0)
        {
            SceneManager.LoadScene("Result");
        }
    }
}
