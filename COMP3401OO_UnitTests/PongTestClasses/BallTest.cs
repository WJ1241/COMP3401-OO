using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO_Engine.CollisionManagement.Interfaces;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.CustomEventArgs;
using COMP3401OO_Engine.Delegates.Interfaces;
using COMP3401OO_Engine.EntityManagement;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO_Engine.SceneManagement;
using COMP3401OO_Engine.SceneManagement.Interfaces;
using COMP3401OO.PongPackage.Behaviours;
using COMP3401OO.PongPackage.Entities;
using COMP3401OO.PongPackage.Delegates.Interfaces;

namespace COMP3401OO_UnitTests.PongTestClasses
{
    /// <summary>
    /// Test Class for an Entity that acts as a Ball in game
    /// Author: William Smith
    /// Date: 26/02/22
    /// </summary>
    [TestClass]
    public class BallTest
    {
        #region FIELD VARIABLES

        // DECLARE TWO Point variables, name it '_bounds':
        private Point _bounds;

        #endregion


        #region BALL CREATION (MAKES EASIER TO READ TESTS)

        /// <summary>
        /// Method which creates a Ball entity for Test Methods
        /// </summary>
        public IEntity CreateBall()
        {
            #region MONOGAME SETUP

            // SET value of _bounds to max Window Size of 1600x800:
            _bounds = new Point(1600, 800);

            #endregion


            #region CREATION

            // DECLARE & INSTANTIATE an IEntity as a new Ball(), name it '_tempEntity':
            IEntity _tempEntity = new Ball();

            // ASSIGN UName to _tempEntity:
            _tempEntity.UName = "Ball";

            #endregion


            #region SETTING VALUES

            // SET & MOCK a texture size of 20x20 to _tempEntity:
            (_tempEntity as ITexture).TexSize = new Point(20, 20);

            // SET value of WindowBorder Property to value of _bounds:
            (_tempEntity as IContainBoundary).WindowBorder = _bounds;

            #endregion


            #region RETURNING ENTITY TO CALLER

            // RETURN instance of _tempEntity:
            return _tempEntity;

            #endregion
        }

        #endregion


        #region TOP BOUND 

        /// <summary>
        /// Tests if Ball Reverses Y Direction when in contact with top of screen
        /// </summary>
        [TestMethod]
        public void ContactWithTopOfScreen()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it '_ballBehaviour':
            IUpdateEventListener _ballBehaviour = new BallBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreateBall(), name it '_ball':
            IEntity _ball = CreateBall();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _ballBehaviour with reference to _ball:
            (_ballBehaviour as IInitialiseIEntity).Initialise(_ball);

            #endregion


            #region ENTITY
            
            // INITIALISE _ball with reference to _ballBehaviour:
            (_ball as IInitialiseIUpdateEventListener).Initialise(_ballBehaviour);

            // SPAWN _ball in top middle of screen, Y axis value of 1, so it is 1px from contact before running code:
            _ball.Position = new Vector2((_bounds.X / 2) - (_ball as ITexture).TexSize.X / 2, 1);

            // SET Velocity.Y of _ball to -1, to head upwards:
            (_ball as IVelocity).Velocity = new Vector2(0, -1);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL _OnUpdate() on _ballBehaviour, passing _ball and a new UpdateEventArgs() as parameters:
            _ballBehaviour.OnUpdate(_ball, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Ball has reversed Y axis Velocity to a positive number:
            Assert.AreEqual(new Vector2(0, 1), (_ball as IVelocity).Velocity);

            #endregion
        }

        #endregion


        #region BOTTOM BOUND

        /// <summary>
        /// Tests if Ball Reverses Y Direction when in contact with bottom of screen
        /// </summary>
        [TestMethod]
        public void ContactWithBottomOfScreen()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it '_ballBehaviour':
            IUpdateEventListener _ballBehaviour = new BallBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreateBall(), name it '_ball':
            IEntity _ball = CreateBall();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _ballBehaviour with reference to _ball:
            (_ballBehaviour as IInitialiseIEntity).Initialise(_ball);

            #endregion


            #region ENTITY

            // INITIALISE _ball with reference to _ballBehaviour:
            (_ball as IInitialiseIUpdateEventListener).Initialise(_ballBehaviour);

            // SPAWN _ball in bottom middle of screen, Y axis value of _bounds.Y - 1, so it is 1px from contact before running code:
            _ball.Position = new Vector2((_bounds.X / 2) - (_ball as ITexture).TexSize.X / 2, _bounds.Y - 1);

