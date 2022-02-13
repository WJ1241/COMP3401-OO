using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using COMP3401OO.EnginePackage.CollisionManagement;
using COMP3401OO.EnginePackage.CollisionManagement.Interfaces;
using COMP3401OO.EnginePackage.CoreInterfaces;
using COMP3401OO.EnginePackage.EntityManagement;
using COMP3401OO.EnginePackage.EntityManagement.Interfaces;
using COMP3401OO.EnginePackage.InputManagement;
using COMP3401OO.EnginePackage.InputManagement.Interfaces;
using COMP3401OO.EnginePackage.SceneManagement;
using COMP3401OO.EnginePackage.SceneManagement.Interfaces;
using COMP3401OO.PongPackage;
using COMP3401OO.PongPackage.Delegates.Interfaces;

namespace COMP3401OO
{
    /// <summary>
    /// Main Class of OO System
    /// Author: William Smith
    /// Date: 13/02/22
    /// </summary>
    public class Kernel : Game
    {
        #region FIELD VARIABLES

        // DECLARE a GraphicsDeviceManager, name it '_graphics':
        private GraphicsDeviceManager _graphics;

        // DECLARE a SpriteBatch, name it '_spriteBatch':
        private SpriteBatch _spriteBatch;

        // DECLARE a Random, name it '_rand':
        private Random _rand;

        // DECLARE an IEntityManager, name it '_entityManager':
        private IEntityManager _entityManager;

        // DECLARE an ISceneManager, name it '_sceneManager':
        private ISceneManager _sceneManager;

        // DECLARE an ISceneGraph, name it '_sceneGraph':
        private ISceneGraph _sceneGraph;

        // DECLARE an ICollisionManager, name it '_CollisionManager':
        private ICollisionManager _collisionManager;

        // DECLARE an IKeyboardPublisher, name it '_kBManager':
        private IKeyboardPublisher _kBManager;

        // DECLARE an IDictionary, name it '_entityDictionary':
        private IDictionary<string, IEntity> _entityDictionary;

        // DECLARE a Vector2, used to store Screen size, name it 'screenSize':
        private Vector2 _screenSize;

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
            // INSTANTIATE _graphics as new GraphicsDeviceManager, passing Kernel as a parameter:
            _graphics = new GraphicsDeviceManager(this);

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
            #region OBJECT INSTANTIATIONS

            // INITIALISE _screenSize.X with value of Viewport.Width:
            _screenSize.X = GraphicsDevice.Viewport.Width;

            // INITIALISE _screenSize.Y with value of Viewport.Height:
            _screenSize.Y = GraphicsDevice.Viewport.Height;

            // INSTANTIATE _rand as new Random():
            _rand = new Random();

            // INSTANTIATE _entityManager as new EntityManager():
            _entityManager = new EntityManager();

            // INSTANTIATE _sceneManager as new SceneManager():
            _sceneManager = new SceneManager();

            // INSTANTIATE _sceneGraph as new SceneGraph():
            _sceneGraph = new SceneGraph();

            // INSTANTIATE _collisionManager as new SceneManager():
            _collisionManager = new CollisionManager();

            // INSTANTIATE _kBManager, name it '_kBManager':
            _kBManager = new KeyboardManager();

            // ASSIGNMENT, set value of '_entityDictionary' the same as _entityManager Dictionary:
            _entityDictionary = _entityManager.GetDictionary;

            #endregion


            #region OBJECT INITIALISATION

            // INITIALISE _entityManager, passing _sceneManager as a parameter:
            _entityManager.Initialise(_sceneManager);

            // INITIALISE _entityManager, passing _sceneManager as a parameter:
            _entityManager.Initialise(_kBManager);

            // INITIALISE _sceneManager, passing _collisionManager as a parameter:
            _sceneManager.Initialise(_collisionManager);

            // INITIALISE _sceneManager, passing _sceneGraph as a parameter:
            _sceneManager.Initialise(_sceneGraph);

            #endregion


            #region DISPLAYABLE CREATION

            //// PADDLE 1

            // INSTANTIATE new Paddle():
            _entityManager.Create<Paddle>("paddle1");

            // ASSIGNMENT, set PlayerNum value as PlayerIndex.One:
            (_entityDictionary["paddle1"] as IPlayer).PlayerNum = PlayerIndex.One;

