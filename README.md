# LudumDare2D basic template

## Contains

- General event system via scriptable objects
  - to trigger an event to which anyone can respond
  - good for getting rid of the "Singleton" over usage 
- Scene transitions
  - Simple scene transition object
    - as it is now it is based on the animator with two states, but it is prepared for shader transitions in future   
- Type writter
  - it will take text and make it appear letter by letter
  - start of the future dialogue system
- CustomYieldInstruction taking Func<Bool>
  - help to pause coroutine while waiting for some state to happen (like paused game)
  - waits while true, run while false 
  - https://docs.unity3d.com/ScriptReference/CustomYieldInstruction.html


## Planned

- 2D APathFinding algorithm where walkable area will be set by polygon collider
  - probably with some solution for steering behavior 
- Dialogue system 
- AI skeleton
  - StateMachine
  - GOAP
- Leaderboard with own microservice
 
