using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class SpawnPoint : MonoBehaviour
{
    [SerializeField] Vector2 localDirection = Vector2.down;
    RectTransform rt;

    void Awake()
    {
        if (rt == null)
        {
            rt = GetComponent<RectTransform>();
        }
    }
    
    void OnDrawGizmos()
    {
        if (rt == null)
        {
            rt = GetComponent<RectTransform>();
        }

        Gizmos.color = Color.blue;
        Gizmos.DrawRay(transform.position, rt.TransformDirection(Vector2.Scale(localDirection, rt.rect.size)));
    }

    public void ManageSprite(CollectableSprite sprite)
    {
        sprite.transform.position = transform.position;
        sprite.direction = rt.TransformDirection(localDirection);
    }
}
