   M S B A M L   `   `   `  ����  Pet    Pet.Window_Menu   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Options��5   	   $	��400��6    � SizeToContent$ Height=�5   	    � 
ResizeMode$ NoResize=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � WindowStyle$
 None=�5   	   $'��!pack://application:,,,/#Kavivanar)�5
   	    � UseLayoutRounding . $��30(�5   	    � AllowsTransparency . 
������  � 	Resources 5       �� 
TargetType	 �� BasedOn
 �� Property �� Value �� 
TargetType � Cursor �� CornerRadius �� EndPoint �� 
StartPoint � Color � Offset �� Triggers P� Property P� Value �� 
TargetName��%�  '��       7��'�� M     �� 5   
   " ��6   8	   .�5      �� 
 � ��$ 30(�6)   5      �� 5   
   " ��6   .�5      �� 
 � �� 5      �� 5      " ��6&   .R�5      �� $
 Hand��6*   ._�5      �� $
��Auto��6%   $ 3��63   ���	#FFE2E2E2$��1q�6\   ._�5   "   � .+�5   &   �� $��Center=�67   $
��20 0q�6R   �� 5"   &   $��	RadioMark��6r   $��10��6-   $��5,0,48,0q�68   ���	#FFCDCDCD$ 1��6a   $
��Left=�6�   5#   #   ��5%   "   �� 5&   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5'   *   � $ White��67   $ 0Q�6E   � 5(   *   $ 	#FFE2E2E2��67   $ 1Q�6I   5)   '   5,      5.       50      P� 51       �@d�	IsChecked$
 trueY�6;   . �52   "   �� $ 	RadioMark��6)   
 � ��
 ����6V   53      P� 55       � {� .  . �56   "   �� $ 	RadioMark��6)   
 � y�$ 	Collapsed=�6V   57      5:      5<      5=      5>      .��5@      �� 
������$��5q�6&   $ 10��6:   
����·�._�5A   
   �� ���	#FF00B5C5$��2q�6)   $ 10��6=   $��1q�6O   ��5B      �� 5C      $ 0.5, 0&�6&   $ 0.5, 1&�6:   .��5D      � $ 	AliceBlue��6#   $	 0.0Q�65   � 5E      $ AntiqueWhite��6#   $	 0.5Q�68   � 5F      $ 	AliceBlue��6#   $	 1.0Q�65   5G      ._�5J      �� $��10q�6   .+�5L      �� -   5        $��Continue��5L   1   �� 5N      -   5        $
��Save��5N   -   �� 5P      -   5        $��btn_Restart��5P       � ToolTip$ Restart the game��6F   .��5Q      �  � ColumnDefinitions 5R      �� 5S      $
��Auto �6/   �� 5T      .+�5W      �� $��0��6    $.��(pack://application:,,,/Images/reload.png��60   $��20��6b   $��Uniform=�6q   �� 5Y      $��1��6$   $��Center=�64   $	��5 0q�6O   $��Restart��6\   5Z      5[      �� 5]      -   5        $��btn_MainMenu��5]      $ Return to Main Menu��6H   .��5^      �� $��Center=�6    $��	Main Menu��6;   5_      �� 5a      -   5        $��	Exit Game��5a   -   �� 5c      -   5        $��checkBox_Music��5c      $	��0 5q�62   $��Music��6?   5d      5e      5f      5g      