   M S B A M L   `   `   `  ����L  HMqttMonitoringApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:MqttMonitoringApp.ViewsMqttMonitoringApp.Views  5      )    #MqttMonitoringApp.Views.HistoryView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      R NOxyPlot.Wpf, Version=2.0.0.0, Culture=neutral, PublicKeyToken=75e952ba404cdbb0 oxyhttp://oxyplot.org/wpf  5      :d2http://schemas.microsoft.com/expression/blend/2008  5      1local%clr-namespace:MqttMonitoringApp.Views  5      .��5
      �   � RowDefinitions  5   
   �� 5      $��50 �6   �� 5      $��* �6   .+�5   
   �� $��IoT History Datas��6      MahApps.Styles.Label#���   6,   $��25(�5      $��Black"�6   � 5   
   $��1��6     5      �� 5      $��40 �6    �� 5      $��* �6     � ColumnDefinitions 5      �� 5      �� 5      $	��100 �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Division��6   #���   6+   $��Center=�6Z   �� 5      -   5         ��Name$ 	Divisions��5      $	��150��6.    �� DisplayMemberPath$ DivisionVal��6:   $��Center=�5         MahApps.Styles.ComboBox#���  5!       �� SelectedItem 5"      �� *SelectedDivision+�� 5#      $��   StartDate��6   $��Center=�6/   (  "System.Windows.Controls.DatePicker  5$      -   5          Name$ 	StartDate��5$      $	��100��60      Text$ 
2020-09-01��6<   $��Center=�5%        MahApps.Styles.DatePicker#���  5&      �� 5'      $��
 ~ EndDate��6   #���   6-   $��Center=�6\     5(      -   5        $ EndDate��5(      $	��100��6.   $ 
2020-09-02��6:   $��Center=�5)      #���  5*      �� 5+      $�� Total Count��6   #���   6/   $��Center=�6^   �� 5,      -   5         ��Name$ 
TotalCount��5,      #���   6,   $��Center=�6[   5-      �� 5/      -   5        	 ��Name$	 Search��5/      $��1��6%   $��SEARCH��65   $
��10,0q�6F    ( $MahApps.Styles.Button.Dialogs.Accent#���  50      � 52      $��1��6   $��0��6    $��2��60   $��15q�6D   .+�53        OxyPlot.Wpf.Plot  
�������
   Series
 54        OxyPlot.Wpf.LineSeries  55        OxyPlot.Wpf.Series   Color$	 Red��6)      
MarkerType$
 None=�65      Title$ Temperature��6G   ��56   )   �� *
TempValues+  57      $ 	CadetBlue��6)   $
 None=�6;   $ Humidity��6M   ��58   )   �� *HumidValues+  59      $ Violet��6)   $
 None=�68   $ Pressure��6J   ��5:   )   �� *PressValues+5<      5=      5>      5?      5@      