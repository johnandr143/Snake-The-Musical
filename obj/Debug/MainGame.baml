   M S B A M L   `   `   `  ����D  @Test_Game, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:Test_Game	Test_Game  5   	       Test_Game.MainGame   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:Test_Game     5   	     � Title$  Snake! The musical Beta��5	   	   $	��600��6+   $	��800��68    � WindowStyle$ ThreeDBorderWindow=�6D   .��5      �� .+�5   
   �� -   5        $��
lbluseless��5      $��12(�6"   
�������$��Right=�6B    �� Left$	 640��6^   
 �� Top$ 10��6p   .��6�   Press Esc for Pause Menu6�   �� 5   
   -   5        $��yaboi��5      $	��480��6!   $	��480��6-   $ 20��6:   $ 20��6J   
���   �6j   �� 5   
   -   5         ��Name$ canvas��5      
���   �5      �� 5   
   -   5         ��Name$ Score��5      $ 50��6$   $	 500��64   .+�5      �� -   5         ��Name$ lblScore��5      $�� ��6&   $	��300��62   6@   5      �� 5   
   -   5        $ stkPause��5      $	��200��6'   $	��185��64   $	 220��6@   $	 550��6Q   .+�5      �� -   5         ��Name$ 
btnRestart��5      $��Restart��6B   $��25(�6T   $y�Hidden=�6b   6x   �� 5      -   5        $ btnSettings��5      $��Setting��6D   $��25(�6V   $y�Hidden=�6d   6z   �� 5      -	   5        $ 	btnResume��5      $��Resume��6(   $��25(�6Q   $y�Hidden=�6_   6u   �� 5      -
   5        $ btnExit��5      $
��Exit��6<   $��25(�6K   $y�Hidden=�6Y   6o   5      5      5      