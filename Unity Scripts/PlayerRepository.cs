using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerRepository : Singleton<PlayerRepository>
    {
    string PlayerControllerURL = "http://www.memoryexam.edu/Memory/Player/";

    public void ProcessPlayers(DBPlayer player)
    {
        StartCoroutine(PostPlayer(player));
    }

    private IEnumerator PostPlayer(DBPlayer player)
    {
            string json = JsonConvert.SerializeObject(player);
            UnityWebRequest uwr = UnityWebRequest.Put(PlayerControllerURL, json);
            uwr.SetRequestHeader("content-type", "application/json");
            uwr.method = "POST";
            yield return uwr.SendWebRequest();

            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Post Player error: " + uwr.error);
            }
            else
            {
                string returnJson = uwr.downloadHandler.text;
                DBPlayer returnPlayer = JsonConvert.DeserializeObject<DBPlayer>(returnJson);
                Debug.Log("PlayerID " + returnPlayer.PlayerId + " Player Name: " + returnPlayer.Name + " Player Score: " + returnPlayer.Score);
            }
    }

}
