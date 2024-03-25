using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text fpsText;
    private float fps;

    private IEnumerator Start()
    {
        while (true)
        {
            fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps.ToString();
            yield return new WaitForSeconds(1f);
        }
    }
}
