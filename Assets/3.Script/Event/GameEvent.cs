using UnityEngine;

namespace TMS.Event
{
    public class GameStartEvent
    {
    }

    public class PlayStartEvent
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

    // 코인 습득, 게임 내 점수가 다른 요소라고 기획하셨던거 같아서 게임스코어용 이벤트 하나 만들겠습니다.
    // 코인 습득 이벤트와 동일하게 게임 매니저에서 스코어 습득 이벤트 구독
    // 플레이어 혹은 생존 시간에 따라 스코어 습득, 이벤트 발행. ( 스코어 습득 조건에 대한 기획이 정해져있지 않아서 PlayerEntity 클래스의 Update에서 1씩 발행 하겠습니다. )
    public class AcquireGameScoreEvent
    {
        public int GameScore { get; }

        public AcquireGameScoreEvent(int gameScore)
        {
            GameScore = gameScore;
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

    public class UpdateGameScoreEvent
    {
        public int GameScore { get; }

        public UpdateGameScoreEvent(int gameScore)
        {
            GameScore = gameScore;
        }
    }
    
    
}