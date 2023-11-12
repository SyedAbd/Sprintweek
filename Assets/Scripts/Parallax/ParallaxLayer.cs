using UnityEngine;

[ExecuteInEditMode]
public class ParallaxLayer : MonoBehaviour
{
    public float parallaxFactor;

    public void Move(float delta)
    {
        Vector3 newPos = transform.localPosition;
        newPos.x -= delta * parallaxFactor;

        transform.localPosition = newPos;
    }

    public float GetLength()
    {
        float length = 0;
        if (gameObject.transform.childCount > 0)
        {
         length  = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
        }

        return length;
    }
}