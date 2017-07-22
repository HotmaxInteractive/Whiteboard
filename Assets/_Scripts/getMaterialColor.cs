using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMaterialColor : MonoBehaviour {

    public Color raycastHitColor;

    void Update()
    {

    }

    void OnTriggerExit(Collider collision)
    {

        sendRayOut();

    }

    void sendRayOut()
    {
        RaycastHit hit;
        //GameObject gameObject = null;

        if (Physics.Raycast(transform.position, transform.forward * -1, out hit))
        {
            if (hit.transform.gameObject.name == "ColorSphere")
            {

                Renderer rend = hit.transform.GetComponent<Renderer>();
                rend.material.shader = Shader.Find("Standard");
                MeshCollider meshCollider = hit.collider as MeshCollider;

                if (rend == null || rend.sharedMaterial == null || rend.sharedMaterial.mainTexture == null || meshCollider == null)
                {
                    return;
                }

                Texture2D tex = rend.material.mainTexture as Texture2D;
                Vector2 pixelUV = hit.textureCoord;
                pixelUV.x *= tex.width;
                pixelUV.y *= tex.height;

                raycastHitColor = tex.GetPixel((int)pixelUV.x, (int)pixelUV.y);
            }
        }
    }
}