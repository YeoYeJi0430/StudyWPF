   M S B A M L   `   `   `  ����L  HMqttMonitoringApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MqttMonitoringApp.ViewsMqttMonitoringApp.Views  5      -    'MqttMonitoringApp.Views.CustomPopupView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5      1local%clr-namespace:MqttMonitoringApp.Views  5        � WindowStyle$  
ToolWindow=�5
       � WindowStartupLocation$ CenterOwner=�6    � 
ResizeMode$ NoResize=�6B   $	��220��5      $	��300��6   .��5      � $��15q�6    � RowDefinitions 5   
   �� 5      $
��0.5* �6   �� 5      $
��1.2* �6   �� 5      $
��1.2* �6   �� 5      $
��auto �6   .+�5   
   �� -   5         ��Name$ DisplayName��5      $��0��6)   �� 5   
   -   5         ��Name$ BokerIP��5      $��1��6#      MahApps.Styles.TextBox#��[  60   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ 	BrokerUrl��6`   $��18(�6�   �� 5   
   -   5        $ Topic��5      $��2��6!   #��[  6.   $ Topic��6^   $��18(�6�   $��0,1,0,1q�6�   �� 5   
   $��3��6    �� Orientation$ 
Horizontal=�6"   $��Right=�6;   .+�5      �� -   5         ��Name$ AcceptClose��5      	 �� 	IsDefault	 .  ( $MahApps.Styles.Button.Dialogs.Accent#���  6;   $��ACCEPT��6z   �� 5      
 �� IsCancel
 .  ! MahApps.Styles.Button.Dialogs#���  6%   $��CANCEL��6]   $��5,0,0,0q�6n   5      5      5      