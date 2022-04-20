using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ClosedXML.Excel;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CollisionManagement;
using COMP3401OO_Engine.CollisionManagement.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.Delegates.Interfaces;
using COMP3401OO_Engine.EntityManagement;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO_Engine.Exceptions;
using COMP3401OO_Engine.Factories;
using COMP3401OO_Engine.Factories.Interfaces;
using COMP3401OO_Engine.InputManagement;
using COMP3401OO_Engine.InputManagement.Interfaces;
using COMP3401OO_Engine.SceneManagement;
using COMP3401OO_Engine.SceneManagement.Interfaces;
using COMP3401OO_Engine.Services.Interfaces;
using COMP3401OO.PongPackage.Behaviours;
using COMP3401OO.PongPackage.Delegates.Interfaces;
using COMP3401OO.PongPackage.Entities;
using COMP3401OO.PongPackage.Forms;
using COMP3401OO_ProjectHWTest;
using COMP3401OO.ProjectHWTest.Interfaces;
using COMP3401OO_Engine.CustomEventArgs;

namespace COMP3401OO
{
    /// <summary>
    /// Main Class of OO System
    /// Author: William Smith
    /// Date: 06/04/22
    /// </summary>
    public class Kernel : Game
    {
        #region FIELD VARIABLES

        // DECLARE an IDictionary<string, IService>, name it '_serviceDict':
        private IDictionary<string, IService> _serviceDict;

        // DECLARE an IDictionary<string, IEntity>, name it '_entityDict':
        private IDictionary<string, IEntity> _entityDict;

        // DECLARE a Form, name it '_entityCreator':
        private Form _entityCreator;

        // DECLARE a GraphicsDeviceManager, name it '_graphics':
        private GraphicsDeviceManager _graphics;

        // DECLARE a SpriteBatch, name it '_spriteBatch':
        private SpriteBatch _spriteBatch;

        // DECLARE a Random, name it '_rand':
        private Random _rand;

        // DECLARE a Point, used to store Screen size, name it 'screenSize':
        private Point _screenSize;

        // DECLARE an int, name it '_p1Score':
        private int _p1Score;

        // DECLARE an int, name it '_p2Score':
        private int _p2Score;

        // DECLARE an int, name it '_ballCount':
        private int _ballCount;

        #endregion


        #region CONSTRUCTOR

        /// <summary>
        /// Constructor for objects of Kernel
        /// </summary>
        public Kernel()
        {
            // INSTANTIATE _serviceDict as a new Dictionary<string, IService>():
            _serviceDict = new Dictionary<string, IService>();

            // INSTANTIATE _graphics as new GraphicsDeviceManager, passing Kernel as a parameter:
            _graphics = new GraphicsDeviceManager(this);

            // INSTANTIATE _entityCreator as a new CreationScreen():
            _entityCreator = new CreationScreen();

            // SET RootDirectory of Content to "Content":
            Content.RootDirectory = "Content";

            // SET IsMouseVisible to true:
            IsMouseVisible = true;

            // SET screen width to 1600:
            _graphics.PreferredBackBufferWidth = 1600;

            // SET screen height to 900:
            _graphics.PreferredBackBufferHeight = 900;

            // INITIALISE _p1Score with a value of '0':
            _p1Score = 0;

            // INITIALISE _p2Score with a value of '0':
            _p2Score = 0;

            // INITIALISE _ballCount with a value of '0':
            _ballCount = 0;
        }

        #endregion


        #region PROTECTED METHODS

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            #region MONOGAME SETTINGS

            // INITIALISE _screenSize.X with value of Viewport.Width:
            _screenSize.X = GraphicsDevice.Viewport.Width;

            // INITIALISE _screenSize.Y with value of Viewport.Height:
            _screenSize.Y = GraphicsDevice.Viewport.Height;

            // INITIALISE _entityCreator with reference to CreateMultipleEntities():
            (_entityCreator as IInitialiseCreateMultiDel).Initialise(CreateMultipleEntities);

