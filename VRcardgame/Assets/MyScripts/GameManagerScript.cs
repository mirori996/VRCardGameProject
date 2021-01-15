using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManagerScript : MonoBehaviourPunCallbacks
{
    public GameObject cube;
    public bool isVR = true;
    public int player;

    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinOrCreateRoom("room", new RoomOptions(), TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        // マッチング後、自分自身のネットワークオブジェクトを生成する
        var v = new Vector3(0, 0, 0);
        PhotonNetwork.Instantiate("ObjectManagerPrefab", v, Quaternion.identity);
    }
}
