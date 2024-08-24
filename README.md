# Leaderboard Popup Test Task - Oleksandr Serebriakov


All services, including PopUpManagerService are accessible through zenject dependency injection.<br>
Views (MonoBehaviour classes) do not use them directly, they communicate with Presenter classes to access data and invoke callbacks.

## Entry point

Entry point of the application is Loader.cs class. It is placed in the Main scene.
It initializes needed services and starts LeaderboardSceneController.

### LeaderboardSceneController

LeaderboardSceneController class is something like a state that's purpose to connect logic within one game state (e.g. main menu, settings, gameplay scene) didn't have time to implement state machine logic so there is just LeaderboardSceneController.
LeaderboardSceneController uses PopUpManager to open and close popups.

### ILeaderboardPresenter

As a parameter to initialize leaderboard popup I'm using ILeaderboardPresenter interface.
This presenter is used by Leaderboard View class to get data and connection to the ui factory.
Also it communicates with LeaderboardSceneController through an Action event to change pop ups from main menu to a leaderboard.

### Additional

I added optional Transform parameter to OpenPopUp method in PopUpManagerService to place instatiated pop up under current canvas.
To optimize the solution I would suggest to load only images that are visible at the screen. Also, ObjectPool pattern would fit here well, especially if there would be more leaderboard entries, like infinite scroll.

I would Complete callback to IPopUpInitialization interface, so the pop ups actually knew when all async initializations have been completed.
