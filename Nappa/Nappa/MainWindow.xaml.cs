using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using System.Threading;

namespace Nappa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MediaPlayer mediaPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();


        }

        private void btnOpenAudioFileClick(object sender, RoutedEventArgs e)
        {
            var demon = new Thread(midi =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == true)
                {
                    mediaPlayer.Open(new Uri(openFileDialog.FileName));
                    mediaPlayer.Play();
                }
            })
            {
                IsBackground = true
            };
            demon.Start();
        }

        //private void PlayAudioFile()
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    openFileDialog.Filter = "MP3 files (*.mp3)|*.mp3|All files (*.*)|*.*";
        //    if (openFileDialog.ShowDialog() == true)
        //    {
        //        mediaPlayer.Open(new Uri(openFileDialog.FileName));
        //        mediaPlayer.Play();
        //    }
        //}
    }
}
