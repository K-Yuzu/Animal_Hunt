using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance{  get; private set; }

    private int openUICount = 0;

    public bool IsAnyUIOpen => openUICount > 0;

    private void Awake()
    {
        Instance = this;
    }

    public void UIOpened()
    {
        openUICount++;
    }

    public void UIClosed()
    {
        openUICount = Mathf.Max(0, openUICount - 1);
    }
}
