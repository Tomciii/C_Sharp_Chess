   M S B A M L   `   `   `  ����@  <Chess, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Chess.View
Chess.View  5      1clr-namespace:Chess.ConverterChess.Converter  5      1clr-namespace:Chess.ViewModelChess.ViewModel  5      "    Chess.View.ChessBoardButtons   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      *localclr-namespace:Chess.View     5      3	converterclr-namespace:Chess.Converter     5      ,vnclr-namespace:Chess.ViewModel     5        � 	Resources  5      =   7Chess.Converter.ChessBoardObservableCollectionConverter   ListConverter��%   &	          5   
   6T   5      .��5      �   5   
    �� 
TargetType �� Property �� Value �� 
TargetType �� Triggers P� Property P� Value �� 
TargetName��%A  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6*   .R�5      �� $��buttonBorder��6%   $��2q�6:   
������ 6i    5      P� 5   "    �@J�IsMouseOver . . �5   &   �� $ buttonBorder��6-    � ��
 �����6n   5   #   5      5      5       5!      .+�5#   
   �� -   5        	 ��Name$	 ButtonControl��5#      
 � DataContext
 6.   �� ��6F   ��  �� Path$ CurrentBoard� �� 	Converter# [  ��5$      �� 5%      .R�5&      A�  A� Rows 6"   �� $ CurrentBoard.Row� A� Columns 6I   �� $ CurrentBoard.Column�6x   5'      ��5*      �� 5+      .R�5,      �� ��6   ��  �� ElementName$ ButtonControl��$ DataContext.SelectTile���6h   ��  �� RelativeSource �� *Self+$	 Tag�
 � Tag 6�   �� 6�   5-      5/      50      51      