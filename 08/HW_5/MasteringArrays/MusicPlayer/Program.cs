namespace MusicPlayer
{
    internal class Program
    {
        //private static void Test()
        //{
        //    var menuState = new ConfigurableMenuState();
        //    menuState.AddMenuItem(1, new MenuItem {Text = "Option 1"},
        //                          () => new AuthState());
        //    menuState.AddMenuItem(2, new MenuItem {Text = "Exit"},
        //                          () => null);

        //    IState startState = menuState;
        //    while (startState != null) startState = startState.RunState();
        //}

        private static void Test()
        {
            IState startState = new MenuStateGlobal();
            while (startState != null) startState = startState.RunState();
        }

        private static void Main()
        {
            Test();
        }
    }
}