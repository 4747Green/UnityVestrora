using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOpenner : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Panel;
    public GameObject SecondaryPanel;
    public GameObject[] Panels;

    public void OpenPanel()
    {

        CloseAllOtherPanels();

        if (Panel != null)
        {

            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }

        if (SecondaryPanel != null)
        {

            bool isActive = SecondaryPanel.activeSelf;
            SecondaryPanel.SetActive(!isActive);
        }
    }

    public void CloseAllOtherPanels()
    {
        if (Panels != null || Panels.Length != 0)
        {
            foreach (var item in Panels)
            {
                item.SetActive(false);
            }
        }

    }




}
