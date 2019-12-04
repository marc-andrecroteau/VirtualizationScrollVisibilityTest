﻿using System;
using System.Windows;
using System.Windows.Threading;
using AlphaChiTech.Virtualization;

namespace VirtualizationScrollVisibilityTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //this routine only needs to run once, so first check to make sure the
            //VirtualizationManager isn’t already initialized
            if (!VirtualizationManager.IsInitialized)
            {
                //set the VirtualizationManager’s UIThreadExcecuteAction. In this case
                //we’re using Dispatcher.Invoke to give the VirtualizationManager access
                //to the dispatcher thread, and using a DispatcherTimer to run the background
                //operations the VirtualizationManager needs to run to reclaim pages and manage memory.
                VirtualizationManager.Instance.UIThreadExcecuteAction = a =>
                {
                    if (Application.Current.Dispatcher != null) Application.Current.Dispatcher.Invoke(a);
                };
                new DispatcherTimer(TimeSpan.FromMilliseconds(10),
                    DispatcherPriority.Background,
                    delegate { VirtualizationManager.Instance.ProcessActions(); },
                    this.Dispatcher).Start();
            }

            DataContext = new MainWindowViewModel();
        }
    }
}
