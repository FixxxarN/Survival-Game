using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets
{
    public enum MenuState
    {
        mainMenu,
        selection,
        characterSelection,
        characterCreation,
        worldSelection,
        worldCreation,
        achievements,
        settings
    }

    public static class MenuStateHandler
    {
        public static MenuState currentMenuState;
    }
}
