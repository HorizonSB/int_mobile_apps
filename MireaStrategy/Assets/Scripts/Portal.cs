using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public Text portalHealth;
    public int _portalhealth;
    public GameObject endGamePanel;
    public GameObject winPanel;
    public GameObject joystick;
    public GameObject[] spawners;
    public GameObject timer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            _portalhealth -= 1;
        }

    }

    private void Update()
    {
        portalHealth.text = _portalhealth.ToString() + "/20";

        if(_portalhealth <= 0)
        {
            endGamePanel.gameObject.SetActive(true);
            joystick.gameObject.SetActive(false);
        }

        if (_portalhealth <= 0) _portalhealth = 0;

        if(timer.GetComponent<Timer>()._timeLeft <= 270)
        {
            for(int i = 0; i < spawners.Length; i++)
            {
                spawners[i].SetActive(true);
            }
        }


        if (timer.GetComponent<Timer>()._timeLeft <= 0 && _portalhealth !=0)
        {
            winPanel.SetActive(true);
        }

    }
}
