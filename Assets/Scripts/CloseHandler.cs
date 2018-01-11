using UnityEngine;

public class CloseHandler: MonoBehaviour {

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            // Android close icon or back button tapped.
            Application.Quit();
        }
    }
}
