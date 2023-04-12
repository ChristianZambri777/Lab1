using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericList : MonoBehaviour
{

     public List<int> numbers = new List<int>();
    public List<string> items = new List<string>();

    // Start is called before the first frame update
    void Start()
    {

        items.Add("FirstAdded");
        items.Add("SecondAdded");
        items.Add("ThirdAdded");
        items.Add("FourthAdded");

        numbers.Add(1);
        numbers.Add(2);
        numbers.Add(3);
        numbers.Add(4);

       


    }

    // Update is called once per frame
    void Update()
    {
        
       if(Input.GetKeyDown(KeyCode.T))
       {
            Debug.Log("IN");
            numbers = ReverseList(numbers);
            items = ReverseList(items);

       }

    }

    private List<T> ReverseList<T> (List<T> list)
    {
        List<T> tempList = new List<T>();

        for(int i = list.Count - 1; i >=0; i--)
        {
            tempList.Add(list[i]);
        }
        return tempList;
    }

    //private List<Item> 
}
