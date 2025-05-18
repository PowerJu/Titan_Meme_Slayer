using UnityEngine;

namespace TMS.Event
{
    public class GameStartEvent
    {
    }

    public class GameClearEvent
    {
    }

    public class AcquireCoinEvent
    {
        public int CoinScore { get; }

        public AcquireCoinEvent(int coinScore)
        {
            CoinScore = coinScore;
        }
    }

    public class UpdateScoreEvent
    {
        public int Score { get; }

        public UpdateScoreEvent(int score)
        {
            Score = score;
        }
    }
}