            // SET Velocity.Y of _ball to 1, to head downwards:
            (_ball as IVelocity).Velocity = new Vector2(0, 1);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL _OnUpdate() on _ballBehaviour, passing _ball and a new UpdateEventArgs() as parameters:
            _ballBehaviour.OnUpdate(_ball, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Ball has reversed Y axis Velocity to a negative number:
            Assert.AreEqual(new Vector2(0, -1), (_ball as IVelocity).Velocity);

            #endregion
        }

        #endregion

        
        #region COLLISION

        /// <summary>
        /// Tests if Ball reverses X axis Direction when in contact with another Entity
        /// </summary>
        [TestMethod]
        public void CollisionWithSecondEntity()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an ICollisionEventListener as a new BallBehaviour(), name it '_ballBehaviour':
            ICollisionEventListener _ballBehaviour = new BallBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreateBall(), name it '_ball':
            IEntity _ball = CreateBall();

            // DECLARE & INSTANTIATE an IEntity as a new Paddle(), name it '_paddle':
            IEntity _paddle = new Paddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _ballBehaviour with reference to _ball:
            (_ballBehaviour as IInitialiseIEntity).Initialise(_ball);

            // DECLARE & INSTANTIATE a CollisionEventArgs(), name it '_args':
            CollisionEventArgs _args = new CollisionEventArgs();

            // SET RequiredArg Property value of _args to reference of _paddle:
            _args.RequiredArg = _paddle as ICollidable;

            #endregion


            #region BALL

            // INITIALISE _ball with reference to _ballBehaviour:
            (_ball as IInitialiseIUpdateEventListener).Initialise(_ballBehaviour as IUpdateEventListener);

            // SPAWN _ball in bottom middle of screen, Y axis value of _bounds.Y - 1, so it is 1px from contact before running code:
            _ball.Position = new Vector2((_bounds.X / 2) - (_ball as ITexture).TexSize.X / 2, _bounds.Y - 1);

            // SET Velocity.Y of _ball to -1, to head left:
            (_ball as IVelocity).Velocity = new Vector2(-1, 0);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL OnCollision() on _ballBehaviour, passing _ball and _args as parameters:
            _ballBehaviour.OnCollision(_ball, _args);

            #endregion


            #region ASSERT

            // ASSERT that Ball has reversed X axis Velocity:
            Assert.AreEqual(1, (_ball as IVelocity).Velocity.X);

            #endregion
        }

        #endregion

        
        #region TERMINATION

