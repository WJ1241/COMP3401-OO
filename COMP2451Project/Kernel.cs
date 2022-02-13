using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using COMP2451Project.EnginePackage.CollisionManagement;
using COMP2451Project.EnginePackage.CoreInterfaces;
using COMP2451Project.EnginePackage.EntityManagement;
using COMP2451Project.EnginePackage.InputManagement;
using COMP2451Project.EnginePackage.SceneManagement;
using COMP2451Project.PongPackage;

namespace COMP2451Project
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Kernel : Game
    {
        #region FIELD VARIABLES

        // DECLARE a GraphicsDeviceManager, call it '_graphics':
        private GraphicsDeviceManager _graphics;

        // DECLARE a SpriteBatch, call it '_spriteBatch':
        private SpriteBatch _spriteBatch;

        // DECLARE a Random, call it '_rand':
        private Random _rand;

        // DECLARE an IEntityManager, call it '_entityManager':
        private IEntityManager _entityManager;

        // DECLARE an ISceneManager, call it '_sceneManager':
        private ISceneManager _sceneManager;

        // DECLARE an ISceneGraph, call it '_sceneGraph':
        private ISceneGraph _sceneGraph;

        // DECLARE an ICollisionManager, call it '_CollisionManager':
        private ICollisionManager _collisionManager;

        // DECLARE an IKeyboardPublisher, call it '_kBManager':
        private IKeyboardPublisher _kBManager;

        // DECLARE an IDictionary, call it '_entityDictionary':
        private IDictionary<string, IEntity> _entityDictionary;

        // DECLARE a Vector2, used to store Screen size, call it 'screenSize':
        private Vector2 _screenSize;

        // DECLARE an int, call it '_p1Score':
        private int _p1Score;

        // DECLARE an int, call it '_p2Score':
        private int _p2Score;

        #endregion


        #region PUBLIC METHODS

        public Kernel()
        {
            // INSTANTIATE _graphics as new GraphicsDeviceManager, passing Kernel as a parameter:
            _graphics = new GraphicsDeviceManager(this);

            // SET RootDirectory of Content as "Content":
            Content.RootDirectory = "Content";

            // SET IsMouseVisible to true:
            IsMouseVisible = true;

            // SET screen width to 1600:
            _graphics.PreferredBackBufferWidth = 1600;

            // SET screen height to 900:
            _graphics.PreferredBackBufferHeight = 900;

            // INITIALISE _p1Score with a value of 0:
            _p1Score = 0;

            // INITIALISE _p2Score with a value of 0:
            _p2Score = 0;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            #region OBJECT INSTANTIATIONS

            // Get Screen Width:
            _screenSize.X = GraphicsDevice.Viewport.Width;

            // GET Screen Height:
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

            // INSTANTIATE _kBManager, call it '_kBManager':
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


            //// BALL


            // INSTANTIATE new Ball():
            _entityManager.Create<Ball>("ball");

            // SET boundary size for Ball:
            (_entityDictionary["ball"] as ISetBoundary).WindowBorder = _screenSize;

            // INITIALISE "ball":
            _entityDictionary["ball"].Initialise();

            // INITIALISE "ball", passing _rand as a parameter:
            (_entityDictionary["ball"] as IInitialiseRand).Initialise(_rand);

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

            // LOAD "square" texture to "ball":
            (_entityDictionary["ball"] as ITexture).Texture = Content.Load<Texture2D>("square");


            // SPAWN Paddle1 on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["paddle1"], new Vector2 (0, (_screenSize.Y / 2) - (_entityDictionary["paddle2"] as ITexture).Texture.Height / 2));

            // SPAWN Paddle2 on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["paddle2"], new Vector2(_screenSize.X - (_entityDictionary["paddle2"] as ITexture).Texture.Width, (_screenSize.Y / 2) - (_entityDictionary["paddle2"] as ITexture).Texture.Height / 2));

            // SPAWN Ball on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["ball"], new Vector2((_screenSize.X / 2) - (_entityDictionary["ball"] as ITexture).Texture.Width / 2, (_screenSize.Y / 2) - (_entityDictionary["ball"] as ITexture).Texture.Height / 2));

            // CALL Reset() on Ball object:
            (_entityDictionary["ball"] as IReset).Reset();
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
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
                || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            // CALL Update() on SceneManager:
            (_sceneManager as IUpdatable).Update(gameTime);

            // CALL Update() on CollisionManager:
            (_collisionManager as IUpdatable).Update(gameTime);

            // CALL Update() on KeyboardManager:
            (_kBManager as IUpdatable).Update(gameTime);


            // CALL method which tests contact with side boundaries
            checkGoal();

            // CALL method from base Game class, uses gameTime as parameter:
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
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
            base.Draw(gameTime);
        }

        #endregion


        #region PRIVATE METHODS


        /// <summary>
        /// Spawns a Ball object on screen.
        /// </summary>
        private void RespawnBall()
        {
            // INSTANTIATE Ball():
            _entityManager.Create<Ball>("ball");

            // SET boundary size for Ball:
            (_entityDictionary["ball"] as ISetBoundary).WindowBorder = _screenSize;

            // INITIALISE "ball":
            _entityDictionary["ball"].Initialise();

            // INITIALISE "ball", passing _rand as a parameter:
            (_entityDictionary["ball"] as IInitialiseRand).Initialise(_rand);

            // LOAD "square" texture to "ball":
            (_entityDictionary["ball"] as ITexture).Texture = Content.Load<Texture2D>("square");

            // SPAWN Ball on screen by adding to SceneManager Dictionary:
            (_sceneManager as ISpawn).Spawn(_entityDictionary["ball"], new Vector2((_screenSize.X / 2) - (_entityDictionary["ball"] as ITexture).Texture.Width / 2, (_screenSize.Y / 2) - (_entityDictionary["ball"] as ITexture).Texture.Height / 2));

            // CALL Reset() on Ball object:
            (_entityDictionary["ball"] as IReset).Reset(); // CALL method in Ball, serves ball in random direction
        }


        /// <summary>
        /// Checks if ball has reached either the left or right side of the screen.
        /// </summary>
        private void checkGoal()
        {
            // DECLARE & ASSIGN a bool, call it '_tempTerminate', set it to false:
            bool _tempTerminate = false;

            // DECLARE & ASSIGN a Vector2, call it '_tempPosition', used to stop Score count going up, temporarily:
            Vector2 _tempPosition = new Vector2(_screenSize.X / 2, _screenSize.Y / 2);

            if ((_entityDictionary["ball"] as ITerminate).SelfDestruct == true) // IF "ball" _selfDestruct value is true:
            {
                // ASSIGNMENT, set value of '_tempTerminate' to true:
                _tempTerminate = true;

                // ASSIGNMENT, set value of '_tempPosition' to true:
                _tempPosition = _entityDictionary["ball"].Position;

                // CALL Terminate, passing "ball" uName as a parameter:
                _entityManager.Terminate(_entityDictionary["ball"].UName);
            }

            if (_tempPosition.X <= 0) // IF ball location exceeds left of screen
            {
                // INCREMENT Player 2 score
                _p2Score++;

                if (_p2Score == 1)
                {
                    Console.WriteLine("PLAYER 2 has Scored! PLAYER 2 has: " + _p2Score + " point!");
                }
                else if (_p2Score >= 2)
                {
                    Console.WriteLine("PLAYER 2 has Scored! PLAYER 2 has: " + _p2Score + " points!");
                }
            }
            else if (_tempPosition.X >= _screenSize.X) // IF ball location exceeds right of screen
            {
                // INCREMENT Player 1 score
                _p1Score++;

                if (_p1Score == 1)
                {
                    Console.WriteLine("PLAYER 1 has Scored! PLAYER 1 has: " + _p1Score + " point!");
                }
                else if (_p1Score >= 2)
                {
                    Console.WriteLine("PLAYER 1 has Scored! PLAYER 1 has: " + _p1Score + " points!");
                }
            }

            if (_tempTerminate == true) 
            {
                // CALL spawns another Ball object
                RespawnBall();
            }
        }

        #endregion
    }
}