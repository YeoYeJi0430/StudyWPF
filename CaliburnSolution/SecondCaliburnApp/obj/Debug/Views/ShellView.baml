   M S B A M L   `   `   `  ����L  HSecondCaliburnApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:SecondCaliburnAppSecondCaliburnApp  5   	   '    !SecondCaliburnApp.Views.ShellView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   1localclr-namespace:SecondCaliburnApp     5   	   $	��400��5   	   $	��600��6   .��5	      �   � RowDefinitions  5
   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6    � ColumnDefinitions 5   
   �� 5      $��20 �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $��20 �6   .+�5   
   �� $��1��6   $��1��6!   $��2��61   $��20(�5      $��30��6"   ��5       �� *
FullName+ �� Mode$ OneWay=��� 5"   
   -   5         ��Name$ 	FirstName��5"      $��2��6%   $��1��62   $	��100��5#      $��25��6   �� 5%   
   -   5        $ LastName��5%      $	��100��5&      $��25��6   $��2��5'      $��2��6   �� 5)   
   -   5         ��Name$ People��5)      $��3��5*      $��1��6     �� DisplayMemberPath$ 	FirstName��5+       �� SelectedItem 5,      �� *SelectedPerson+�� 5/   
   -   5         ��Name$ ElectedPerson_LastName��5/      $��3��64   $��2��6A   $	��100��50      �� 52   
   -   5         ��Name$ 	ClearName��52      $��4��53      $��1��6   $��30��54      $��Clear��6   �� 57   
   -   5        $ LoadPageOne��57      $��5��6&   $��1��63   $��Load Page 1��58      �� 59   
   -   5        $ LoadPageTwo��59      $��5��6&   $��2��63   $��Load Page 2��5:      �� 5<   
   -   5        	 ��Name$	 
ActiveItem��5<      $��6��6-   $��1��6:   $��5��6J   5>      5?      