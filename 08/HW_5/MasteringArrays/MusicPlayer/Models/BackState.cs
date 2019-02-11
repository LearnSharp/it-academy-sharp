using MusicPlayer.Interface;
using static MusicPlayer.Program;

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
            do
            {
                SongHandler(CurrentPlaylist, Back);
            } while (!ControlEvent);
        }

        private delegate void HandlerEsc();
    }
}