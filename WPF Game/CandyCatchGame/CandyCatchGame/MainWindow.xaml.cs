using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CandyCatchGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int maxItems = 5;
        int currentItems = 0;

        Random rand = new Random();

        int score = 0;
        int missed = 0;

        Rect playerHitBox;

        DispatcherTimer gameTimer = new DispatcherTimer();

        List<Rectangle> itemsToRemove = new List<Rectangle>();

        ImageBrush playerImage = new ImageBrush();
        ImageBrush backgroundImage = new ImageBrush();

        int itemSpeed = 10;
        public MainWindow()
        {
            InitializeComponent();

            MyCanvas.Focus();

            gameTimer.Tick += GameEngine;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();

            playerImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/basket.png"));
            player1.Fill = playerImage;

            backgroundImage.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/Candybg.jpg"));
            MyCanvas.Background = backgroundImage;
        }

        private void GameEngine(object sender, EventArgs e)
        {
            lblScore.Content = "Caught: " + score;
            lblMissed.Content = "Missed: " + missed;

            if(currentItems < maxItems)
            {
                MakeCandies();
                currentItems++;
                itemsToRemove.Clear();
            }

            foreach (var x in MyCanvas.Children.OfType<Rectangle>())
            {
                if ((string)x.Tag == "drops")
                {
                    Canvas.SetTop(x, Canvas.GetTop(x) + itemSpeed);

                    if (Canvas.GetTop(x) > 720)
                    {
                        itemsToRemove.Add(x);
                        currentItems--;
                        missed++;
                    }

                    Rect candiesHitBox = new Rect(Canvas.GetLeft(x), Canvas.GetTop(x), x.Width, x.Height);
                    playerHitBox = new Rect(Canvas.GetLeft(player1), Canvas.GetTop(player1), player1.Width, player1.Height);

                    if (playerHitBox.IntersectsWith(candiesHitBox))
                    {
                        itemsToRemove.Add(x);
                        currentItems--;
                        score++;
                    }
                }
            }

            foreach (var i in itemsToRemove)
            {
                MyCanvas.Children.Remove(i);
            }

            if (score > 10 )
            {
                itemSpeed = 20;
            }

            if(missed > 10)
            {
                gameTimer.Stop();
                DialogResult choice = System.Windows.Forms.MessageBox.Show("You Lost!" + Environment.NewLine + "You Score: " + score + Environment.NewLine + "Click ok to play again","Save the candies catch game", MessageBoxButtons.OKCancel);
                if(choice == System.Windows.Forms.DialogResult.Cancel)
                {
                    this.Close();
                }
                else
                {
                    ResetGame();
                }
            }
        }

        private void MyCanvas_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            Point position = e.GetPosition(this);

            double px = position.X;

            Canvas.SetLeft(player1, px - 35);
        }

        private void ResetGame()
        {
            System.Diagnostics.Process.Start(System.Windows.Application.ResourceAssembly.Location);
            System.Windows.Application.Current.Shutdown();
            Environment.Exit(0);
        }

        private void MakeCandies()
        {
            ImageBrush candies = new ImageBrush();

            int i = rand.Next(1, 6);

            switch(i)
            {
                case 1:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy1.png"));
                    break;
                case 2:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy2.png"));
                    break;
                case 3:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy3.png"));
                    break;
                case 4:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy4.png"));
                    break;
                case 5:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy5.png"));
                    break;
                case 6:
                    candies.ImageSource = new BitmapImage(new Uri("pack://application:,,,/Images/candy6.png"));
                    break;
            }

            Rectangle newRec = new Rectangle
            {
                Tag = "drops",
                Width = 50,
                Height = 50,
                Fill = candies
            };

            Canvas.SetLeft(newRec, rand.Next(10, 450));
            Canvas.SetTop(newRec, rand.Next(60, 150) * -1);

            MyCanvas.Children.Add(newRec);
        }
    }
}
