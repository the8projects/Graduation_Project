   M S B A M L   `   `   `  ����  
ProjectApp!    ProjectApp.Source.LoginForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	LoginForm��5   	   $	��400��6   $	��600��6(    � 
ResizeMode$ NoResize=�64    � Icon$) #/ProjectApp;component/Image/CV1.png��6J    � WindowStartupLocation$ CenterScreen=�6�    � Topmost . ���	#FFF18B10$��4q�6�   .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5	      �� 5
       � RowDefinitions 5   
   �� 5      $	��12* �6   �� 5      $��6* �6   �� 5      $��6* �6   �� 5      $��6* �6   �� 5      $��5* �6   .+�5   
   �� $��ร้าน Sweet Addict��6   $��	54,27,0,0q�6,   $	��Top=�6?   $��2��6W   $	��180��6k   $��Tahoma)�6w   $��16(�6�    � UseLayoutRounding .  $��30��6�   $��Center=�6�   $
��Bold"�6�   $
��Left=�6�   $��1��6  �� 5   
   $��Open 9.00 - 20.00 น.��6   $
��Left=�6/   $��	39,62,0,0q�6J   $	��Top=�6]   $��2��6u   $	��210��6�   $��Tahoma)�6�   $��16(�6�    .  $��30��6�   $��Center=�6�   $
��Bold"�6  $��1��6  �� 5   
   $��93,10q�6   $��1��6   $��2��6,   $��2��6=   $)��#/ProjectApp;component/Image/CV1.png��6Q   �� 5   
   $��Account   :��6   $��1��6&   $��	54,28,0,5q�66   $��1��6I   $��Tahoma)�6V   $��14(�6j   $��SemiBold"�6x   �� 5   
   $��
Password :��6   $��1��6%   $��	54,3,0,23q�65   $��2��6H   $��Tahoma)�6U   $��14(�6i   $��SemiBold"�6w   �� 5   
   -   5         ��Name$ 
txtAccount��5      $��2��6&   $��	10,32,0,5q�66   $��1��6I   	 �� 	MaxLength$	 16��6V   G� 5   
   -   5        
 G�Name$
 txtPassword��5      $��2��6+   $��	10,5,0,33q�6;   $��2��6N   �� 5   
   -   5         ��Name$ btnLogin��5      $��Login��6#   $��2��63   $��
68,41,0,40q�6C   $��2��6W   $��2��6{    �� 	IsDefault . 6�   �� 5   
   -   5        $ btnClear��5      $��Clear��6#   $��1��63   $��106,41,106,40q�6C   $��2��6Z   $��2��6g   $��2��6{   6�   �� 5   
   $I��CAddress : PSU, Hatyai. Tel 088-123-4567 Email : psucoffee@psu.ac.th��6   $��0,24,0,0q�6^   $��4��6p   $��4��6}   $��RightToLeft=�6�   �� 5   
   -   5         ��Name$ lbLoginStatus��5      $�� ��6'   $��1��62   $��	51,0,0,31q�6B   $��1��6U   $��3��6b   
���  ��$��SemiBold"�6�   5      5      