   M S B A M L   `   `   `  ����@  <Chess, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Chess.View
Chess.View  5   	   1clr-namespace:Chess.ConverterChess.Converter  5   	   1clr-namespace:Chess.ViewModelChess.ViewModel  5   	       Chess.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Chess.View     5   	   3	converterclr-namespace:Chess.Converter     5   	   ,vnclr-namespace:Chess.ViewModel     5   	     � SizeToContent$  WidthAndHeight=�5
   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	   ���	#FFF3F1F1 � Title$ Chess��5   	    � Icon$ Images/K_W.png��5   	    � DataContext 5      !   Chess.ViewModel.GameStateVM  5   
   -   5        GameSessionVM��5   2   .��5      �  6   ��  � 	Resources 5   
   *   $Chess.Converter.BoardHeightConverter   HeightConverter)   #Chess.Converter.BoardWidthConverter  WidthConverter��%:   &	        &	        5      6G     5      6E   5      .+�5   
      Chess.View.Menu  $��Center=�6   $
��Left=�60   $��50 25 25 25q�6K   6b   � 5   
    � ColumnDefinitions 5      �� 5      $	��250 �6#   �� 5       $��40 �6#   �� 5!      ��6#   �� *CurrentBoard+ �� 	Converter# [ �� 5"      $��40 �6#   �� 5#      $��40 �6#   �� 5$      $	��250 �6#   	 � RowDefinitions	 5&      �� 5'      $��* �6    �� 5(      $��40 �6    �� 5)      ��6    �� *CurrentBoard+# [  �� 5*      $��40 �6    �� 5+      $��* �6    .+�5.      �� 
���   �$��1��6'   $��1��67   6F   �� 5/      
���   �$��3��6'   $��1��67   6F   �� 50      
���   �$��1��6'   $��3��67   6F   �� 51      
���   �$��3��6'   $��3��67   6F   '   !Chess.View.ChessBoardColumnBorder  54      $��2��6+   $��1��6;   6J     55      $��2��6+   $��3��6;   6J   $   Chess.View.ChessBoardRowBorder  56      $��3��6(   $��2��68   6G     57      $��1��6(   $��2��68   6G   %   Chess.View.ChessBoardBackground  58      $��2��6)   $��2��69   6H      Chess.View.PossibleMoves  59      $��2��6"   $��2��62   6A   	   Chess.View.InCheckSignal	  5:      $
��Left=�6"   $	��Top=�6=   $��2��6V   $��2��6f   6u   !
   Chess.View.ChessPieceImages
  5;      $��2��6%   $��2��65   6D   "   Chess.View.ChessBoardButtons  5<      $��2��6&   $��2��66   $��2q�6C   
�������6m   5>         Chess.View.ChessGraveyard  5?   
   $��Center=�6   $��Right=�6:   $��25 50 50 50q�6V   6m   5@      5A      