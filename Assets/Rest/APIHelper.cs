using System.IO;
using System.Net;
using UnityEngine;

namespace Rest
{
    public static class APIHelper
    {
        public static Joke GetNewJoke()
        {
            HttpWebRequest httpWebRequest =
                (HttpWebRequest) WebRequest.Create("https://api.chucknorris.io/jokes/random");

            HttpWebResponse httpWebResponse = (HttpWebResponse) httpWebRequest.GetResponse();

            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());

            string json = streamReader.ReadToEnd();
            return JsonUtility.FromJson<Joke>(json);
        }
    }
}