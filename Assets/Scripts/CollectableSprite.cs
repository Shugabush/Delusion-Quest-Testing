using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(RectTransform))]
public class CollectableSprite : MonoBehaviour
{
    // Must be assigned in the inspector
    [SerializeField] RectTransform rt;
    [SerializeField] Button button;
    [SerializeField] Renderer buttonRend;
    [SerializeField] float minSpeed = 200f;
    [SerializeField] float maxSpeed = 400f;
    float speed;

    public Vector2 direction = Vector2.zero;

    void Awake()
    {
        button.onClick.AddListener(OnButtonClicked);
        speed = Random.Range(minSpeed, maxSpeed);
    }

    void OnDestroy()
    {
        HeatCollectionManager.RemoveSprite(this);
    }

    void Update()
    {
        rt.Translate(direction * speed * Time.deltaTime);
        if (IsOffScreen())
        {
            Destroy(gameObject);
        }
    }

    void OnButtonClicked()
    {
        SpriteCounter.CollectSprite();
        Destroy(gameObject);
    }

    bool IsOffScreen()
    {
        return rt.anchoredPosition.x >= (Screen.width + rt.sizeDelta.x) / 2f ||
               rt.anchoredPosition.x <= (-Screen.width - rt.sizeDelta.x) / 2f ||
               rt.anchoredPosition.y >= (Screen.height + rt.sizeDelta.y) / 2f ||
               rt.anchoredPosition.y <= (-Screen.height - rt.sizeDelta.y) / 2f;
    }
}
