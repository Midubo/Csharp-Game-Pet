   M S B A M L   `   `   `  ����  Pet    Pet.UserControl_SelectPet   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -   5        ���#eaf1fc  � 	Resources  5       �� 
TargetType �� Property �� Value �� 
TargetType � RowDefinitions � Cursor �� CornerRadius �� EndPoint	 �� 
StartPoint
 � Color � Offset �� Triggers P� Property P� Value �� 
TargetName   StackPanelStyle �� Triggers �� BasedOn��%�  '��       '	� �    &	  .    '�� �    '�� u    '�� �    7���� 5
   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      � ���#25A0DA 5      �� 5   "   $
��Auto �60   �� 5   "   $��* �60   .+�5      �� $��0��6%   ���#25A0DA���#25A0DA._�5   "   �� 
�������.��5   &   �� $��Header��67   ��. 6N   5   #   5      �� 5      $��1��6%   $��5 0 5 5q�62   ���#25A0DA���#eaf1fc._�5   "   �� $��4q�63   5      5      5      5       5!      �� 5#   
   " 	�6   .�5$      ��  � �� 5%      �� 5&      " 	�6&   .R�5'      �� $
 Hand��6*   ._�5)      �� $
��Auto��6%   $ 3��63   ���	#FFE2E2E2$��1q�6\   ._�5*   "   � .+�5+   &   �� $��Center=�67   $
��20 0q�6R   �� 5.   &   $��	RadioMark��6r   $��10��6-   $��5,0,48,0q�68   ���	#FFCDCDCD$ 1��6a   $
��Left=�6�   5/   #   ��51   "   �� 52   &   $ 0.5,1&�6:   $	 0.5,0&�6K   .��53   *   � $
 White��67   $ 0Q�6E   � 54   *   $
 	#FFE2E2E2��67   $ 1Q�6I   55   '   58      5:       5<      P� 5=       �@d�	IsChecked$
 trueY�6;   . �5>   "   �� $ 	RadioMark��6)    � ��
 ����6V   5?      P� 5A       � {� .  . �5B   "   �� $ 	RadioMark��6)    � y�$ 	Collapsed=�6V   5C      5F      5H      5I      �� 5K   
   " ��6(   .�5L      ��  � ��$	 5,0q�6'    5N      P� 5O       � {� .  . �5P      ��  �@J�Opacity$	 0.5Q�60   6>   5Q      5S      �� 5U   
   " ��6   .�5V      ��  � ��$
 Wrap=�6-   �� 5W       � ��$ Center=�62   �� 5X       � ��$ 22(�6)   5Y      �� 5[   
   " ��6   .�5\      ��  � ��$
 None=�6(   5]      �� 5_   
   " ��6   8   .�5`      ��  � ��$ 35��6'   �� 5a       � ��$ 30(�6)   �� 5b       � ��$	 225��6)   5c      5e      .��5g      �  5h   
   �� 5i      $
��auto �6   6,   �� 5j      6   .+�5m   
   �� $��0��6   ���	#FF00B5C5$��5q�66   $ 	0 0 10 10��6J   
������._�5n      �� $
��10 0q�6   .+�5o      �� $��CHOOSE A PET��6   $��Center=�60   $
��Bold"�6M   $
��auto��6_   5p      5q      � 5s   
   -   5        $��PropertiesBox��5s      $��1��6$   $��
