<h3>Ledearboard task</h3>

Oleksander Serebriakov
<br>
<br>
All services, including PopUpManagerService are accessible through zenject dependency injection.
<br>
Views (MonoBehaviour classes) do not use them directly, they communicate with Presenter classes to access data and invoke callbacks. 
<h3>Entry point</h3>
Entry point of the application is Loader.cs class. It is placed in the Main scene.
<br>
It initializes needed services and starts LeaderboardSceneController.
<br>

<h4>LeaderboardSceneController </h4>

LeaderboardSceneController class is something like a state that's purpose to connect logic within one game state (e.g. main menu, settings, gameplay scene)
didn't have time to implement state machine logic so there is just LeaderboardSceneController.
<br>
<br>
LeaderboardSceneController uses PopUpManager to open and close popups.
<br>
<h4>ILeaderboardPresenter</h4>
As a parameter to initialize leaderboard popup I'm using ILeaderboardPresenter interface.
<br>
This presenter is used by Leaderboard View class to get data and connection to the ui factory. 
<br>
Also it communicates with LeaderboardSceneController through an Action event to change pop ups from main menu to a leaderboard.
<br>

<h3>Additional</h3>
I added optional Transform parameter to OpenPopUp method in PopUpManagerService to place instatiated pop up under current canvas.

To optimize the solution I would suggest to load only images that are visible at the screen.
Also, ObjectPool pattern would fit here well, especially if there would be more leaderboard entries, like infinite scroll.
<br><br>
I would Complete callback to IPopUpInitialization interface, so the pop ups actually knew when all async initializations have been completed. 