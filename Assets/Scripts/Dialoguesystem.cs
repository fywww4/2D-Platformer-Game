using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;

public class Dialoguesystem : MonoBehaviour
{

    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default2", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("intro2");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            fs.Next();
        }
    }
}
