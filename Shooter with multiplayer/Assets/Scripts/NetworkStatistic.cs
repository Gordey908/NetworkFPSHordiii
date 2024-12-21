using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NetworkStatisic : MonoBehaviour
{  
    private void Start()
    {
        StartCoroutine(UpdateConnectedPlayerCount());
    }
    private IEnumerator UpdateConnectedPlayerCount()
    {
        yield return new WaitForSeconds(3);
        while (true)
        {
            yield return new WaitForSeconds(5);
            UIManager.Instance.ChangeConnectedPlayersText(PhotonNetwork.CountOfPlayers);
        }
    }
}
