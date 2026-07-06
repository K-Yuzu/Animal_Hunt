using UnityEngine;

public class inventory : MonoBehaviour
{
    public static inventory Instance;

    public int boar = 0;//‚¢‚Ì‚µ‚µ
    public int bird = 0;//‚Æ‚è


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        Instance = this;
    }

    public void addboar(string itemName,int amout)
    {
        boar += amout;
    }
    public void addbird(int amout)
    {

    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
