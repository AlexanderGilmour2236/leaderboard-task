using System;
using System.Collections.Generic;
using LeaderboardTask.View;

namespace LeaderboardTask
{
    public interface ILeaderboardPresenter
    {
        event Action<string> PopUpChange;
        LeaderboardEntryView[] GetLeaderboardEntryViews(List<LeaderboardEntryData> entryDataCollection);
        public List<LeaderboardEntryData> GetLeaderboardEntryDataCollection(bool update = false);
        void OnCloseButtonClick();
    }
}
