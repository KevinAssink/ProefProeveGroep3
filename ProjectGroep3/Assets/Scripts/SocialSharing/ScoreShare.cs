using System.Collections;
using UnityEngine;

namespace ScoreSharing
{
    public class ScoreShare : MonoBehaviour
    {
        //--------------------Functions--------------------//
        /// <summary>
        /// Opens the Share menu of your phone, Where you can share a message of your highscore
        /// </summary>
        public void ShareHighScore()
        {
            StartCoroutine(ShareHighScoreCoroutine());
        }

        //als we een download link hebben, voeg die toe
        private IEnumerator ShareHighScoreCoroutine()
        {
            yield return new WaitForEndOfFrame();
            new NativeShare()
                .SetSubject("HighScore").SetText("I beat Synthwave Outlaws with a highscore of: " + PlayerPrefs.GetFloat("HighScore") + ". Can you Beat me?!?!")
                .SetCallback((result, shareTarget) => Debug.Log("Share result: " + result + ", selected app: " + shareTarget))
                .Share();
        }
    }
}