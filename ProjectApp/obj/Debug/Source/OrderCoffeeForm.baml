   M S B A M L   `   `   `  ����  
ProjectApp'    !ProjectApp.Source.OrderCoffeeForm   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  	OrderForm��5   	   $	��500��6   $	��400��6(    � WindowStyle$
 None=�64   ���	#FFF18B10$��4q�6_    � WindowStartupLocation$ CenterScreen=�6s    � 
ResizeMode$ NoResize=�6�    � Topmost . .��5      �  � ColumnDefinitions 5   
   �� 5      $
��126* �6   �� 5      $	��70* �6   �� 5	      $	��19* �6   �� 5
      $	��18* �6   �� 5      $	��26* �6   �� 5      $	��20* �6   �� 5      $	��36* �6   �� 5      $	��77* �6    � RowDefinitions 5   
   �� 5      $	��14* �6   �� 5      $
��120* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��30* �6   �� 5      $	��63* �6   �� 5      $	��60* �6   .+�5   
   �� -   5         ��Name$ btnConfirmOrder��5      $��Order��6*   $��57,10,37,20q�6:   $��11��6O   $��2��6]   6q   �� 5   
   -   5        $ 	btnCancel��5      $��Cancel��6$   $��
0,10,55,20q�65   $��11��6I   $��4��6W   $��4��6   �� 5    
   -   5         ��Name$ imDrink��5       $��4��6!   $��1��65   $��
22,20,16,0q�6E   $��1��6Y   �� 5!   
   $��Product Name��6   $��	26,0,10,0q�6'   $��2��6:   $��Center=�6G   $��SemiBold"�6i   �� 5"   
   $��Price��6   $��	26,0,10,0q�6    $��4��63   $��Center=�6@   $��SemiBold"�6b   �� 5#   
   $��Stock(s)��6   $��	26,0,10,0q�6#   $��3��66   $��Center=�6C   $��SemiBold"�6e   �� 5$   
   $��Order Amount��6   $��	26,0,10,0q�6'   $��5��6:   $��Center=�6G   $��SemiBold"�6i   �� 5%   
   $��Total Price��6   $��
26,29,10,0q�6&   $��8��6:   $��Center=�6G   $��SemiBold"�6i   $��2��6   �� 5&   
   -   5        	 ��Name$	 
lbProdName��5&      $�� ��6$   $
��10,0q�6/   $��2��6=   $��Center=�6J   $��1��6l   $��5��6|   �� 5'   
   -   5        $	 lbProdStock��5'      $�� ��6%   $��10,0,0,0q�60   $��3��6B   $��Center=�6O   $��1��6q   $��Right=�6�   �� 5(   
   -   5        $	 lbProdPrice��5(      $�� ��6%   $��10,0,0,0q�60   $��4��6B   $��Center=�6O   $��1��6q   $��Right=�6�   �� 5)   
   $��	Low Sugar��6   $	��1,0q�6$   $��5��61   $��Center=�6>   $��1��6`   $��SemiBold"�6p   �� 5*   
   $��Medium��6   $	��1,0q�6!   $��6��6.   $��Center=�6;   $��1��6]   $��SemiBold"�6m   �� 5+   
   $��Sweet��6   $	��1,0q�6    $��7��6-   $��Center=�6:   $��1��6\   $��SemiBold"�6l   �� 5,   
   $��Total Amount��6   $��	26,0,10,0q�6'   $��8��6:   $��Center=�6G   $��SemiBold"�6i   �� 5-   
   -   5        
 ��Name$
 txtLowAmount��5-      $��2,1,1,1q�6(   $��5��69    �� TextWrapping$
 Wrap=�6F   $��Right=�6Z    �� 
IsReadOnly . 
����������	#FFFF4646$��4��6�    �� TextAlignment$ Center=�6�    �� 	MaxLength$ 3��6�   $	��2,1q�6�   $��2��6  �� 5.   
   -	   5        $
 txtMedAmount��5.      $��2,1,1,1q�6(   $��6��69   $
 Wrap=�6F   $��Right=�6Z    . 
����������	#FFFF4646$��4��6�   $ Center=�6�   $ 3��6�   $	��2,1q�6�   $��2��6  �� 5/   
   -
   5        $
 txtSweAmount��5/      $��2,1,1,1q�6(   $��7��69   $
 Wrap=�6F   $��Right=�6Z    . 
����������	#FFFF4646$��4��6�   $ Center=�6�   $ 3��6�   $	��2,1q�6�   $��2��6  �� 50   
   -   5        $ 	btnLowDec��50      $��<��6$   $��2��63   $	��0,4q�6C   $��5��6P   $
��Left=�6]   $��37��6x   $��2��6�   �� 51   
   -   5        $ 	btnMedDec��51      $��<��6$   $��2��63   $	��0,4q�6C   $��6��6P   $��2��6u   �� 52   
   -   5        $ 	btnSweDec��52      $��<��6$   $��2��63   $��0,4,0,3q�6C   $��7��6T   $��2��6y   �� 53   
   -   5        $ 	btnLowInc��53      $��>��6$   $��6��63   $	��0,4q�6C   $��5��6P   6]   �� 54   
   -   5        $ 	btnMedInc��54      $��>��6$   $��6��63   $	��0,4q�6C   $��6��6P   6]   �� 55   
   -   5        $ 	btnSweInc��55      $��>��6$   $��6��63   $��0,4,0,3q�6C   $��7��6T   6a   �� 56   
   -   5        $	 lbTotalAmount��56      $�� ��6'   $��10,0,0,0q�62   $��8��6D   $��Center=�6Q   $��1��6s   �� 57   
   -   5        $	 lbTotalPrice��57      $�� ��6&   $��10,0,0,0q�61   $��9��6C   $��Center=�6P   $��1��6r   �� 58   
   -   5        $	 lbProdPrice_Copy2��58      $��Cup(s)��6+   $��8��6<   $��Center=�6I   $��3��6k   $��2��6{   �� 59   
   -   5        $	 lbProdPrice_Copy3��59      $��Cup(s)��6+   $��0,0,33,0q�6<   $��7��6N   $��Center=�6[   $��7��6}   �� 5:   
   -   5        $	 lbProdPrice_Copy4��5:      $��Cup(s)��6+   $��0,0,33,0q�6<   $��6��6N   $��Center=�6[   $��7��6}   �� 5;   
   -   5        $	 lbProdPrice_Copy5��5;      $��Cup(s)��6+   $��0,0,33,0q�6<   $��5��6N   $��Center=�6[   $��7��6}    J� RenderTransformOrigin$ 1.25,0.5&�6�   �� 5<   
   -   5        $	 lbProdPrice_Copy��5<      $
��Baht��6*   $��4��69   $��Center=�6F   $��3��6h   $ 1.25,0.5&�6x   $��2��6�   �� 5=   
   -   5        $	 lbProdPrice_Copy1��5=      $��Cup(s)��6+   $��3��6<   $��Center=�6I   $��3��6k   $ 1.25,0.5&�6{   $��2��6�   �� 5>   
   -   5        $	 lbProdPrice_Copy6��5>      $
��Baht��6+   $��9��6:   $��Center=�6G   $��3��6i   $ 1.25,0.5&�6y   $��2��6�   �� 5?   
   -   5        $	 lbAlert��5?      $
��Left=�6!   $��26,5,0,0q�6<   $��10��6N   $	��Top=�6\   $��8��6t   $	��333��6�   5A      5B      