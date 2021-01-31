using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreManager {
    private static int sitaPortal;

    private static int enemiesKilled;
    public static void ResetScore() {
        enemiesKilled = 0;
    }

    public static void OnEnemyKilled() {
        enemiesKilled++;
    }
    public static bool CanSpawnSita() {
        return enemiesKilled % 200 == 0;
    }

    public static void GenerateSitaPortal() {
        sitaPortal = Random.Range(1, 5);
    }

    public static bool IsSitaPortal(int id) {
        return sitaPortal == id;
    }
}
