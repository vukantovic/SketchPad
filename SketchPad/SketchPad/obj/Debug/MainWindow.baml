   M S B A M L   `   `   `  ����D  @SketchPad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:SketchPad	SketchPad  5   	       SketchPad.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:SketchPad     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $
��229* �6   �� 5      $
��191* �6    � ColumnDefinitions 5   
   �� 5      $
��347* �6   �� 5      $	��49* �6   �� 5      $
��398* �6   .+�5   
   o� -   5         o�Name$
 Menu��5      $��
0,0,-0.4,0q�6   $��3��61   $��83��6E   $	��Top=�6Q   .@�5      m� -   5         m�Name$
 File��5      $��                 File��6%   $��Center=�6D    J� 	AllowDrop . $��83��6p   $	��140��6|   .@�5      m� -   5        $ 	OpenImage��5      $
��Open��6.   6Q   m� 5      -   5        $
 Save��5      $
��Save��6)   6L   5      m� 5      -   5        $ Brush��5      $��             Brush    ��6&   $	��126��6F   5      m� 5      -   5        $ Erase��5      $��
  Eraser  ��6'   6Q   m� 5      -   5        $
 Undo��5      $��61��69   ��5      �� 5      $��
   Undo   ��6    $��Center=�62   $��Center=�6O   $��51��6j   5       m� 5!      -   5        $
 Redo��5!   +   $��
   Redo   ��6   $��65��6L   m� 5"      -	   5        $ Delete��5"      $��
  Delete  ��6(   6<   �� 5#      -
   5         ��Name$ sldSize��5#      $	��222��6'    � Maximum$ 30Q�6W    � Minimum$ 1Q�6d   5%      �� 5&   
   -   5        	 ��Name$	 cnsBackground��5&      $��0,83,-0.4,0q�6(   $��3��6=   $��2��6Q   
�������6�   5(      5)      