            // INITIALISE _entityCreator with reference to DeleteMultipleEntities():
            (_entityCreator as IInitialiseDeleteMultiDel).Initialise(DeleteMultipleEntities);

            // SHOW _entityCreator:
            _entityCreator.Show();

            // INSTANTIATE _rand as new Random():
            _rand = new Random();

            #endregion

            // TRY checking if any creation or initialisation throws an exception:
            try
            {
                #region FACTORY INSTANTIATIONS

                // ADD a new Factory<IService>() to _serviceDict:
                _serviceDict.Add("ServiceFactory", new Factory<IService>());

                // ADD a new Factory<IDisposable>() to _serviceDict:
                _serviceDict.Add("DisposableFactory", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<Factory<IDisposable>>());

                // ADD a new Factory<IEnumerable>() to _serviceDict:
                _serviceDict.Add("EnumerableFactory", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<Factory<IEnumerable>>());

                // ADD a new Factory<IEntity>() to _serviceDict:
                _serviceDict.Add("EntityFactory", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<Factory<IEntity>>());

                // ADD a new Factory<IUpdateEventListener>() to _serviceDict:
                _serviceDict.Add("BehaviourFactory", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<Factory<IUpdateEventListener>>());

                // ADD a new Factory<EventArgs>() to _serviceDict:
                _serviceDict.Add("EventArgsFactory", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<Factory<EventArgs>>());

                #endregion


                #region MANAGER INSTANTIATIONS & INITIALISATIONS

                #region INSTANTIATIONS

                // ADD a new EntityManager() to _serviceDict:
                _serviceDict.Add("EntityManager", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<EntityManager>());

                // STORE reference to master entity list locally for easier reuse:
                _entityDict = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary();

                // ADD a new SceneManager() to _serviceDict:
                _serviceDict.Add("SceneManager", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<SceneManager>());

                // ADD a new CollisionManager() to _serviceDict:
                _serviceDict.Add("CollisionManager", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<CollisionManager>());

                // ADD a new KeyboardManager() to _serviceDict:
                _serviceDict.Add("KeyboardManager", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<KeyboardManager>());

                #endregion


                #region INITIALISATIONS

                // INITIALISE _serviceDict["EntityManager"] with reference to _serviceDict["EntityFactory"]:
                (_serviceDict["EntityManager"] as IInitialiseIEntityFactory).Initialise(_serviceDict["EntityFactory"] as IFactory<IEntity>);

                // INITIALISE _serviceDict["EntityManager"] with reference to _serviceDict["SceneManager"]:
                (_serviceDict["EntityManager"] as IEntityManager).Initialise(_serviceDict["SceneManager"] as ISceneManager);

                // INITIALISE _serviceDict["EntityManager"] with reference to _serviceDict["KeyboardManager"]:
                (_serviceDict["EntityManager"] as IEntityManager).Initialise(_serviceDict["KeyboardManager"] as IKeyboardPublisher);

                // INITIALISE _serviceDict["SceneManager"] with reference to _serviceDict["CollisionManager"]:
                (_serviceDict["SceneManager"] as ISceneManager).Initialise(_serviceDict["CollisionManager"] as ICollisionManager);

                // INITIALISE _serviceDict["SceneManager"], passing a new SceneGraph as a parameter:
                (_serviceDict["SceneManager"] as ISceneManager).Initialise((_serviceDict["ServiceFactory"] as IFactory<IService>).Create<SceneGraph>() as ISceneGraph);

                #endregion

                #endregion


                #region PERFORMANCE MEASURE INSTANTIATION & INITIALISATIONS

                // ADD a new PerformanceMeasure() to _serviceDict:
                _serviceDict.Add("PerformanceMeasure", (_serviceDict["ServiceFactory"] as IFactory<IService>).Create<PerformanceMeasure>());

                // INITIALISE _serviceDict["PerformanceMeasure"] with a new Stopwatch():
                (_serviceDict["PerformanceMeasure"] as IInitialiseStopwatch).Initialise(new Stopwatch());

                // INITIALISE _serviceDict["PerformanceMeasure"] with a new XLWorkbook():
                (_serviceDict["PerformanceMeasure"] as IExportExcelData).Initialise((_serviceDict["DisposableFactory"] as IFactory<IDisposable>).Create<XLWorkbook>() as XLWorkbook);

                // INITIALISE _serviceDict["PerformanceMeasure"] with a new List<long>():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise((_serviceDict["EnumerableFactory"] as IFactory<IEnumerable>).Create<List<long>>() as IList<long>);

                // INITIALISE _serviceDict["PerformanceMeasure"] with "CPU" and a new PerformanceCounter():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise("CPU", new PerformanceCounter("Process", "% Processor Time", "COMP3401OO"));

                // INITIALISE _serviceDict["PerformanceMeasure"] with "CPU" and a new List<float>():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise("CPU", (_serviceDict["EnumerableFactory"] as IFactory<IEnumerable>).Create<List<float>>() as IList<float>);

                // INITIALISE _serviceDict["PerformanceMeasure"] with "RAM" and a new PerformanceCounter():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise("RAM", new PerformanceCounter("Process", "Working Set", "COMP3401OO"));

                // INITIALISE _serviceDict["PerformanceMeasure"] with "RAM" and a new List<float>():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise("RAM", (_serviceDict["EnumerableFactory"] as IFactory<IEnumerable>).Create<List<float>>() as IList<float>);

                // INITIALISE _serviceDict["PerformanceMeasure"] with "FPS" and a new List<float>():
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).Initialise("FPS", (_serviceDict["EnumerableFactory"] as IFactory<IEnumerable>).Create<List<float>>() as IList<float>);

