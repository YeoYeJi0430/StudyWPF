   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	   O KArduinoMonitoringApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:ArduinoMonitoringApp.HelpersArduinoMonitoringApp.Helpers 5   	   ;"clr-namespace:ArduinoMonitoringAppArduinoMonitoringApp 5	   	   )   #ArduinoMonitoringApp.Views.MainView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   T PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3f6mah,http://metro.mahapps.com/winfx/xaml/controls  5   	   6helps*clr-namespace:ArduinoMonitoringApp.Helpers  5   	   .local"clr-namespace:ArduinoMonitoringApp  5	   	     � Title$  Arduino��5   	   (  "MahApps.Metro.Controls.MetroWindow   WindowTitleBrush
 �����$	��450��66   $
��1000��6C   .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5       � ColumnDefinitions 5   
   �� 5      $��2* �6   �� 5      $��* �6   �� 5      $
��0.5* �6   .+�5   
   o� $��0��6   $��0��6   $��12(�6,   .@�5      m� $��파일��6   .@�5      m� $��열기��6   m� 5      $��저장��6   m� 5      -   5         m�Name$
 Exit��5      $��	끝내기��6)   5      m� 5      $��76��6   $��시뮬레이션��6"   .@�5      m� -   5        $ Start��5      $��시작��6+   m� 5      -   5        $
 Stop��5      $��중지��6)   5       m� 5!      $��	도움말��6   .@�5"      m� -   5        $
 Info��5"      $��정보��6)   5#      5$      #   LiveCharts.Wpf.CartesianChart  5&   
   $��0��69   $��1��6I   &    LiveCharts.Wpf.Charts.Base.Chart   Series 6   �� *
ChartVal+   AxisY 5(         LiveCharts.Wpf.Axis     Title$ Value��6      MinValue$ 0Q�6)   	   MaxValue$
	 1000Q�66   
   AxisX
 5+        $
 Time��6   $ 0Q�6(   $		 200Q�65   5-      �� 5/   
   $��1��6   $��1��6"   $��25q�62   .+�50      ��  �� TextAlignment$ Right=�6   $��	20,0,20,5q�6.   $��12(�6A   연결시간6U   �� 51      -   5         ��Name$ SensorCount��51      $��10q�6+    �� TextAlignment$ Right=�67   �� 52      $��1��6   $��10,10,10.4,10q�6'   
���   �2  ,MahApps.Metro.Controls.HeaderedControlHelper   HeaderBackground
 �����
�������$	��103��6�   .��53      �� .+�54      �� $��25��6    $��포토레지스터��6,   $ Center=�6:   � 55      -   5         �Name$ PgbPhotoRegistor��55   "   $��25��6<    � Maximum$
 1000Q�6H    � Minimum$ 0Q�6W   ���	#FFFAC5E76c   �� 56      $��5��6    �� 57      -   5        $ LblPhotoRegistor��57      $ Center=�68   58      59      �� 5:      -   5        $ Board��5:      $	��140��6%   $��10q�62   " �� VerticalScrollBarVisibility$
 Auto=�6>   3  -ArduinoMonitoringApp.Helpers.TextBoxBehaviors   AutoScrollToEnd . .��5;   D   5<      5=      �� 5?   
   $��1��6   $��2��6"   $��15q�62   .+�5@      �� $ Right=�6   $��20,5,5,5q�6.   $��13(�6@   포트6R   �� 5A      -	   5         ��Name$ CboSerialPort��5A      $��10��6.   $��	0,14,0,10q�6:    �� SelectedItem 6M   �� *SelectedPortName+�� 5B      $��14��6   �� 5C      -
   5         ��Name$ Connect��5C      $��40��6&   $��CONNECT��62   $��0,0,0,10q�6D   �� 5D      -   5        $ 
DisConnect��5D      $��40��6)   $��
DISCONNECT��65   $��0,0,0,10q�6J   �� 5E      $��60��6   $
��PORT��6!   $��0,0,0,10q�60   5F      5G      5H      