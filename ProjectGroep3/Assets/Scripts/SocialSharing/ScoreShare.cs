using System.Collections;
using UnityEngine;

namespace ScoreSharing
{
    public class ScoreShare : MonoBehaviour
    {
        public void Test()
        {
            StartCoroutine(TakeScreenshotAndShare());
        }

        //als we een download link hebben, voeg die toe
        private IEnumerator TakeScreenshotAndShare()
        {
            yield return new WaitForEndOfFrame();
            new NativeShare()
                .SetSubject("HighScore").SetText("I beat Synthwave Outlaws with a highscore of: " + PlayerPrefs.GetFloat("HighScore") + ". Can you Beat me?!?!")
                .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                .Share();
        }
    }
}