                #endregion


                #region DISPLAYABLE CREATION

                #region BACKGROUND

                // DECLARE & INSTANTIATE an IEntity as a new DrawableEntity(), name it '_tempEntity':
                IEntity _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).Create<DrawableEntity>("Background");

                #endregion

                /*
                #region PADDLE 1

                #region BEHAVIOURS

                /// INSTANTIATION

                // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it '_tempBehaviour':
                IUpdateEventListener _tempBehaviour = (_serviceDict["BehaviourFactory"] as IFactory<IUpdateEventListener>).Create<PaddleBehaviour>();

                /// INITIALISATION

                // INITIALISE _tempBehaviour with a new Paddle():
                (_tempBehaviour as IInitialiseIEntity).Initialise((_serviceDict["EntityManager"] as IEntityManager).Create<Paddle>("Paddle1"));


                #endregion


                #region ENTITY

                /// INSTANTATION

                // INITIALISE _tempEntity with "Paddle1" from EntityManager.GetDictionary():
                _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Paddle1"];

                /// INITIALISATION

                // INITIALISE "Paddle1" with reference to _tempBehaviour:
                (_tempEntity as IInitialiseIUpdateEventListener).Initialise(_tempBehaviour);

                // INITIALISE "Paddle1" with a new UpdateEventArgs():
                (_tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<UpdateEventArgs>());

                // INITIALISE "Paddle1" with a new KBEventArgs():
                (_tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<KBEventArgs>());

                // SUBSCRIBE "Paddle1" to KeyboardManager:
                (_serviceDict["KeyboardManager"] as IKeyboardPublisher).Subscribe(_tempEntity as IKeyboardListener);

                // ASSIGNMENT, set PlayerNum value as PlayerIndex.One:
                (_tempEntity as IPlayer).PlayerNum = PlayerIndex.One;

                // SET boundary size for "Paddle1":
                (_tempEntity as IContainBoundary).WindowBorder = _screenSize;

                #endregion

                #endregion

                #region PADDLE 2

                #region BEHAVIOURS

                /// INSTANTIATION

                // INSTANTIATE _tempBehaviour as a new PaddleBehaviour():
                _tempBehaviour = (_serviceDict["BehaviourFactory"] as IFactory<IUpdateEventListener>).Create<PaddleBehaviour>();

                /// INITIALISATION

                // INITIALISE _tempBehaviour with a new Paddle():
                (_tempBehaviour as IInitialiseIEntity).Initialise((_serviceDict["EntityManager"] as IEntityManager).Create<Paddle>("Paddle2"));

                #endregion


                #region ENTITY

                /// INSTANTATION

                // INITIALISE _tempEntity with "Paddle2" from EntityManager.GetDictionary():
                _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Paddle2"];

                /// INITIALISATION

                // INITIALISE "Paddle2" with reference to _tempBehaviour:
                (_tempEntity as IInitialiseIUpdateEventListener).Initialise(_tempBehaviour);

                // INITIALISE "Paddle2" with a new UpdateEventArgs():
                (_tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<UpdateEventArgs>());

                // INITIALISE "Paddle2" with a new KBEventArgs():
                (_tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<KBEventArgs>());

                // SUBSCRIBE "Paddle2" to KeyboardManager:
                (_serviceDict["KeyboardManager"] as IKeyboardPublisher).Subscribe(_tempEntity as IKeyboardListener);

                // ASSIGNMENT, set PlayerNum value as PlayerIndex.Two:
                (_tempEntity as IPlayer).PlayerNum = PlayerIndex.Two;

                // SET boundary size for "Paddle2":
                (_tempEntity as IContainBoundary).WindowBorder = _screenSize;

                #endregion

                #endregion
                */

