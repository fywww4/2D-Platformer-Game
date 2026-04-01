using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using UnityEngine.SceneManagement;

public class IntroSceneController : MonoBehaviour
{
    FlowerSystem fs;
    void Start()
    {
        fs = FlowerManager.Instance.CreateFlowerSystem("default", false);
        fs.SetupDialog();
        fs.ReadTextFromResource("intro");
        fs.RegisterCommand("load_scene",(List<string> _params) =>
        {
            SceneManager.LoadScene(_params[0]);
        });
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
