using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Reference

{
    public enum GameStates { Menu, Game, Over }

    public static class GameState
    {
        static GameStates currentState;
        public static void SetState(GameStates newState)
        {
            currentState = newState;
        }

        public static GameStates GetState()
        {
            return currentState;
        }
    }

}


