using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
    GameManager does the following:
        --- SETUP ---
        1. Takes player through Setup phase, where they can configure what they want
        2. Sets up the board

        --- GAME ---
        1. Queries next player to take a turn
        2. Waits for their move to be submitted
        3. Resolves the move
        4. Checks if the game is over, if so, moves to game end

        --- END ---
        1. Determines game outcome
        2. Shows the outcome
*/
public class GameManager : MonoBehaviour
{
    // ======================================================================== //
    // =========    Variable Declarations        ============================== //
    // ======================================================================== //

    // ------- Helper classes ---------------- //
    [System.Serializable]
    public class PlayerData
    {
        public bool isHuman = true;
        public Color color;
        public string name;
        // public bool isLocal = true;
    }
    [System.Serializable]
    public class GameSettings
    {
        public PlayerData[] players;
    }

    
    // ------- Public vars ---------------- //
    public GameSettings gameSettings;
    public jsch.JewelHeist.TurnManager turnManager;

    // singleton instance
    public static GameManager instance;
    
    
    // ------- Private vars ---------------- //
    private IPlayer[] players;
    private int currentPlayerIndex;




    // ======================================================================== //
    // =========    Lifecycle Methods            ============================== //
    // ======================================================================== //


    void Awake()
    {
        // ensure singleton instance 
        if(GameManager.instance != null && GameManager.instance != this) {
            Destroy(this.gameObject);
        }
        else {
            GameManager.instance = this;
        }
    }

    void Start()
    {
        SetupGame();
        QueryCurrentPlayerTurn();
    }




    // ======================================================================== //
    // =========    Public Methods               ============================== //
    // ======================================================================== //


    // to be called by players to submit their move
    public void SubmitMove(IMove move)
    {
        // resolve move
        move.Resolve();

        // go to the next player
        currentPlayerIndex = (currentPlayerIndex + 1) % players.Length;

        // query the next player to take their turn
        QueryCurrentPlayerTurn();
    }




    // ======================================================================== //
    // =========    Private Methods               ============================== //
    // ======================================================================== //



    private void QueryCurrentPlayerTurn()
    {
        Debug.Log("querying player!");
        IPlayer currentPlayer = players[currentPlayerIndex];
        Camera.main.backgroundColor = currentPlayer.color;

        currentPlayer.TakeTurn();
        turnManager.BeginPlayerTurn(currentPlayer);
    }


    private bool IsGameOver()
    {
        return false;
    }


    private void SetupGame()
    {
        // init players array
        players = new IPlayer[gameSettings.players.Length];

        // foreach player in Game Settings, make a new player
        for(int i = 0; i < players.Length; i++) {
            IPlayer player = new HumanPlayer();
            if(gameSettings.players[i].isHuman) {
                player = new HumanPlayer();
                player.color = gameSettings.players[i].color;
                player.name = gameSettings.players[i].name;
            }
            else {
                Debug.LogError($"You tried to play with a computer player, but that isn't supported yet!");
            }

            players[i] = player;
        }

        Debug.Log("done setting up game!");
    }
}
