using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using COMP3401OO_Engine.CoreInterfaces;
using COMP3401OO_Engine.EntityManagement.Interfaces;
using COMP3401OO.PongPackage.Entities;
using COMP3401OO.PongPackage.Behaviours;
using COMP3401OO_Engine.Behaviours.Interfaces;
using COMP3401OO.PongPackage.Behaviours.Interfaces;
using COMP3401OO_Engine.CustomEventArgs;
using Microsoft.Xna.Framework.Input;

namespace COMP3401OO_UnitTests.PongTestClasses
{
    /// <summary>
    /// Test Class for an Entity that acts as a Paddle in game
    /// Author: William Smith
    /// Date: 26/02/22
    /// </summary>
    [TestClass]
    public class PaddleTest
    {
        #region FIELD VARIABLES

        // DECLARE TWO Point variables, name it '_bounds':
        private Point _bounds;

        #endregion


        #region PADDLE CREATION (MAKES EASIER TO READ TESTS)

        /// <summary>
        /// Method which creates a Paddle entity for Test Methods
        /// </summary>
        public IEntity CreatePaddle()
        {
            #region MONOGAME SETUP

            // SET value of _bounds to max Window Size of 1600x800:
            _bounds = new Point(1600, 800);

            #endregion


            #region CREATION

            // DECLARE & INSTANTIATE an IEntity as a new Paddle(), name it '_tempEntity':
            IEntity _tempEntity = new Paddle();

            // ASSIGN UName to _tempEntity:
            _tempEntity.UName = "Paddle";

            #endregion


            #region SETTING VALUES

            // SET & MOCK a texture size of 20x60 to _tempEntity:
            (_tempEntity as ITexture).TexSize = new Point(20, 60);

            // SET value of WindowBorder Property to value of _bounds:
            (_tempEntity as IContainBoundary).WindowBorder = _bounds;

            #endregion


            #region RETURNING ENTITY TO CALLER

            // RETURN instance of _tempEntity:
            return _tempEntity;

            #endregion
        }

        #endregion


        #region UP MOVEMENT

        /// <summary>
        /// Tests if Player One's Direction heads upwards when 'W' is Pressed
        /// </summary>
        [TestMethod]
        public void PlayerOneMoveUp()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IKBEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IKBEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            // DECLARE & INSTANTIATE a KBEventArgs(), name it '_args':
            KBEventArgs _args = new KBEventArgs();

            // SET RequiredArg Property value of _args to reference of Keyboard.GetState():
            _args.RequiredArg = Keyboard.GetState();

            #endregion


            #region ENTITY

            // SET PlayerNum of _paddle to PlayerIndex.One:
            (_paddle as IPlayer).PlayerNum = PlayerIndex.One;

            #endregion

            #endregion

            #endregion


            #region ACT

            // SET input to 'W' Key:
            (_paddleBehaviour as ITestKBInput).SetKeyPressed = "W";

            // CALL OnKBInput() on _paddleBehaviour, passing _paddle and _args as parameters:
            _paddleBehaviour.OnKBInput(_paddle, _args);

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            (_paddleBehaviour as IUpdateEventListener).OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle is moving upwards:
            Assert.AreEqual(-10, (_paddle as IVelocity).Velocity.Y);

            #endregion
        }
        
        /// <summary>
        /// Tests if Player Two's Direction heads upwards when Up Arrow is Pressed
        /// </summary>
        [TestMethod]
        public void PlayerTwoMoveUp()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IKBEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IKBEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            // DECLARE & INSTANTIATE a KBEventArgs(), name it '_args':
            KBEventArgs _args = new KBEventArgs();

            // SET RequiredArg Property value of _args to reference of Keyboard.GetState():
            _args.RequiredArg = Keyboard.GetState();

            #endregion


            #region ENTITY

            // SET PlayerNum of _paddle to PlayerIndex.Two:
            (_paddle as IPlayer).PlayerNum = PlayerIndex.Two;

            #endregion

            #endregion

            #endregion


            #region ACT

            // SET input to Up Arrow Key:
            (_paddleBehaviour as ITestKBInput).SetKeyPressed = "Up";

            // CALL OnKBInput() on _paddleBehaviour, passing _paddle and _args as parameters:
            _paddleBehaviour.OnKBInput(_paddle, _args);

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            (_paddleBehaviour as IUpdateEventListener).OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle is moving upwards:
            Assert.AreEqual(-10, (_paddle as IVelocity).Velocity.Y);

