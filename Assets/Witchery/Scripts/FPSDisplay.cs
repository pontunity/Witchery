using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Lektion04
{
    public class FPSDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI fpsText;

        private float time;
        private float pollingTime = 3f;
        private int frameCount = 0;

        // Update is called once per frame
        void Update()
        {
            time += Time.deltaTime;
            frameCount++;

            if (time >= pollingTime)
            {
                int frameRate = Mathf.RoundToInt(frameCount / time);
                fpsText.text = frameRate.ToString() + " FPS";

                time -= pollingTime;
                frameCount = 0;
            }
        }
    }
}
