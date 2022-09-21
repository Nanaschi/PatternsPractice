using System.Collections;
using System.Collections.Generic;
using Rest;
using UnityEngine;

public class JokeTeller : MonoBehaviour
{
    void Start()
    {
        var joke = APIHelper.GetNewJoke();
        print(joke.value);
    }
}