            #endregion
        }

        #endregion

        

        #region DOWN MOVEMENT

        /// <summary>
        /// Tests if Player One's Direction heads downwards when 'S' is Pressed
        /// </summary>
        [TestMethod]
        public void PlayerOneMoveDown()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IKBEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IKBEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            // DECLARE & INSTANTIATE a KBEventArgs(), name it '_args':
            KBEventArgs _args = new KBEventArgs();

            // SET RequiredArg Property value of _args to reference of Keyboard.GetState():
            _args.RequiredArg = Keyboard.GetState();

            #endregion


            #region ENTITY

            // SET PlayerNum of _paddle to PlayerIndex.One:
            (_paddle as IPlayer).PlayerNum = PlayerIndex.One;

            #endregion

            #endregion

            #endregion


            #region ACT

            // SET input to 'S' Key:
            (_paddleBehaviour as ITestKBInput).SetKeyPressed = "S";

            // CALL OnKBInput() on _paddleBehaviour, passing _paddle and _args as parameters:
            _paddleBehaviour.OnKBInput(_paddle, _args);

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            (_paddleBehaviour as IUpdateEventListener).OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle is moving downwards:
            Assert.AreEqual(10, (_paddle as IVelocity).Velocity.Y);

            #endregion
        }

        /// <summary>
        /// Tests if Player Two's Direction heads downwards when Down Arrow is Pressed
        /// </summary>
        [TestMethod]
        public void PlayerTwoMoveDown()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IKBEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IKBEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            // DECLARE & INSTANTIATE a KBEventArgs(), name it '_args':
            KBEventArgs _args = new KBEventArgs();

            // SET RequiredArg Property value of _args to reference of Keyboard.GetState():
            _args.RequiredArg = Keyboard.GetState();

            #endregion


            #region ENTITY

            // SET PlayerNum of _paddle to PlayerIndex.Two:
            (_paddle as IPlayer).PlayerNum = PlayerIndex.Two;

            #endregion

            #endregion

            #endregion


            #region ACT

            // SET input to Down Arrow Key:
            (_paddleBehaviour as ITestKBInput).SetKeyPressed = "Down";

            // CALL OnKBInput() on _paddleBehaviour, passing _paddle and _args as parameters:
            _paddleBehaviour.OnKBInput(_paddle, _args);

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            (_paddleBehaviour as IUpdateEventListener).OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle is moving downwards:
            Assert.AreEqual(10, (_paddle as IVelocity).Velocity.Y);

            #endregion
        }

        #endregion


        #region TOP BOUND 

        /// <summary>
        /// Tests if Paddle Reverts Position to top of Y axis when in contact with top of screen
        /// </summary>
        [TestMethod]
        public void ContactWithTopOfScreen()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IUpdateEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            #endregion


            #region ENTITY

            // SET Origin Property value to centre of texture:
            (_paddle as IRotation).Origin = new Vector2((_paddle as ITexture).TexSize.X / 2, (_paddle as ITexture).TexSize.Y / 2);

            // SET Position of _paddle to left edge of screen and origin of _paddle - 1, so it is only past contact with top of screen:
            _paddle.Position = new Vector2(0, (_paddle as IRotation).Origin.Y - 1);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            _paddleBehaviour.OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle has reverted Y axis Position back to top of screen:
            Assert.AreEqual(0, _paddle.Position.Y - (_paddle as IRotation).Origin.Y);

            #endregion
        }

        #endregion
        

        #region BOTTOM BOUND

        /// <summary>
        /// Tests if Paddle Reverts Position to bottom of Y axis when in contact with bottom of screen
        /// </summary>
        [TestMethod]
        public void ContactWithBottomOfScreen()
        {
            #region ARRANGE

            #region INSTANTIATIONS

            // DECLARE & INSTANTIATE an IUpdateEventListener as a new PaddleBehaviour(), name it '_paddleBehaviour':
            IUpdateEventListener _paddleBehaviour = new PaddleBehaviour();

            // DECLARE & INSTANTIATE an IEntity using CreatePaddle(), name it '_paddle':
            IEntity _paddle = CreatePaddle();

            #endregion


            #region INITIALISATIONS

            #region BEHAVIOUR

            // INITIALISE _paddleBehaviour with reference to _paddle:
            (_paddleBehaviour as IInitialiseIEntity).Initialise(_paddle);

            #endregion


            #region ENTITY

            // SET Origin Property value to centre of texture:
            (_paddle as IRotation).Origin = new Vector2((_paddle as ITexture).TexSize.X / 2, (_paddle as ITexture).TexSize.Y / 2);

            // SET Position of _paddle to left edge of screen and Y axis bounds - origin of _paddle + 1, so it is only past contact with bottom of screen:
            _paddle.Position = new Vector2(0, _bounds.Y - (_paddle as IRotation).Origin.Y + 1);

            #endregion

            #endregion

            #endregion


            #region ACT

            // CALL OnUpdate() on _paddleBehaviour, passing _paddle and a new UpdateEventArgs() as parameters:
            _paddleBehaviour.OnUpdate(_paddle, new UpdateEventArgs());

            #endregion


            #region ASSERT

            // ASSERT that Paddle has reverted Y axis Position back to bottom of screen:
            Assert.AreEqual(_bounds.Y, _paddle.Position.Y + (_paddle as IRotation).Origin.Y);

            #endregion
        }

        #endregion
    }
}
