using UnityEngine;

public class inventory : MonoBehaviour
{
    public static inventory Instance;

    //“÷
    public int boar = 0;//‚¢‚Ì‚µ‚µ
    public int bird = 0;//‚Æ‚è


    //Ìæ•¨
    public int apple = 0;//ƒŠƒ“ƒS
    public int mushroom = 0;//ƒLƒmƒR


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    private void Awake()
    {
        Instance = this;
    }

    public void addItem(string itemName, int amout)
    {
        switch (itemName)
        {
            case "boar":
                boar += amout;
                break;
            case "bird":
                bird += amout;
                break;
            case "apple":
                apple += amout;
                break;
            case "mushroom":
                mushroom += amout;
                break;

                default:
                break;
        }
    }
    //public void addboar(string itemName,int amout)
    //{
    //    boar += amout;
    //    bird += amout;

    //    apple += amout;
    //    mushroom += amout;
    //}
    //public void addbird(int amout)
    //{

    //}
    //public void addapple(int amout)
    //{

    //}
    //public void addmushroom(int amout)
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
