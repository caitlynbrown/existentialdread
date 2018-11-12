﻿using UnityEngine;
using Prototype.NetworkLobby;
using System.Collections;
using UnityEngine.Networking;

public class NetworkLobbyHook : LobbyHook 
{
    public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
    {
        LobbyPlayer lobby = lobbyPlayer.GetComponent<LobbyPlayer>();
		SetupLocalPlayer localPlayer = gamePlayer.GetComponent<SetupLocalPlayer>();

		//localPlayer.name = lobby.playerName;
		//localPlayer.playerColor = lobby.playerColor;
        //spaceship.score = 0;
       // spaceship.lifeCount = 3;
    }
}
