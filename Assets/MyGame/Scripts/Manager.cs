using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public GameObject prefab;
    public GameObject myParent;
    

    void Start()
    {
        for (int i = 0; i < 100; i++){

            Instantiate(prefab, myParent.transform);
            GameObject obj = Instantiate(prefab);
            obj.transform.SetParent(myParent.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
