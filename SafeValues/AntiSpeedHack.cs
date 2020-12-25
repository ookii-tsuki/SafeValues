using System;
using System.Collections;
using UnityEngine;

namespace Med.SafeValue
{
    /// <summary>
    /// Guards the game from speed hacks (it's not recommanded to use it in an online game as everything would be client side)
    /// </summary>
    public static class AntiSpeedHack
    {
        private static float sysTime = DateTime.Now.Second;
        private static float timer = DateTime.Now.Second;

        /// <summary>
        /// Returns if the Anti Speed Hack is running.
        /// </summary>
        public static bool IsRunning { get; private set; }

        /// <summary>
        /// Starts the Anti Speed Hack process.
        /// </summary>
        /// <param name="OnTrigger">An action parameter that gets invoked when a speed hack occures.</param>
        /// <param name="tolerance">Speed tolerance.</param>
        /// /// <param name="runInBackground">Wheather to keep the game running in the background (it is recommanded to leave it true).</param>
        public static IEnumerator Start(Action OnTrigger, float tolerance = 2f, bool runInBackground = true)
        {
            sysTime = timer = DateTime.Now.Second;
            IsRunning = true;
            Application.runInBackground = runInBackground;
            while (IsRunning)
            {
                if (Mathf.Approximately(sysTime, 10f) || Mathf.Approximately(sysTime, 50f))
                    timer = DateTime.Now.Second;

                sysTime = DateTime.Now.Second;
                timer += Time.deltaTime;

                var result = Mathf.Abs(timer - sysTime);

                if ((result > tolerance && sysTime > 10f) || (result > 60 + tolerance && sysTime < 10f))
                    OnTrigger.Invoke();

                yield return null;
            }
        }
        /// <summary>
        /// Resets the Anti Speed Hack timer without stopping the process.
        /// </summary>
        public static void Reset()
        {
            sysTime = timer = DateTime.Now.Second;
        }
        /// <summary>
        /// Stops the Anti Speed Hack and resets its timer.
        /// </summary>
        public static void Stop()
        {
            sysTime = timer = DateTime.Now.Second;
            IsRunning = false;
        }
    }
}
