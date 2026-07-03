using UnityEngine;

public class Reset : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
