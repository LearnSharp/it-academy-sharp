using MusicPlayer.Interface;
using static MusicPlayer.Program;

namespace MusicPlayer.Models
{
    public class BackState : PlayStateBase, IState
    {
        private delegate void HandlerEsc();

        IState IState.RunState()
        {
            HandlerEsc handlerEsc = HandLoopForward;
            HeaderState(CurrentPlaylist, StBack);

            handlerEsc();

            FooterState();
            return new MenuPlay();
        }

        private void HandLoopForward()
        {
            do SongHandler(CurrentPlaylist, Back);
            while (!ControlEvent);
        }
    }
}