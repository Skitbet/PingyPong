using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PingyPong
{
    
    public class GameStateManager
    {
        public GameState CurrentState { get; private set; }

        public GameStateManager()
        {
            CurrentState = GameState.MainMenu;
        }
        
        public void ChangeState(GameState newState)
        {
            CurrentState = newState;
        }
    }
}
