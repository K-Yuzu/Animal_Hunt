using UnityEngine;

public class PauseManuUI : MonoBehaviour
{
    [SerializeField] private GameManager pauseManu;

    //‚Ù‚©‚ÌUI‚ªŠJ‚¢‚Ä‚¢‚é‚©‚ğŠÇ—‚·‚é
    [SerializeField] private UIManager uiManager;

    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            //‚Ù‚©‚ÌUI‚ªŠJ‚¢‚Ä‚¢‚é‚È‚ç
            if (uiManager)
            {

            }
        }
    }
}