            // SUBSCRIBE Paddle1 to Mouse Manager:
            _kBManager.Subscribe(_entityDictionary["paddle1"] as IKeyboardListener);

            // SET boundary size for Paddle1:
            (_entityDictionary["paddle1"] as ISetBoundary).WindowBorder = new Vector2(_screenSize.X, _screenSize.Y);

            // INITIALISE "paddle1":
            _entityDictionary["paddle1"].Initialise();

            //// PADDLE 2

            // INSTANTIATE new Paddle():
            _entityManager.Create<Paddle>("paddle2");

            // ASSIGNMENT, set PlayerNum value as PlayerIndex.Two:
            (_entityDictionary["paddle2"] as IPlayer).PlayerNum = PlayerIndex.Two;

            // SUBSCRIBE Paddle2 to Mouse Manager:
            _kBManager.Subscribe(_entityDictionary["paddle2"] as IKeyboardListener);

            // SET boundary size for Paddle2:
            (_entityDictionary["paddle2"] as ISetBoundary).WindowBorder = _screenSize;

            // INITIALISE "paddle2":
            _entityDictionary["paddle2"].Initialise();

            #endregion

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

            // LOAD "paddle" texture to "paddle1":
            (_entityDictionary["paddle1"] as ITexture).Texture = Content.Load<Texture2D>("paddle");

            // LOAD "paddle" texture to "paddle2":
            (_entityDictionary["paddle2"] as ITexture).Texture = Content.Load<Texture2D>("paddle");

            // SPAWN Paddle1 on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["paddle1"], new Vector2 (0, (_screenSize.Y / 2) - (_entityDictionary["paddle2"] as ITexture).Texture.Height / 2));

            // SPAWN Paddle2 on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["paddle2"], new Vector2(_screenSize.X - (_entityDictionary["paddle2"] as ITexture).Texture.Width, (_screenSize.Y / 2) - (_entityDictionary["paddle2"] as ITexture).Texture.Height / 2));

            // CALL SpawnBall(), handles creation and initialisation:
            SpawnBall();
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // CALL Update() on SceneManager:
            (_sceneManager as IUpdatable).Update(pGameTime);

            // CALL Update() on CollisionManager:
            (_collisionManager as IUpdatable).Update(pGameTime);

            // CALL Update() on KeyboardManager:
            (_kBManager as IUpdatable).Update(pGameTime);

            // CALL method from base Game class, uses gameTime as parameter:
            base.Update(pGameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime pGameTime)
        {
            // SET colour of screen background as CornflowerBlue:
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // BEGIN creation of displayable objects:
            _spriteBatch.Begin();

            // CALL Draw() method in _sceneManager:
            (_sceneManager as IDraw).Draw(_spriteBatch);

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

            // INSTANTIATE Ball():
            _entityManager.Create<Ball>("Ball" + _ballCount);

            // SET boundary size for Ball:
            (_entityDictionary["Ball" + _ballCount] as ISetBoundary).WindowBorder = _screenSize;

            // INITIALISE "Ball":
            _entityDictionary["Ball" + _ballCount].Initialise();

            // INITIALISE "Ball", passing _rand as a parameter:
            (_entityDictionary["Ball" + _ballCount] as IInitialiseRand).Initialise(_rand);

            // INITIALISE "Ball" with reference to CheckGoal(): 
            (_entityDictionary["Ball" + _ballCount] as IInitialiseCheckPosDel).Initialise(CheckGoal);

            // LOAD "square" texture to "Ball":
            (_entityDictionary["Ball" + _ballCount] as ITexture).Texture = Content.Load<Texture2D>("square");

            // SPAWN "Ball" on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["Ball" + _ballCount], new Vector2((_screenSize.X / 2) - (_entityDictionary["Ball" + _ballCount] as ITexture).Texture.Width / 2, (_screenSize.Y / 2) - (_entityDictionary["Ball" + _ballCount] as ITexture).Texture.Height / 2));

            // CALL Reset() on "Ball":
            (_entityDictionary["Ball" + _ballCount] as IReset).Reset();
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

            // CALL SpawnBall() to make another Ball object:
            SpawnBall();
        }

        #endregion
    }
}