using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Playbutton : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Level1");
    }


}