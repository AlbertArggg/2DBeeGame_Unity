using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int musicVol;
    public int gameMusicVol;
    public int sdfxVol;
    public int sensitivity;
    public int highScore;
    public int diamonds;
    public int custItem;

    public PlayerData(int _musicVol, int _gameMusicVol, int _sdfxVol, int _sensitivity, int _highScore, int _diamonds, int _custItem)
    {
        musicVol = _musicVol;
        gameMusicVol = _gameMusicVol;
        sdfxVol = _sdfxVol;
        sensitivity = _sensitivity;
        highScore = _highScore;
        diamonds = _diamonds;
        custItem = _custItem;
        if (highScore == null) { highScore = 0; }
        if (diamonds == null) { diamonds = 0; }
    }
}
