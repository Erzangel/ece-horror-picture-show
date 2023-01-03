# Exporting an AR movie from the Unity engine

This Markdown file documents my attempts & reasoning at exporting a hard-coded Unity scene to a file that can be downlaoded by a third-party app & read by Unity.

This was done in the context of the ECE Horror Picture Show project.

## How does an AR movie work currently?

We have built an engine to play AR movies in Unity. This engine uses a framework we have built ourselves that defines **Event C# classes**.

An **Event** is an abstract C# class. As its namesake implies, it represents an Event in the AR movie, which can really be anything Unity can do from code. Examples would be a Zombie appearing, or simply a sound playing after some time.

An Event has a set of properties, for example:

- A string ID
- A boolean indicating if it is done
- An `is_active` flag
- A reference to a GameObject which follows the AR camera called `dummy`
- A List<GameObject> of prefabs used, and a List<GameObject> of instances of those prefabs, cleaned up on Event deletion with the Clear() method
- An Awake() method initializing everything

The full definition of the Event class [can be found here](../Assets/Scripts/Event.cs).

Examples of Events implementing this class are [Event0]((../Assets/Scripts/Event0.cs) or [Event1]((../Assets/Scripts/Event1.cs)

## ScriptedEvent class

There is a [ScriptedEvent class](../Assets/Scripts/ScriptedEvents.cs) which handles all events. After a given timer, it plays the first event, Event0.

Events then call each other using the playEvent<T>() and clearEvent<T>() methods from the ScriptedEvent class. Event0 can call eventManager.playEvent<Event1>() to play Event1 when it is done.

## How to export this implementation as external files?

Multiple AR implementations in Unity are possible. We have created a framework, but AR producers might not use entirely.

A common resource in Unity is a Scene. We may want to **load scenes and required assets/scripts for a movie**. Exporting the raw source files might be a problem, though.

## References to achieve this

Here are links containing indications on how to achieve the link between a catalog app downloading the scenes and the Unity player

- Loading scenes:
  - [How to load a Unity Scene at runtime](https://docs.unity3d.com/Packages/com.unity.entities@0.50/manual/loading_scenes.html)
  - [Loading a Scene from a .unity file](https://answers.unity.com/questions/1463977/load-scene-from-unity-file.html)
- Using Deep Linking (opening an app with another app with a context)
  - [Linking in React Native](https://reactnative.dev/docs/linking)
  - [Stackoverflow thread: saving files in React Native](https://stackoverflow.com/questions/44376002/what-are-my-options-for-storing-data-when-using-react-native-ios-and-android)
  - [Enabling Deep Linking in an Unity app](https://docs.unity3d.com/Manual/deep-linking.html)