10 0 10 10q�61    � ColumnDefinitions 5t      �� 5u      �� 5v      $	��500 �6#   .+�5y      � $��0��6    5{      �� 5|      $
��auto �6$   �� 5}      $��* �6$   �� 5~      $
��auto �6$   .+�5�      �� $��0��6   .+�5�      �� -   5        $��tblc_IntroGoal��5�       $
��Wrap=�66   • Make your pet 100% �� 5�   +   ���#5ed836$
��Bold"�6D   .�6V   ♥6Y   %# (happy) in a given period of time.�� 6�   • �� 5�      $.��(pack://application:,,,/Images/hunger.png��6   $��32��6P   $��32��6[    �� BitmapScalingMode$ NearestNeighbor=�6g   $
��Fill=�6�    (�� 6�   
���Gc��$
��bold"�6�   .�6�   hunger6�   (&) raises by 1 every day and decreases �� 6	  ���#5ed836$
��Bold"�6"  .�64  ♥67  .�� 6=  • �� 5�       �� BaselineAlignment$ Center=�6   .�67   	You get 16B    �� 6H   $,��&pack://application:,,,/Images/coin.png��6N   $��32��6~   $��32��6�   $ NearestNeighbor=�6�   $
��Fill=�6�    �� 6�   $ Center=�6�   .�6�   (coin) and 16   �� 6  $,��&pack://application:,,,/Images/time.png��6  $��32��6B  $��32��6M  $ NearestNeighbor=�6Y  $
��Fill=�6�   �� 6�  $ Center=�6�  .�6�  (free hour) every day.6�  6�  � 5�       5�      �� 5�      $
��Auto �6/   �� 5�      $
��Auto �6/   �� 5�      �� 5�      .+�5�      �� $��0��6$   $0��*• Win games to unlock all pets and ages!��64   �� 5�      -   5        $��
tblc_Intro��5�   4   $��1��6$   $��5 0 5 0q�6F   $��Right=�6W   $��Center=�6s   	Wins: {0}6�   �� 5�      -   5        $��	btn_Erase��5�   1   $��2��6!    � ToolTip$ Erase your results��6Z   $
��Left=�6w   
������ 
������ $
��Auto��6�   .��5�      �� $.��(pack://application:,,,/Images/delete.png��6$   $��20��6V   $��20��6a   $
��Fill=�6m    �� EdgeMode$ Aliased=�6|   5�      �� 5�      -   5        $��
btn_AddWin��5�   !   $��3��63   $y�	Collapsed=�6X   .��6o   	Add win6x   5�      5�      � 5�      $��1��6    5�      �� 5�      $
��Auto �6(   �� 5�      $��* �6(   �� 5�      $
��Auto �6(   .+�5�      � $��0��6   $��0 10 0 5q�6(    5�      �� 5�      $
��Auto �6/   �� 5�      �� 5�      .+�5�      �� -   5        $��	tblc_Name��5�   4   $��0��6$   Type your pet's name:6\   �� 5�      -   5        $��tb_Name��5�   2   $��1��6"   $��22(�6A   $	��5 0q�6O   $	��Rex��6\   �� 5�      -	   5        $��tblc_WarningName��5�   4   $��2��6$   
���  ��$y�Hidden=�6]   $��Enter the name!��6q   5�      �� 5�      $��1��6   ��5�      �� 5�      ���	#FF00B5C5$ 10��6=   
��� ���._�5�   "   �� $
��10 0q�6-   .+�5�   &   �� $	��PET��60   $��Center=�6;   $
��Bold"�6X   $
��auto��6j   5�   #   5�      .��5�      � ���#eaf1fc  5�      ��%S   '��       �� 5�   "   " ��6(   .�5�   &   ��  � ��$	 120��6?   5�   #   5�       5�      �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   �� 5�   "   .+�5�      �� $��0��6)   #��[  69   .+�5�   "   �� $��5q�6)   $ 10��6=   ���	#FF000000._�5�   &   �� $-��'pack://application:,,,/Images/puppy.png��6,   6_   5�   #   	� 5�   "   -
   5        $��choicePuppy��5�   .   
������ 	� 	GroupName$	 Pet��6\    d� 	IsChecked$
 TrueY�6�   ��5�   &   �� 5�   *   -   5        $��textBlock_choiceA��5�   4    �� TextAlignment$ Justify=�6M   Puppy5�   +   5�   #   �� 5�   "   �� 5�   &   ���#5ed836$
��Bold"�6?   .�6Q   +5 ♥6W   5�   #   5�      �� 5�      $��1��6(   $��3 WINS��68   $��Center=�6F   $��18(�6c   
���  ��$
��Bold"�6�   ��5�   "   �� 5�   &   .�5�   *   ��  � y�$ 	Collapsed=�6Q    5�   *   �� 5�   .    �� Binding 6:   �� *	IsEnabled+ �� ElementName$ stackPanel_Kitty�� �� Value	 False6v   .a�5�   2   ��  � y�$ Visible=�6Y   5�   /   5�   '   5�      �� 5�      -   5        $��stackPanel_Kitty��5�   9   $��1��6)   #��[  6Q   {�.  .+�5�   "   �� $��5q�6)   $ 10��6=   ���	#FF000000._�5�   &   �� $-��'pack://application:,,,/Images/kitty.png��6,   6_   5�   #   	� 5�   "   -   5        $��choiceKitty��5�   .   
��� ���$	 Pet��6U   ��5�   &   �� 5�   *   -   5        $��textBlock_choiceB��5�   4   $ Justify=�6M   Kitty5�   +   5�   #   �� 5�   "   �� 5�      ���#5ed836$
��Bold"�67   .�6I   +1 Day6Q   5�   #   5�      �� 5�      $��2��6(   $��4 WINS��68   $��Center=�6F   $��18(�6c   
���  ��$
��Bold"�6�   ��5�   "   �� 5�   &   .�5   *   ��  � y�$ 	Collapsed=�6Q    5  *   �� 5  .    6:   �� *	IsEnabled+$ stackPanel_Parrot��	 False6w   .a�5  2   ��  � y�$ Visible=�6Y   5  /   5  '   5	     �� 5     -   5        $��stackPanel_Parrot��5  9   $��2��6)   #��[  6R   {�.  .+�5  "   �� $��5q�6)   $ 10��6=   ���	#FF000000._�5  &   �� $.��(pack://application:,,,/Images/parrot.png��6,   6`   5  #   	� 5  "   -   5        $��choiceParrot��5  .   
���2͚�$	 Pet��6[   ��5  &   �� 5  *   -   5        $��textBlock_choiceC��5  4   $ Justify=�6M   Parrot5  +   5  #   �� 5  "   $	��Top=�6,   �� 5     ���#5ed836$
��Bold"�67   $	 Top=�6I   .�6a   
50% less6k   �� 6p   $.��(pack://application:,,,/Images/hunger.png��6v   $��32��6�   $��32��6�   $ NearestNeighbor=�6�   5  #   5     �� 5     $��3��6(   $��5 WINS��68   $��Center=�6F   $��18(�6c   
���  ��$
��Bold"�6�   ��5  "   �� 5  &   .�5   *   ��  � y�$ 	Collapsed=�6Q    5"  *   �� 5#  .    6:   �� *	IsEnabled+$ stackPanel_Hamster��	 False6x   .a�5$  2   ��  � y�$ Visible=�6Y   5%  /   5'  '   5)     �� 5+     -   5        $��stackPanel_Hamster��5+  9   $��3��6)   #��[  6S   {�.  .+�5,  "   �� $��5q�6)   $ 10��6=   ���	#FF000000._�5-  &   �� $/��)pack://application:,,,/Images/hamster.png��6,   6a   5.  #   	� 50  "   -   5        $��choiceHamster��50  .   
����p��$	 Pet��6^   ��51  &   �� 52  *   -   5        $��textBlock_choiceD��52  4   $ Justify=�6M   	Hamster54  +   56  #   �� 58  "   �� 59     ���#5ed836$
��Bold"�67   .�6I   	+10 ♥6P   , �� 6W   
���Gc��$
��Bold"�6o   .�6�   -1 Day6�   5:  #   5<     �� 5>     $��4��6(   $��6 WINS��68   $��Center=�6F   $��18(�6c   
���  ��$
��Bold"�6�   ��5?  "   �� 5@  &   .�5A  *   ��  � y�$ 	Collapsed=�6Q    5C  *   �� 5D  .    6:   �� *	IsEnabled+$ stackPanel_Panda��	 False6v   .a�5E  2   ��  � y�$ Visible=�6Y   5F  /   5H  '   5J     �� 5L     -   5        $��stackPanel_Panda��5L  9   $��4��6)   #��[  6Q   {�.  .+�5M  "   �� $��5q�6)   $ 10��6=   ���	#FF000000._�5N  &   �� $-��'pack://application:,,,/Images/panda.png��6,   6_   5O  #   	� 5Q  "   -   5        $��choicePanda��5Q  .   $	 Pet��6A   ��5R  &   �� 5S  *   -   5        $��textBlock_choicePanda��5S  4   $ Justify=�6Q   Panda5U  +   5W  #   �� 5Y  "   �� 5Z     ���#5ed836$
��Bold"�67   .�6I   +1 ♥ every day6Y   5[  #   5]     5^     5`     �� 5b     $��2��6   ��5c     �� 5d     ���	#FF00B5C5$ 10��6=   
��� ���._�5e  "   �� $
��10 0q�6-   .+�5f  &   �� $	��AGE��60   $��Center=�6;   $
��Bold"�6X   $
��auto��6j   5g  #   5h     .��5k     �� 
�������.+�5l     	� -   5        $��
AgeChoice1��5l  *   $
 TrueY�6<   .��5m  "   �� �� 5n  &   $ Center=�6*   .�6E   	1 month (6P   �� 6U   ���#5ed836$
��Bold"�6n   $ Center=�6�   .�6�   +1 Day6�   , �� 6�   
���Gc��$
��Bold"�6�   $ Center=�6�   .�6�   +16�   �� 6�   $.��(pack://application:,,,/Images/hunger.png��6�   $��32��60  $��32��6;  $ NearestNeighbor=�6G  $
��Fill=�6y  �� 6�  $ Center=�6�  .�6�  )6�  5o  #   5q     	� 5s     -   5        $��
AgeChoice2��5s  *   {�.  .��5t  "   �� 6 months (no effect) [1 win]5v  #   5w     	� 5y     -   5        $��
AgeChoice3��5y  *   {�.  .��5z  "   �� 12 months (�� 5{  :   ���#5ed836$
��Bold"�6S   $ Center=�6e   .�6�   +1 ♥6�   , �� 6�   
���Gc��$
��Bold"�6�   $ Center=�6�   .�6�   -1 Day6�   
) [2 wins]5|  #   5}     5     5�     5�     5�     � 5�     $��1��6    5�     �� 5�     �� 5�     $
��Auto �6$   .+�5�     �� $��0��6   .+�5�     �� ���	#FF00B5C5$��5q�65   $ 10��6I   
������$��Center=�6s   $	��100��6�   $��0 5 0 0q�6�   ._�5�     �� $
��10 5q�6%   .+�5�     �� -   5        $��tlbc_PetName��5�  (   $��Center=�6l   $ Center=�6�   $
��Bold"�6�   ��6<   �� $ tb_Name�� �� Path$
 Text�6�   5�     5�     �� 5�     $��5q�6   ���	#FF000000$	��5 0q�6I   $ 10��6V   ._�5�     �  5�     �� 5�  "   �� 5�  "   .+�5�     � $��0��6#    5�  "   �� 5�  &   �� 5�  &   �� 5�  &   .+�5�  "   �� $��0��6,   $��10q�6<   Pet: �� 5�  +   �6/   �� *SelectedPet.Type+�� 5�  &   �� 5�  &   $�Special:��6*   $
��Bold"�6:    �� 6O   �6S   �� *SelectedPet.Special+5�  #   �� 5�  "   -   5        $��img_Pet��5�  8   $��1��6(   ��6G   �� *SelectedPet.ImageSource+�� 5�  "   $��2��6-   .+�5�  &   �� $ Center=�60   $��Age effect:��6G   �� 5�  &   -   5        $��tblc_Effect��5�  0   $ Center=�6C   $��+1 Day
+1 hunger��6Z   5�  #   5�     �� 5�     $��1��6(   $
��10 0q�6^   $ Justify=�6l   ��65   �� *SelectedPet.Description+6l   5�     5�     5�     � 5�     $��1��6    5�     �� 5�     �� 5�      5�     �� 5�     �� 5�     .+�5�     �� -   5        $��	btn_Start��5�  :   $��0��6   $��0��6-   $ Start��6b   $��1q�6r   .��5�     �� $��Center=�6$   $��30(�6?   ✔5�     5�     �� 5�     -   5        $��btn_Restart��5�  :   $��1��6   $��0��6-   $ Default settings��6g   $��1q�6�   .��5�     �  5�     �� 5�  "   $
��Auto �63   6B   �� 5�  "   65   .+�5�     �� $.��(pack://application:,,,/Images/reload.png��6$   $��20��6V   $��Uniform=�6e   �� 5�     $��1��6(   $��Center=�68   $	��5 0q�6S   $��30(�6`   	Restore6w   5�     5�     �� 5�     -    5        $��btn_MainMenu��5�  :   $��0��6   $��1��6-   $��1q�6i   .��5�     �� $��Center=�6$   $��30(�6?   	Main Menu5�     5�     �� 5�     -!   5        $��btn_Exit��5�  :   $��1��6   $��1��6-   $ Exit the game��6a   $��1q�6y   .��5�     �� $��Center=�6$   $��30(�6?   	Exit Game5�     5�     5�     5�     5�     5�     5�     