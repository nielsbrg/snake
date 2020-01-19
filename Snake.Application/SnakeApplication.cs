namespace Snake.Application
{
    using System.Windows.Forms;
    using System.Collections.Generic;
    using Renderers;
    using Input;
    using Game;
    using Events;
    using Domain;
    using Properties;
    using System.Runtime.InteropServices;
    using System;
    using System.Drawing;
    using System.Diagnostics;
    using Snake.Engine;
    using System.Linq;
    using System.Threading;

    public partial class SnakeApplication : Form, Events.IObserver<SnakeDyingEvent>
    {
        private readonly InputController inputController;
        private readonly SnakeController snakeController;
        private readonly SnakeFoodController snakeFoodController;
        private readonly ScoreController scoreController;
        private readonly SnakeFoodCollisionController collisionDetector;
        private readonly List<IRenderer> renderers = new List<IRenderer>();
        private readonly Settings settings = new Settings();

        public SnakeApplication()
        {
            InitializeComponent();
            //Application.Idle += HandleApplicationIdle;
            var board = CreateBoard();
            var snake = SnakeCreator.CreateSnake(board);
            this.inputController = new InputController();
            this.snakeController = new SnakeController(board, snake);
            this.collisionDetector = new SnakeFoodCollisionController(board, snake);
            this.snakeFoodController = new SnakeFoodController(board);
            this.scoreController = new ScoreController(new Score());
            
            InitializeRenderers();
            InitializeObservers();
            InitializeTimer();
        }

        private void InitializeTimer()
        {
            timer1.Interval = settings.UpdateInterval;
            timer1.Start();
        }

        private new void Update()
        {
            pbCanvas.Invalidate();
            snakeController.Update();
            collisionDetector.Update();
            snakeFoodController.Update();
        }

        private void UpdateGraphics(object sender, PaintEventArgs e)
        {
            foreach (var renderer in renderers)
            {
                renderer.Render(e.Graphics);
            }
        }

        private Board CreateBoard()
        {
            var screenBounds = pbCanvas.Bounds;
            var boundaries = new Boundaries(screenBounds.Left, screenBounds.Top, screenBounds.Right, screenBounds.Bottom);
            return new Board(boundaries, settings.SnakePartSize.Width);
        }

        private void InitializeObservers()
        {
            inputController.AddObserver(snakeController);
            snakeController.AddObserver(this);
            collisionDetector.AddObserver(snakeController);
            collisionDetector.AddObserver(snakeFoodController);
            collisionDetector.AddObserver(scoreController);
        }

        private void InitializeRenderers()
        {
            renderers.Add(new SnakeRenderer(snakeController.Snake));
            renderers.Add(new SnakeFoodRenderer(snakeFoodController));
            renderers.Add(new ScoreRenderer(label1, scoreController));
        }

        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            inputController.OnKeyDown(e);
        }

        public void HandleEvent(SnakeDyingEvent e)
        {
            timer1.Stop();
        }

        //private void HandleApplicationIdle(object sender, EventArgs e)
        //{
        //    //var stopWatch = new Stopwatch();

        //    while (IsApplicationIdle())
        //    {
        //        Thread.Sleep(1000);
        //        //stopWatch.Start();
        //        Update();
        //        Render();
        //        //stopWatch.Stop();
        //        //Time.DeltaTime = stopWatch.Elapsed.TotalSeconds;
        //        //stopWatch.Reset();
        //    }
        //}

        //[StructLayout(LayoutKind.Sequential)]
        //public struct NativeMessage
        //{
        //    public IntPtr Handle;
        //    public uint Message;
        //    public IntPtr WParameter;
        //    public IntPtr LParameter;
        //    public uint Time;
        //    public Point Location;
        //}

        //[DllImport("user32.dll")]
        //public static extern int PeekMessage(out NativeMessage message, IntPtr window, uint filterMin, uint filterMax, uint remove);

        //bool IsApplicationIdle()
        //{
        //    NativeMessage result;
        //    return PeekMessage(out result, IntPtr.Zero, (uint)0, (uint)0, (uint)0) == 0;
        //}

        private void FixedUpdate(object sender, EventArgs e)
        {
            Update();
        }
    }
}
