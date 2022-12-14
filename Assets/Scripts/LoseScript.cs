using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseScript : MonoBehaviour
{
    public GameObject panel;

    private void OnCollisionEnter(Collision other) {
        panel.SetActive(true);
    }
}