                #endregion
            }
            // CATCH ClassDoesNotExistException from object creation:
            catch (ClassDoesNotExistException e)
            {
                // PRINT exception message to console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullInstanceException from object initialisation:
            catch (NullInstanceException e)
            {
                // PRINT exception message to console:
                Console.WriteLine(e.Message);
            }
            // CATCH NullReferenceException from delegate initialisation:
            catch (NullReferenceException e)
            {
                // PRINT exception message to console:
                Console.WriteLine(e.Message);
            }

            // INITIALISE base class:
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // INSTANTIATE _spriteBatch as new SpriteBatch:
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            #region BACKGROUND

            // DECLARE & INITIALISE an IEntity, name it '_tempEntity', give instance of "Background":
            IEntity _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Background"];

            // LOAD "Background" texture to "Background":
            (_tempEntity as ITexture).Texture = Content.Load<Texture2D>("Background");

            // SPAWN "Background" on screen at top left corner:
            (_serviceDict["SceneManager"] as ISpawn).Spawn(_tempEntity, Vector2.Zero);

            #endregion

            /*

            #region PADDLES

            #region PADDLE 1

            // INITIALISE _tempEntity with instance of "Paddle1":
            _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Paddle1"];

            // ADD "Paddle1_DFLT" as a key and "Paddle1_DFLT" as a Texture2D to _tempEntity.ReturnTextureDict():
            (_tempEntity as IRtnTextureDict).ReturnTextureDict().Add("Paddle1_DFLT", Content.Load<Texture2D>("Paddle1_DFLT"));

            // ADD "Paddle1_INPT" as a key and "Paddle1_INPT" as a Texture2D to _tempEntity.ReturnTextureDict():
            (_tempEntity as IRtnTextureDict).ReturnTextureDict().Add("Paddle1_INPT", Content.Load<Texture2D>("Paddle1_INPT"));

            // SET Texture Property value of "Paddle1" to "Paddle1_DFLT" stored in _tempEntity.ReturnTextureDict():
            (_tempEntity as ITexture).Texture = (_tempEntity as IRtnTextureDict).ReturnTextureDict()["Paddle1_DFLT"];

            // SET Origin Property value of "Paddle1" to centre of Texture:
            (_tempEntity as IRotation).Origin = new Vector2((_tempEntity as ITexture).TexSize.X / 2, (_tempEntity as ITexture).TexSize.Y / 2);

            // SPAWN "Paddle1" on screen at the far left middle of the screen:
            (_serviceDict["SceneManager"] as ISpawn).Spawn(_tempEntity, new Vector2((_tempEntity as ITexture).TexSize.X, _screenSize.Y / 2));

            #endregion


            #region PADDLE 2

            // INITIALISE _tempEntity with instance of "Paddle2":
            _tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Paddle2"];

            // ADD "Paddle2_DFLT" as a key and "Paddle2_DFLT" as a Texture2D to _tempEntity.ReturnTextureDict():
            (_tempEntity as IRtnTextureDict).ReturnTextureDict().Add("Paddle2_DFLT", Content.Load<Texture2D>("Paddle2_DFLT"));

            // ADD "Paddle2_INPT" as a key and "Paddle2_INPT" as a Texture2D to _tempEntity.ReturnTextureDict():
            (_tempEntity as IRtnTextureDict).ReturnTextureDict().Add("Paddle2_INPT", Content.Load<Texture2D>("Paddle2_INPT"));

            // SET Texture Property value of "Paddle2" to "Paddle2_DFLT" stored in _tempEntity.ReturnTextureDict():
            (_tempEntity as ITexture).Texture = (_tempEntity as IRtnTextureDict).ReturnTextureDict()["Paddle2_DFLT"];

            // SET Origin Property value of "Paddle2" to centre of Texture:
            (_tempEntity as IRotation).Origin = new Vector2((_tempEntity as ITexture).TexSize.X / 2, (_tempEntity as ITexture).TexSize.Y / 2);

            // SPAWN "Paddle2" on screen at the far right middle of the screen:
            (_serviceDict["SceneManager"] as ISpawn).Spawn(_tempEntity, new Vector2(_screenSize.X - (_tempEntity as ITexture).TexSize.X, _screenSize.Y / 2));

            #endregion

            #endregion


            #region BALL

            // CALL SpawnBall(), handles creation and initialisation:
            SpawnBall();

            #endregion

            */

            // CALL CreateMultipleEntities(), passing 100 as a parameter:
            //CreateMultipleEntities(100);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="pGameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime pGameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Microsoft.Xna.Framework.Input.Keys.Escape))
            {
                // CALL Exit():
                Exit();
            }

            // CALL Update() on "SceneManager":
            (_serviceDict["SceneManager"] as IUpdatable).Update(pGameTime);

            // CALL Update() on "CollisionManager":
            (_serviceDict["CollisionManager"] as IUpdatable).Update(pGameTime);

            // CALL Update() on "KeyboardManager":
            (_serviceDict["KeyboardManager"] as IUpdatable).Update(pGameTime);

            // CALL LongTimedTest() on _serviceDict["PerformanceMeasure"], passing pGameTime as a parameter:
            //(_serviceDict["PerformanceMeasure"] as ITestPerformance).LongTimedTest(pGameTime);

            // CALL method from base Game class, uses gameTime as parameter:
            base.Update(pGameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="pGameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime pGameTime)
        {
            // SET colour of screen background as CornflowerBlue:
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // BEGIN creation of displayable objects:
            _spriteBatch.Begin();

            // CALL Draw() method on "SceneManager":
            (_serviceDict["SceneManager"] as IDraw).Draw(_spriteBatch);

            // CALL TestFPS() on _serviceDict["PerformanceMeasure"], passing pGameTime as a parameter:
            // CALLED IN DRAW() AS UPDATE() DOES NOT CHANGE FPS
            //(_serviceDict["PerformanceMeasure"] as ITestPerformance).TestFPS(pGameTime);

            // END creation of displayable objects:
            _spriteBatch.End();

            // CALL Draw() method from base class:
            base.Draw(pGameTime);
        }

        #endregion


        #region PRIVATE METHODS

        /// <summary>
        /// Spawns a Ball object on screen.
        /// </summary>
        private void SpawnBall()
        {
            // INCREMENT _ballCount by '1':
            _ballCount++;

            #region BEHAVIOURS

            /// INSTANTIATION

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it 'tempBehaviour':
            IUpdateEventListener tempBehaviour = (_serviceDict["BehaviourFactory"] as IFactory<IUpdateEventListener>).Create<BallBehaviour>();

            /// INITIALISATION
            
            // INITIALISE tempBehaviour with reference to CheckGoal():
            (tempBehaviour as IInitialiseCheckPosDel).Initialise(CheckGoal);

            // INITIALISE tempBehaviour with a new Ball():
            (tempBehaviour as IInitialiseIEntity).Initialise((_serviceDict["EntityManager"] as IEntityManager).Create<Ball>("Ball" + _ballCount));

            #endregion


            #region ENTITY

            /// INSTANTIATION

            // DECLARE & INITIALISE an IEntity with reference of '"Ball" + ballCount' from EntityManager.GetDictionary(), name it _tempEntity:
            IEntity tempEntity = (_serviceDict["EntityManager"] as IEntityManager).GetDictionary()["Ball" + _ballCount];

            /// INTIIALISATION

            // INITIALISE '"Ball" + _ballCount' with reference to _tempBehaviour:
            (tempEntity as IInitialiseIUpdateEventListener).Initialise(tempBehaviour);

            // INITIALISE '"Ball" + _ballCount' with a new UpdateEventArgs():
            (tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<UpdateEventArgs>());

            // INITIALISE '"Ball" + _ballCount' with a new CollisionEventArgs():
            (tempEntity as IInitialiseEventArgs).Initialise((_serviceDict["EventArgsFactory"] as IFactory<EventArgs>).Create<CollisionEventArgs>());

            // INITIALISE '"Ball" + _ballCount' with reference to rand:
            (tempEntity as IInitialiseRand).Initialise(_rand);

            // SET boundary size for '"Ball" + _ballCount':
            (tempEntity as IContainBoundary).WindowBorder = _screenSize;

            // LOAD "square" texture to '"Ball" + _ballCount':
            (tempEntity as ITexture).Texture = Content.Load<Texture2D>("Football");

            // CALL Reset() on '"Ball" + _ballCount':
            (tempEntity as IReset).Reset();

            // SPAWN '"Ball" + _ballCount' at centre of screen:
            (_serviceDict["SceneManager"] as ISpawn).Spawn(tempEntity, new Vector2((_screenSize.X / 2) - (tempEntity as ITexture).TexSize.X / 2, (_screenSize.Y / 2) - (tempEntity as ITexture).TexSize.Y / 2));

            #endregion
        }

        /// <summary>
        /// Method which creates as many Ball entities as specified via an integer parameter
        /// </summary>
        /// <param name="pInt"> Number of entities to be created </param>
        private void CreateMultipleEntities(int pInt)
        {
            // DECLARE & INSTANTIATE a Stopwatch, name it 'tempStopwatch':
            //Stopwatch tempStopwatch = new Stopwatch();

            // FORLOOP, iterate for as many times specified by pInt:
            for (int i = 0; i < pInt; i++)
            {
                /*
                // RESET tempStopwatch():
                tempStopwatch.Reset();

                // START tempStopwatch():
                tempStopwatch.Start();
                */

                // CALL SpawnBall():
                SpawnBall();

                /*
                // STOP tempStopwatch:
                tempStopwatch.Stop();

                // CALL QuickTimedTest() on _serviceDict["PerformanceMeasure"], passing TWO strings, tempStopWatch's elapsed ms, and FALSE as parameters:
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).QuickTimedTest("CreationTest", "ShortTest", tempStopwatch.ElapsedMilliseconds, false);
                */
            }

            //// CALL QuickTimedTest() on _serviceDict["PerformanceMeasure"], passing TWO strings, 0 as null cannot be used, and TRUE as parameters:
            //(_serviceDict["PerformanceMeasure"] as ITestPerformance).QuickTimedTest("CreationTest", "ShortTest", 0, true);

            //// CALL DeleteMultipleEntities(), passing 100 as a parameter:
            //DeleteMultipleEntities(100);

            //// CALL UpdateLongTimedTest() on _serviceDict["PerformanceMeasure"]:
            //(_serviceDict["PerformanceMeasure"] as ITestPerformance).UpdateLongTimedTest();
        }

        /// <summary>
        /// Method which deletes as many Ball entities as specified via an integer parameter
        /// </summary>
        /// <param name="pInt"> Number of entities to be deleted </param>
        private void DeleteMultipleEntities(int pInt)
        {
            // DECLARE & INSTANTIATE a Stopwatch, name it 'tempStopwatch':
            //Stopwatch tempStopwatch = new Stopwatch();

            // IF pInt DOES NOT exceed the number balls in level:
            if (pInt <= _ballCount)
            {
                // DECLARE & INITIALISE an int with the value of _ballCount to keep value from deleting too many entities, name it 'tempEntCount':
                int tempBallCount = _ballCount;

                // FORLOOP, iterate for as many times specified by pInt:
                for (int i = tempBallCount; i > tempBallCount - pInt; i--)
                {
                    /*
                    // RESET tempStopwatch():
                    tempStopwatch.Reset();

                    // START tempStopwatch():
                    tempStopwatch.Start();
                    */

                    // REMOVE entity stored at address '"Ball" + i' from "EntityManager":
                    (_serviceDict["EntityManager"] as IEntityManager).Terminate("Ball" + i);

                    /*
                    // STOP tempStopwatch:
                    tempStopwatch.Stop();
                    
                    // CALL QuickTimedTest() on _serviceDict["PerformanceMeasure"], passing TWO strings, tempStopWatch's elapsed ms, and FALSE as parameters:
                    (_serviceDict["PerformanceMeasure"] as ITestPerformance).QuickTimedTest("TerminationTest", "ShortTest", tempStopwatch.ElapsedMilliseconds, false);
                    */

                    // DECREMENT _ballCount by '1':
                    _ballCount--;
                }

                /*
                // CALL QuickTimedTest() on _serviceDict["PerformanceMeasure"], passing TWO strings, 0 as null cannot be used, and TRUE as parameters:
                (_serviceDict["PerformanceMeasure"] as ITestPerformance).QuickTimedTest("TerminationTest", "ShortTest", 0, true);
                */

                // CALL Collect on Garbage Collector to ensure memory collection after termination:
                GC.Collect();
            }
            // IF pInt DOES exceed the number of entities in _entityDict:
            else
            {
                // WRITE to console explaining that user cannot delete more than the current entity count:
                Console.WriteLine("ERROR: You cannot delete more entities than the number currently stored in the Entity Dictionary!");
            }
        }

        /// <summary>
        /// Checks to see if a positional value has reached either the left or right side of the screen.
        /// </summary>
        /// <param name="pPosition"> Current Position of caller </param>
        private void CheckGoal(Vector2 pPosition)
        {
            // IF pPosition.X has gone off the left side of the screen:
            if (pPosition.X <= 0)
            {
                // INCREMENT Player 2 score by '1':
                _p2Score++;

                // SET Console Text Colour to Red:
                Console.ForegroundColor = ConsoleColor.Red;

                // IF Player 2 has a score of '1':
                if (_p2Score == 1)
                {
                    // PRINT Player 2 score to console:
                    Console.WriteLine("PLAYER 2 has Scored! PLAYER 2 has: " + _p2Score + " point!");
                }
                // IF Player 2 hashas a score of '2' or higher:
                else if (_p2Score >= 2)
                {
                    // PRINT Player 2 score to console:
                    Console.WriteLine("PLAYER 2 has Scored! PLAYER 2 has: " + _p2Score + " points!");
                }
            }
            // IF pPosition.X has gone off the right side of the screen:
            else if (pPosition.X >= _screenSize.X)
            {
                // INCREMENT Player 1 score by '1':
                _p1Score++;

                // SET Console Text Colour to Blue:
                Console.ForegroundColor = ConsoleColor.Blue;

                // IF Player 1 has a score of '1':
                if (_p1Score == 1)
                {
                    // PRINT Player 1 score to console:
                    Console.WriteLine("PLAYER 1 has Scored! PLAYER 1 has: " + _p1Score + " point!");
                }
                // IF Player 1 has a score of '2' or higher:
                else if (_p1Score >= 2)
                {
                    // PRINT Player 1 score to console:
                    Console.WriteLine("PLAYER 1 has Scored! PLAYER 1 has: " + _p1Score + " points!");
                }
            }

            // SET Console Text Colour to White:
            Console.ForegroundColor = ConsoleColor.White;

            // CALL SpawnBall() to make another Ball object:
            SpawnBall();
        }

        #endregion
    }
}