        /// <summary>
        /// Tests if Ball has been terminated when exiting off of the left side of the screen
        /// </summary>
        [TestMethod]
        public void LeftOfScreenTermination()
        {
            #region ARRANGE

            #region MANAGERS

            // DECLARE & INSTANTIATE an IEntityManager as a new EntityManager, name it '_entityManager':
            IEntityManager _entityManager = new EntityManager();

            // DECLARE & INSTANTIATE an ISceneManager as a new SceneManager, name it '_sceneManager':
            ISceneManager _sceneManager = new SceneManager();

            // INITIALISE _entityManager with reference to _sceneManager:
            _entityManager.Initialise(_sceneManager);

            // INITIALISE _sceneManager with a new SceneGraph():
            _sceneManager.Initialise(new SceneGraph());

            #endregion


            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it '_ballBehaviour':
            IUpdateEventListener _ballBehaviour = new BallBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreateBall(), name it '_ball':
            IEntity _ball = CreateBall();

            // ADD _ball.UName as a key, and _ball as a value to _entityManager.GetDictionary():
            _entityManager.GetDictionary().Add(_ball.UName, _ball);

            // ADD _ball.UName as a key, and _ball as a value to _entityManager.GetDictionary():
            _sceneManager.GetDictionary().Add(_ball.UName, _ball);

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _ballBehaviour with reference to _ball:
            (_ballBehaviour as IInitialiseIEntity).Initialise(_ball);

            // INITIALISE _ballBehaviour with a reference to DummyCreate():
            (_ballBehaviour as IInitialiseCheckPosDel).Initialise(DummyCreate);

            #endregion


            #region ENTITY

            // INITIALISE _ball with reference to _ballBehaviour:
            (_ball as IInitialiseIUpdateEventListener).Initialise(_ballBehaviour);

            // INITIALISE _ball with a reference to _entityManager.Terminate():
            (_ball as IInitialiseDeleteDel).Initialise(_entityManager.Terminate);

            // SPAWN _ball in far left middle of screen, X axis value of 1, so it is 1px from contact before running code:
            _ball.Position = new Vector2(1, _bounds.Y / 2);

            // SET Velocity.Y of _ball to -1, to head left:
            (_ball as IVelocity).Velocity = new Vector2(-1, 0);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL _OnUpdate() on _ballBehaviour, passing _ball and a new UpdateEventArgs() as parameters:
            _ballBehaviour.OnUpdate(_ball, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // IF _entityManager DOES NOT contain an Entity Named "Ball":
            if (!_entityManager.GetDictionary().ContainsKey(_ball.UName))
            {
                // DO NOTHING, PASSES
            }
            // IF _entityManager DOES contain an Entity Named "Ball":
            else
            {
                // ASSERT that the test has failed, with corresponding message:
                Assert.Fail("ERROR: _ball has an active instance!");
            }

            #endregion
        }
        
        /// <summary>
        /// Tests if Ball has been terminated when exiting off of the right side of the screen
        /// </summary>
        [TestMethod]
        public void RightOfScreenTermination()
        {
            #region ARRANGE

            #region MANAGERS

            // DECLARE & INSTANTIATE an IEntityManager as a new EntityManager, name it '_entityManager':
            IEntityManager _entityManager = new EntityManager();

            // DECLARE & INSTANTIATE an ISceneManager as a new SceneManager, name it '_sceneManager':
            ISceneManager _sceneManager = new SceneManager();

            // INITIALISE _entityManager with reference to _sceneManager:
            _entityManager.Initialise(_sceneManager);

            // INITIALISE _sceneManager with a new SceneGraph():
            _sceneManager.Initialise(new SceneGraph());

            #endregion


            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new BallBehaviour(), name it '_ballBehaviour':
            IUpdateEventListener _ballBehaviour = new BallBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreateBall(), name it '_ball':
            IEntity _ball = CreateBall();

            // ADD _ball.UName as a key, and _ball as a value to _entityManager.GetDictionary():
            _entityManager.GetDictionary().Add(_ball.UName, _ball);

            // ADD _ball.UName as a key, and _ball as a value to _entityManager.GetDictionary():
            _sceneManager.GetDictionary().Add(_ball.UName, _ball);

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _ballBehaviour with reference to _ball:
            (_ballBehaviour as IInitialiseIEntity).Initialise(_ball);

            // INITIALISE _ballBehaviour with a reference to DummyCreate():
            (_ballBehaviour as IInitialiseCheckPosDel).Initialise(DummyCreate);

            #endregion


            #region ENTITY

            // INITIALISE _ball with reference to _ballBehaviour:
            (_ball as IInitialiseIUpdateEventListener).Initialise(_ballBehaviour);

            // INITIALISE _ball with a reference to _entityManager.Terminate():
            (_ball as IInitialiseDeleteDel).Initialise(_entityManager.Terminate);

            // SPAWN _ball in far right middle of screen, X axis value of _bounds.X - 1, so it is 1px from contact before running code:
            _ball.Position = new Vector2(_bounds.X - 1, _bounds.Y / 2);

            // SET Velocity.Y of _ball to 1, to head right:
            (_ball as IVelocity).Velocity = new Vector2(1, 0);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL _OnUpdate() on _ballBehaviour, passing _ball and a new UpdateEventArgs() as parameters:
            _ballBehaviour.OnUpdate(_ball, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // IF _entityManager DOES NOT contain an Entity Named "Ball":
            if (!_entityManager.GetDictionary().ContainsKey(_ball.UName))
            {
                // DO NOTHING, PASSES
            }
            // IF _entityManager DOES contain an Entity Named "Ball":
            else
            {
                // ASSERT that the test has failed, with corresponding message:
                Assert.Fail("ERROR: _ball has an active instance!");
            }

            #endregion
        }

        #endregion


        #region DUMMY METHODS

        /// <summary>
        /// Dummy Create Method to initialise a CreateDelegate with to prevent runtime error
        /// </summary>
        /// <param name="pVector"> Dummy vector </param>
        private void DummyCreate(Vector2 pVector)
        {
            // DOES NOTHING, CANNOT USE CREATEBALL() IN KERNEL DUE TO ISSUES WITH CREATING GRAPHICS DEVICE
        }

        #endregion
    }
}
