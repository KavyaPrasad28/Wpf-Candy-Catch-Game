   M S B A M L   `   `   `  ����I  ECandyCatchGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:CandyCatchGameCandyCatchGame  5   	       CandyCatchGame.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:CandyCatchGame     5   	     � Title$  Candy Catch Game��5   	   $	��700��6"   $	��525��6/   ���	#FFBEF7ED � 
ResizeMode$ CanMinimize=�6R    � WindowStartupLocation$ CenterScreen=�6k    � Icon$ Images/candy4.png��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��10* �6   .+�5   
   �� -   5        $��lblScore��5      $��18(�6    $��
ExtraBlack"�6.   $��Score: 0��6F   $	��150��6Y   $��35��6e   $
��Left=�6q   �� 5   
   -   5        $��	lblMissed��5      $��18(�6!   $��
ExtraBlack"�6/   $��	Missed: 0��6G   $	��150��6[   $��35��6g   $��Right=�6s   �� 5   
   -   5         ��Name$ MyCanvas��5      $��1��6   |�. .+�5      �� -   5        $��player1��5      $��80��6'   $��80��62    �� Left$	 214��6>   
 �� Top$	 520��6P   
���  ��6a   5      5      5      