using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchController : MonoBehaviour
{
    Transform lantern;
    bool actualLanternState = false;
    bool activatable = false;
    // Start is called before the first frame update
    void Start()
    {
        lantern = transform.GetChild(0);
        ChangeState();
    }

    // Update is called once per frame
    void Update()
    {
        if (activatable && Input.GetKeyDown(KeyCode.B))
        {
            ChangeState();
        }
    }
    private void ChangeState()
    {
        lantern.gameObject.SetActive(actualLanternState);
        actualLanternState = !actualLanternState;
    }
    private void OnEnable()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        activatable = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        activatable = false;
    }
}
