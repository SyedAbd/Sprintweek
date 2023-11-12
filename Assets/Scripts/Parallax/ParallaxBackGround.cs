using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[ExecuteInEditMode]
public class ParallaxBrackGround : MonoBehaviour
{
    [SerializeField] private ParallaxCamera parallaxCamera;
    private List<ParallaxLayer> parallaxLayers = new List<ParallaxLayer>();

    //[SerializeField] GameObject prefab;
    [SerializeField] private float parallaxOffset = 30;

    //private bool isInstanciated;
    //private float length, startPos;

    private void Start()
    {
        if (parallaxCamera == null)
            parallaxCamera = Camera.main.GetComponent<ParallaxCamera>();

        if (parallaxCamera != null)
            parallaxCamera.onCameraTranslate += Move;

        SetLayers();

        //startPos = transform.position.x;
    }

    //private void FixedUpdate()
    //{
    //    float defPosition = startPos + length;
    //    float cameraTrackPosition = parallaxCamera.transform.position.x + parallaxOffset;
    //    if (cameraTrackPosition > defPosition && !isInstanciated)
    //    {
    //        Transform pTransform = transform.parent;
    //        GameObject item = Instantiate(prefab, new Vector3(cameraTrackPosition, transform.position.y, transform.position.z), Quaternion.identity);
    //        item.name = "BackGround";
    //        item.transform.SetParent(pTransform);
    //        isInstanciated = true;
    //    }
    //}

    private void SetLayers()
    {
        parallaxLayers.Clear();

        for (int i = 0; i < transform.childCount; i++)
        {
            ParallaxLayer layer = transform.GetChild(i).GetComponent<ParallaxLayer>();

            if (layer != null)
            {
                //length = layer.GetLength();

                //layer.name = "Layer-" + i;
                parallaxLayers.Add(layer);
            }
        }
    }

    private void Move(float delta)
    {
        foreach (ParallaxLayer layer in parallaxLayers)
        {
            layer.Move(delta);
        }
    }
}
 