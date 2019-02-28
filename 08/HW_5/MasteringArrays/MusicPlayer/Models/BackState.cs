using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class BackState : PlayStateBase, IState
    {
        IState IState.RunState()
        {
            HandlerEsc handlerEsc = HandLoopForward;
            HeaderState(StBack);

            handlerEsc();

            FooterState();
            return new MenuPlay();
        }

        private static void HandLoopForward()
        {
            //do
            //{
                SongHandler(Back);
            //} while (!ControlEvent);
        }

        private delegate void HandlerEsc();
    }
}