namespace Firebase.Sample.Messaging
{
#if UNITY_ANDROID
        using Firebase.Extensions;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;
#elif UNITY_IOS
        using Firebase.Extensions;
    using System;
    using System.Threading.Tasks;
    using UnityEngine;
#else 
    using UnityEngine;

#endif

    public class NotificationHandler : MonoBehaviour
    {
#if UNITY_ANDROID
        Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
        private string topic = "Firefly";
        protected bool isFirebaseInitialized = false;

        protected bool LogTaskCompletion(Task task, string operation)
        {
            bool complete = false;
            
            if (task.IsFaulted)
            {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    string errorCode = "";
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        errorCode = String.Format("Error.{0}: ",
                          ((Firebase.Messaging.Error)firebaseEx.ErrorCode).ToString());
                    }
                }
            }
            else if (task.IsCompleted)
            {
                complete = true;
            }
            return complete;
        }

        // Start is called before the first frame update
        void Start()
        {
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;

            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
                dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError(
                      "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }

        void InitializeFirebase()
        {
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.SubscribeAsync(topic).ContinueWithOnMainThread(task => {
                LogTaskCompletion(task, "SubscribeAsync");
            });

            // This will display the prompt to request permission to receive
            // notifications if the prompt has not already been displayed before. (If
            // the user already responded to the prompt, thier decision is cached by
            // the OS and can be changed in the OS settings).
            Firebase.Messaging.FirebaseMessaging.RequestPermissionAsync().ContinueWithOnMainThread(
              task => {
                  LogTaskCompletion(task, "RequestPermissionAsync");
              }
            );
            isFirebaseInitialized = true;
        }

        public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
        {
            UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
        }

        public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
        }


#elif UNITY_IOS
        Firebase.DependencyStatus dependencyStatus = Firebase.DependencyStatus.UnavailableOther;
        private string topic = "Firefly";
        protected bool isFirebaseInitialized = false;

        protected bool LogTaskCompletion(Task task, string operation)
        {
            bool complete = false;
            
            if (task.IsFaulted)
            {
                foreach (Exception exception in task.Exception.Flatten().InnerExceptions)
                {
                    string errorCode = "";
                    Firebase.FirebaseException firebaseEx = exception as Firebase.FirebaseException;
                    if (firebaseEx != null)
                    {
                        errorCode = String.Format("Error.{0}: ",
                          ((Firebase.Messaging.Error)firebaseEx.ErrorCode).ToString());
                    }
                }
            }
            else if (task.IsCompleted)
            {
                complete = true;
            }
            return complete;
        }

        // Start is called before the first frame update
        void Start()
        {
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;

            Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWithOnMainThread(task => {
                dependencyStatus = task.Result;
                if (dependencyStatus == Firebase.DependencyStatus.Available)
                {
                    InitializeFirebase();
                }
                else
                {
                    Debug.LogError(
                      "Could not resolve all Firebase dependencies: " + dependencyStatus);
                }
            });
        }

        void InitializeFirebase()
        {
            Firebase.Messaging.FirebaseMessaging.MessageReceived += OnMessageReceived;
            Firebase.Messaging.FirebaseMessaging.TokenReceived += OnTokenReceived;
            Firebase.Messaging.FirebaseMessaging.SubscribeAsync(topic).ContinueWithOnMainThread(task => {
                LogTaskCompletion(task, "SubscribeAsync");
            });

            // This will display the prompt to request permission to receive
            // notifications if the prompt has not already been displayed before. (If
            // the user already responded to the prompt, thier decision is cached by
            // the OS and can be changed in the OS settings).
            Firebase.Messaging.FirebaseMessaging.RequestPermissionAsync().ContinueWithOnMainThread(
              task => {
                  LogTaskCompletion(task, "RequestPermissionAsync");
              }
            );
            isFirebaseInitialized = true;
        }

        public void OnTokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs token)
        {
            UnityEngine.Debug.Log("Received Registration Token: " + token.Token);
        }

        public void OnMessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
        {
            UnityEngine.Debug.Log("Received a new message from: " + e.Message.From);
        }

        
    
#endif

    }

}
