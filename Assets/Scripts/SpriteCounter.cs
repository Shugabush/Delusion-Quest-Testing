using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpriteCounter : MonoBehaviour
{
    [SerializeField] TMP_Text countText;
    int count;
    const int targetCount = 15;

    static SpriteCounter instance;

    void Awake()
    {
        instance = this;
    }

    public static void CollectSprite()
    {
        instance.count++;
        instance.countText.text = instance.count.ToString("00");
        if (instance.count >= targetCount)
        {
            // We win
            HeatCollectionManager.End();
        }
    }
}
