   M S B A M L   `   `   `  ����F  BBikeShopApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:BikeShopAppBikeShopApp  5          BikeShopApp.Discussion   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +localclr-namespace:BikeShopApp     5         Page_Background  N� 
Background#  �   5	       N� Title$ Contact��5
      .��5      � -   5         � RowDefinitions 5   
   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      �� 5      $	��150 �6   .+�5   
   �� $��0��6   $��0��6   $��2��6/   $��10q�6C   ��5         BikeShopApp.Talk  5      ��5      5  -System.Windows.Controls.ItemContainerTemplate�  5      .R�5      �� .+�5      ��  �� Orientation$ 
Horizontal=�6%   .+�5      �� $��/assets/chat.png��6$   $��20��6>   �� 5      ��6$   �� *Sender+5      �� 5       $
��Wrap=�6=   $��19(�6Q   ��6$   �� *	Content+6Q   5!      5"      5$      �� 5%   
   $��1��6   $��0��6   $��Type your message here��6/   $
��10,5q�6M   �� 5&   
   $��1��6   $��1��6   $
��SEND��6.   $��5q�6=   ��5'      �� 5(       �� 
TargetType" ��6"   .R�5)      � .+�5*      �� ���	#AA000000$��5,5,0,0q�65    �� RadiusX$ 5��6F    �� RadiusY$ 5��6R   �� 5+      #��z��6$   $��0,0,5,5q�6H   $ 5��6Y   $ 5��6e   (� 5,      $��0,0,0,5q�6"   .��5.      �� #��z��6$   5/      50      51      53      54      55      