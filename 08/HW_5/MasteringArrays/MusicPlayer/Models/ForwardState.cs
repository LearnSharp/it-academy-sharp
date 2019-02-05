using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class ForwardState : PlayStateBase, IState
    {
        private delegate void HandlerEsc();

        IState IState.RunState()
        {
            HandlerEsc handlerEsc= HandLoopForward;
            HeaderState(CurrentPlaylist, StForward);

            handlerEsc();

            FooterState();
            return new MenuPlay();
        }

        private void HandLoopForward()
        {
            do SongHandler(CurrentPlaylist);
            while (!ControlEvent);
        }
    }
}