using MusicPlayer.Interface;

namespace MusicPlayer.Models
{
    public class ForwardState : PlayStateBase, IState
    {
        IState IState.RunState()
        {
            HandlerEsc handlerEsc = HandLoopForward;
            HeaderState(StForward);

            handlerEsc();

            FooterState();
            return new MenuPlay();
        }

        private static void HandLoopForward()
        {
            //do
            //{
                SongHandler();
            //} while (!ControlEvent);
        }

        private delegate void HandlerEsc();
    }
}