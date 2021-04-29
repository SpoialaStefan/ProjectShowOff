using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class ClientInstance : NetworkBehaviour
{

    public static ClientInstance Instance;

    [SerializeField]
    private NetworkIdentity _playerPrefab = null;

    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkSpawnPlayer();
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        Instance = this;
    }

    [Server]
    private void NetworkSpawnPlayer()
    {
        GameObject playerClient = Instantiate(_playerPrefab.gameObject, transform.position, Quaternion.identity);
        NetworkServer.Spawn(playerClient, base.connectionToClient);
    }

    public static ClientInstance GetClientInstance(NetworkConnection conn = null)
    {
        if (NetworkServer.active && conn != null)
        {
            NetworkIdentity localPlayer;
            if (CustomNetworkManager.LocalPlayers.TryGetValue(conn, out localPlayer))
                return localPlayer.GetComponent<ClientInstance>();
            else
                return null;
        }
        else
        {
            return Instance;
        }
    }
}
