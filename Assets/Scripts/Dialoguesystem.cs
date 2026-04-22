using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Flower;
using System; // 別忘了加入這個，因為要使用 Exception

public class Dialoguesystem : MonoBehaviour
{
    FlowerSystem fs;

    void Start()
    {
        // 1. 先嘗試取得是否已經有 "default2" 存在
        try
        {
            fs = FlowerManager.Instance.GetFlowerSystem("default2");
        }
        // 2. 如果 GetFlowerSystem 找不到並拋出錯誤，代表是第一次執行
        catch (Exception)
        {
            // 那我們就正式建立一個新的
            fs = FlowerManager.Instance.CreateFlowerSystem("default2", false);

            // 將基本設定放在這裡，確保只在第一次建立時執行一次
            fs.SetupDialog();
        }

        // 3. 讀取對話文本
        // (每次進入這個場景或掛載此腳本的物件被啟動時，都會讀取 intro2)
        fs.ReadTextFromResource("intro2");
    }

    // Update is called once per frame
    void Update()
    {
        // 加上 fs != null 的保護，避免在任何意外情況下按下空白鍵報錯
        if (Input.GetKeyDown(KeyCode.Space) && fs != null)
        {
            fs.Next();
        }
    }
}