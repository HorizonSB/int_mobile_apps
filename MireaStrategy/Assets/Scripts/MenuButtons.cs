using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void LevelOne(int _scene_number)
    {
        SceneManager.LoadScene(_scene_number);
    }

    public void SetCameraMovementFalse()
    {
        Camera.main.GetComponent<CameraMovement>().enabled = false;
    }

    public void SetCameraMovementTrue()
    {
        Camera.main.GetComponent<CameraMovement>().enabled = true;
    }
}
