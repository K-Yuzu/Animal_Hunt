using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
public class Scene_Manager : MonoBehaviour
{
    public float delay = 0.2f;//ƒV[ƒ“ˆÚs‚Ì—P—\
    private float timer = 0f;

    private bool isLoding = false;


    //“G‚Ì”
    public int enemyCount;

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
        else if(objs.Length==0&&!isLoding)
        {
            isLoding = true;
            //•Û‘¶
            PlayerPrefs.SetInt("ResultScore",ScoreManager.instance.score);
            PlayerPrefs.Save();

            StartCoroutine(LoadResult());

           // timer += Time.deltaTime;
           }
    }

    IEnumerator LoadResult()
    {
        yield return new WaitForSeconds(delay);
        FadeManager.Instance.LoadScene("Result", 1.0f);

    }
}
