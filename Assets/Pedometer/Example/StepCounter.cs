/* 
*   Pedometer
*   Copyright (c) 2018 Yusuf Olokoba
*/

namespace PedometerU.Tests {
    using System;
    using System.Collections;
    using UnityEngine;
    using UnityEngine.Networking;
    using UnityEngine.UI;

    public class StepCounter : MonoBehaviour {

        public static StepCounter instance;
        private void Awake()
        {
            if (instance != null)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
            }
        }

        // public Text stepText, distanceText;
        public Text weekly_steps_count_Text;
        public Text monthly_steps_count_Text;

        public Text weekly_steps_count_2_Text;
        public Text monthly_steps_count_2_Text;


        private Pedometer pedometer;
        private double lastDistance;

        private void Start ()
        {

        #if PLATFORM_IPHONE
            // Create a new pedometer
            pedometer = new Pedometer(OnStep);
            // Reset UI
            OnStep(0, 0);
#endif
            LoadingManager.instance.loading.SetActive(true);
            StartCoroutine(GetMonthlyStepsCount());
        }

        private void OnStep (int steps, double distance) {
            // Display the values // Distance in feet
            //stepText.text = steps.ToString();

            distance *= 3.280849f;
            double dif = distance - lastDistance;
            lastDistance = distance;

            int currentFeet = Mathf.RoundToInt((float)dif);
            DistanceManager.FeetWalked += currentFeet;
            DistanceManager.FeetWalkedWeekly += currentFeet;
            DistanceManager.FeetWalkedMonthly += currentFeet;
            DisplayData();
        }

        public void DisplayData()
        {
            //Debug.Log("DisplayData week count "+ DistanceManager.FeetWalkedWeekly);
            //Debug.Log("DisplayData month count " + DistanceManager.FeetWalkedMonthly);
            //Debug.Log("DisplayData FeetWalked " + DistanceManager.FeetWalked);
            //Debug.Log("Auth0 token " + Auth0Manager.AccessToken);
            weekly_steps_count_Text.text = StepsToKilometers(DistanceManager.FeetWalkedWeekly);
            monthly_steps_count_Text.text = StepsToKilometers(DistanceManager.FeetWalkedMonthly);
            weekly_steps_count_2_Text.text = StepsToKilometers(DistanceManager.FeetWalkedWeekly);
            monthly_steps_count_2_Text.text = StepsToKilometers(DistanceManager.FeetWalkedMonthly);
        }

        public static string StepsToKilometers(int steps)
        {
            return (steps * 0.0003048f).ToString("F3");
        }
        public void GetSteps()
        {
            StartCoroutine(GetMonthlyStepsCount());
        }

        private void OnDisable () {
            // Release the pedometer
            pedometer.Dispose();
            pedometer = null;
        }
        public IEnumerator GetMonthlyStepsCount()
        {
            WWWForm form = new WWWForm();
            form.AddField("onbases", "m");

            string requestName = "api/v1/users/get_user_steps";
            using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
            {
                www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
                {
                    ConsoleManager.instance.ShowMessage("Network Error!");
                    Debug.Log(www.error);
                }
                else
                {
                   // StepsRoot StepsResponce = JsonUtility.FromJson<StepsRoot>(www.downloadHandler.text);
//                    DistanceManager.FeetWalkedMonthly = StepsResponce.data;
                    StartCoroutine(GetWeeklyStepsCount());
                }
            }
        }
        public IEnumerator GetWeeklyStepsCount()
        {
            WWWForm form = new WWWForm();
            form.AddField("onbases", "w");

            string requestName = "api/v1/users/get_user_steps";
            using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
            {
                www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
                {
                    ConsoleManager.instance.ShowMessage("Network Error!");
                    Debug.Log(www.error);
                }
                else
                {
//                    StepsRoot WeeklyStepsResponce = JsonUtility.FromJson<StepsRoot>(www.downloadHandler.text);
                    //DistanceManager.FeetWalkedWeekly = WeeklyStepsResponce.data;
                    //LoadingManager.instance.loading.SetActive(false);
                    //DisplayData();
                }
            }
        }

    }
}