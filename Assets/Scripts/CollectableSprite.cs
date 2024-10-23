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
    [SerializeField] float speed = 5f;

    public Vector2 direction = Vector2.zero;

    void Awake()
    {
        button.onClick.AddListener(OnButtonClicked);
    }

    void Update()
    {
        rt.Translate(direction * speed * Time.deltaTime);
    }

    void OnButtonClicked()
    {
        SpriteCounter.CollectSprite();
        HeatCollectionManager.RemoveSprite(this);
        Destroy(gameObject);
    }
}
