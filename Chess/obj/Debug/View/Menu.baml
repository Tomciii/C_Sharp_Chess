   M S B A M L   `   `   `  ����@  <Chess, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Chess.ConverterChess.Converter  5      1clr-namespace:Chess.ViewModelChess.ViewModel  5      'clr-namespace:Chess.View
Chess.View  5          Chess.View.Menu   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3	converterclr-namespace:Chess.Converter     5      ,vnclr-namespace:Chess.ViewModel     5      *localclr-namespace:Chess.View     5        � 	Resources  5      /   )Chess.Converter.GameStateMessageConverter   GameMessage��%   &	          5   
   6D   5      .��5      �� $
��Left=�6   $	��190��6,     5   
    �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%m  '��       '�� �     �� 5      " ��6   .�5      ��  � ��$ 0 5 0 5q�6+   6=   �� 5       � ��$	 100��6*   68   �� 5       � ��$ 25��6+   68   5      �� 5      " ��6    5      �� 5       6"   �� *WhitePlayerWon+ true6E   .a�5      ��  � �� �	#FF56FF566K   �� 5       � ��
 � � �6H   �� 5       � ��$ 2q�6<   6H   5      �� 5       6"   �� *BlackPlayerWon+ true6E   .a�5      ��  � �� �	#FF56FF566K   �� 5        � ��
 � � �6H   �� 5!       � ��$ 2q�6<   6H   5"      5$      5%      .+�5&   
   �� $
��0 15q�6   ._�5'      �� $	��Top=�6   $��Center=�60   $
��0 15q�6M   $��16(�6[   ��5(      `� 5)       `� 	Converter# [  6#   .1�5*      ��  �� Path$ WhitePlayerWon�6"   6:   �� 5+      $ BlackPlayerWon�6"   6:   �� 5,      $ GameHistory�6"   67   �� 5-      $ CurrentBoard�6"   68   5.      50      51      �� 53   
   ��6   �� *StartNewGameSession+.��69   
New Game6C   �� 54   
   -   5        .��54   )   	Save Game64   �� 55   
   -   5        ��55   )   �� *
NotifyVM+.��6F   	Load Game6Q   �� 57   
   -   5        	 ��Name$	 
ChessTurns��57      $	��140��6'   $	��300��63   $
��0 10q�6@   $��Hidden=�6r   ��6N   �� *GameHistory+
 �� View
 58      �� 59      ! �� ColumnHeaderContainerStyle 5:      �� 5;      " ��6    .�5<      ��  � {� .  6J   5=      .P�5?      �� $��Turns��6%    �� Width$	 140��64    �� CellTemplate 5@      �� 5A      .R�5B   "   �� ��6(   �� *Name+5C      5E      5F      5H      �� 5J   
   ��6   �� *
LoadTurn+��6.   ��  �� ElementName$ 
ChessTurns��$ SelectedIndex�.��6v   	Load Turn6�   5K      5L      